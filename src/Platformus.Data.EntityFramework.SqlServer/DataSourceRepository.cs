﻿// Copyright © 2015 Dmitry Sikorsky. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System.Collections.Generic;
using System.Linq;
using Microsoft.Data.Entity;
using Platformus.Models;

namespace Platformus.Data.EntityFramework.SqlServer
{
  public class DataSourceRepository : RepositoryBase<DataSource>, IDataSourceRepository
  {
    public DataSource WithKey(int id)
    {
      return this.dbSet.FirstOrDefault(ds => ds.Id == id);
    }

    public IEnumerable<DataSource> FilteredByClassId(int classId)
    {
      return this.dbSet.Where(ds => ds.ClassId == classId).OrderBy(ds => ds.CSharpClassName);
    }

    public IEnumerable<DataSource> FilteredByClassIdRange(int classId, string orderBy, string direction, int skip, int take)
    {
      return this.dbSet.Where(ds => ds.ClassId == classId).OrderBy(ds => ds.CSharpClassName).Skip(skip).Take(take);
    }

    public void Create(DataSource dataSource)
    {
      this.dbSet.Add(dataSource);
    }

    public void Edit(DataSource dataSource)
    {
      this.dbContext.Entry(dataSource).State = EntityState.Modified;
    }

    public void Delete(int id)
    {
      this.Delete(this.WithKey(id));
    }

    public void Delete(DataSource dataSource)
    {
      this.dbContext.Database.ExecuteSqlCommand(
        @"
          DELETE FROM CachedObjects WHERE ClassId IN (SELECT ClassId FROM DataSources WHERE Id = {0});
        ",
        dataSource.Id
      );

      this.dbSet.Remove(dataSource);
    }

    public int CountByClassId(int classId)
    {
      return this.dbSet.Count(ds => ds.ClassId == classId);
    }
  }
}