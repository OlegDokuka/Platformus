﻿// Copyright © 2015 Dmitry Sikorsky. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System.Collections.Generic;
using System.Linq;
using Microsoft.Data.Entity;
using Platformus.Models;

namespace Platformus.Data.EntityFramework.Sqlite
{
  public class FieldOptionRepository : RepositoryBase<FieldOption>, IFieldOptionRepository
  {
    public FieldOption WithKey(int id)
    {
      return this.dbSet.FirstOrDefault(fo => fo.Id == id);
    }

    public IEnumerable<FieldOption> FilteredByFieldId(int fieldId)
    {
      return this.dbSet.Where(fo => fo.FieldId == fieldId).OrderBy(fo => fo.Position);
    }

    public void Create(FieldOption fieldOption)
    {
      this.dbSet.Add(fieldOption);
    }

    public void Edit(FieldOption fieldOption)
    {
      this.dbContext.Entry(fieldOption).State = EntityState.Modified;
    }

    public void Delete(int id)
    {
      this.Delete(this.WithKey(id));
    }

    public void Delete(FieldOption fieldOption)
    {
      this.dbContext.Database.ExecuteSqlCommand(
        @"
          CREATE TABLE #Dictionaries (Id INT PRIMARY KEY);
          INSERT INTO #Dictionaries SELECT ValueId FROM FieldOptions WHERE Id = {0};
          DELETE FROM FieldOptions WHERE Id = {0};
          DELETE FROM Localizations WHERE DictionaryId IN (SELECT Id FROM #Dictionaries);
          DELETE FROM Dictionaries WHERE Id IN (SELECT Id FROM #Dictionaries);
        ",
        fieldOption.Id
      );
    }
  }
}