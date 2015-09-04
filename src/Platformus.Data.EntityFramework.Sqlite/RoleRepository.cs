﻿// Copyright © 2015 Dmitry Sikorsky. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System.Collections.Generic;
using System.Linq;
using Microsoft.Data.Entity;
using Platformus.Models;

namespace Platformus.Data.EntityFramework.Sqlite
{
  public class RoleRepository : RepositoryBase<Role>, IRoleRepository
  {
    public Role WithKey(int id)
    {
      return this.dbSet.FirstOrDefault(r => r.Id == id);
    }

    public IEnumerable<Role> All()
    {
      return this.dbSet.OrderBy(r => r.Position);
    }

    public IEnumerable<Role> Range(string orderBy, string direction, int skip, int take)
    {
      return this.dbSet.OrderBy(r => r.Position).Skip(skip).Take(take);
    }

    public void Create(Role role)
    {
      this.dbSet.Add(role);
    }

    public void Edit(Role role)
    {
      this.dbContext.Entry(role).State = EntityState.Modified;
    }

    public void Delete(int id)
    {
      this.Delete(this.WithKey(id));
    }

    public void Delete(Role role)
    {
      this.dbContext.Database.ExecuteSqlCommand(
        @"
          DELETE FROM RolePermissions WHERE RoleId = {0};
          DELETE FROM UserRoles WHERE RoleId = {0};
        ",
        role.Id
      );

      this.dbSet.Remove(role);
    }

    public int Count()
    {
      return this.dbSet.Count();
    }
  }
}