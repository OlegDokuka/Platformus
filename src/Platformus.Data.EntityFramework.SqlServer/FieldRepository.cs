﻿// Copyright © 2015 Dmitry Sikorsky. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System.Collections.Generic;
using System.Linq;
using Microsoft.Data.Entity;
using Platformus.Models;

namespace Platformus.Data.EntityFramework.SqlServer
{
  public class FieldRepository : RepositoryBase<Field>, IFieldRepository
  {
    public Field WithKey(int id)
    {
      return this.dbSet.FirstOrDefault(f => f.Id == id);
    }

    public IEnumerable<Field> FilteredByFormId(int formId)
    {
      return this.dbSet.Where(f => f.FormId == formId).OrderBy(f => f.Position);
    }

    public void Create(Field field)
    {
      this.dbSet.Add(field);
    }

    public void Edit(Field field)
    {
      this.dbContext.Entry(field).State = EntityState.Modified;
    }

    public void Delete(int id)
    {
      this.Delete(this.WithKey(id));
    }

    public void Delete(Field field)
    {
      this.dbContext.Database.ExecuteSqlCommand(
        @"
          CREATE TABLE #Dictionaries (Id INT PRIMARY KEY);
          INSERT INTO #Dictionaries SELECT ValueId FROM FieldOptions WHERE FieldId = {0};
          INSERT INTO #Dictionaries SELECT NameId FROM Fields WHERE Id = {0};
          DELETE FROM FieldOptions WHERE FieldId = {0};
          DELETE FROM Fields WHERE Id = {0};
          DELETE FROM Localizations WHERE DictionaryId IN (SELECT Id FROM #Dictionaries);
          DELETE FROM Dictionaries WHERE Id IN (SELECT Id FROM #Dictionaries);
        ",
        field.Id
      );
    }
  }
}