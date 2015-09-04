﻿// Copyright © 2015 Dmitry Sikorsky. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System.Collections.Generic;
using System.Linq;
using Microsoft.Data.Entity;
using Platformus.Models;

namespace Platformus.Data.EntityFramework.SqlServer
{
  public class UserRepository : RepositoryBase<User>, IUserRepository
  {
    public User WithKey(int id)
    {
      return this.dbSet.FirstOrDefault(u => u.Id == id);
    }

    public IEnumerable<User> Range(string orderBy, string direction, int skip, int take)
    {
      return this.dbSet.OrderBy(u => u.Name).Skip(skip).Take(take);
    }

    public void Create(User user)
    {
      this.dbSet.Add(user);
    }

    public void Edit(User user)
    {
      this.dbContext.Entry(user).State = EntityState.Modified;
    }

    public void Delete(int id)
    {
      this.Delete(this.WithKey(id));
    }

    public void Delete(User user)
    {
      this.dbContext.Database.ExecuteSqlCommand(
        @"
          DELETE FROM UserRoles WHERE UserId = {0};
          DELETE FROM Credentials WHERE UserId = {0};
        ",
        user.Id
      );

      this.dbSet.Remove(user);
    }

    public int Count()
    {
      return this.dbSet.Count();
    }
  }
}