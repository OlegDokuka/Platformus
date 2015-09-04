﻿// Copyright © 2015 Dmitry Sikorsky. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System.Collections.Generic;
using System.Linq;
using Microsoft.Data.Entity;
using Platformus.Models;

namespace Platformus.Data.EntityFramework.SqlServer
{
  public class CultureRepository : RepositoryBase<Culture>, ICultureRepository
  {
    public Culture WithKey(int id)
    {
      return this.dbSet.FirstOrDefault(c => c.Id == id);
    }

    public Culture WithCode(string code)
    {
      return this.dbSet.FirstOrDefault(c => string.Equals(c.Code, code, System.StringComparison.OrdinalIgnoreCase));
    }

    public IEnumerable<Culture> All()
    {
      return this.dbSet.OrderBy(c => c.Code);
    }

    public IEnumerable<Culture> Range(string orderBy, string direction, int skip, int take)
    {
      return this.dbSet.OrderBy(c => c.Name).Skip(skip).Take(take);
    }

    public void Create(Culture culture)
    {
      this.dbSet.Add(culture);
    }

    public void Edit(Culture culture)
    {
      this.dbContext.Entry(culture).State = EntityState.Modified;
    }

    public void Delete(int id)
    {
      this.Delete(this.WithKey(id));
    }

    public void Delete(Culture culture)
    {
      this.dbContext.Database.ExecuteSqlCommand(
        @"
          DELETE FROM CachedObjects WHERE CultureId = {0};
          DELETE FROM CachedMenus WHERE CultureId = {0};
          DELETE FROM CachedForms WHERE CultureId = {0};
          DELETE FROM Localizations WHERE CultureId = {0};
        ",
        culture.Id
      );

      this.dbSet.Remove(culture);
    }

    public int Count()
    {
      return this.dbSet.Count();
    }
  }
}