﻿// Copyright © 2015 Dmitry Sikorsky. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System.Collections.Generic;
using System.Linq;
using Microsoft.Data.Entity;
using Platformus.Models;

namespace Platformus.Data.EntityFramework.SqlServer
{
  public class UserRoleRepository : RepositoryBase<UserRole>, IUserRoleRepository
  {
    public UserRole WithKey(int userId, int roleId)
    {
      return this.dbSet.FirstOrDefault(ur => ur.UserId == userId && ur.RoleId == roleId);
    }

    public IEnumerable<UserRole> FilteredByUserId(int userId)
    {
      return this.dbSet.Where(ur => ur.UserId == userId);
    }

    public void Create(UserRole userRole)
    {
      this.dbSet.Add(userRole);
    }

    public void Edit(UserRole userRole)
    {
      this.dbContext.Entry(userRole).State = EntityState.Modified;
    }

    public void Delete(int userId, int roleId)
    {
      this.Delete(this.WithKey(userId, roleId));
    }

    public void Delete(UserRole userRole)
    {
      this.dbSet.Remove(userRole);
    }
  }
}