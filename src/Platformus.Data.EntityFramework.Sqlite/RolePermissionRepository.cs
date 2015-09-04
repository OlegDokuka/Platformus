﻿// Copyright © 2015 Dmitry Sikorsky. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System.Collections.Generic;
using System.Linq;
using Microsoft.Data.Entity;
using Platformus.Models;

namespace Platformus.Data.EntityFramework.Sqlite
{
  public class RolePermissionRepository : RepositoryBase<RolePermission>, IRolePermissionRepository
  {
    public RolePermission WithKey(int roleId, int permissionId)
    {
      return this.dbSet.FirstOrDefault(rp => rp.RoleId == roleId && rp.PermissionId == permissionId);
    }

    public IEnumerable<RolePermission> FilteredByRoleId(int roleId)
    {
      return this.dbSet.Where(rp => rp.RoleId == roleId);
    }

    public void Create(RolePermission rolePermission)
    {
      this.dbSet.Add(rolePermission);
    }

    public void Edit(RolePermission rolePermission)
    {
      this.dbContext.Entry(rolePermission).State = EntityState.Modified;
    }

    public void Delete(int roleId, int permissionId)
    {
      this.Delete(this.WithKey(roleId, permissionId));
    }

    public void Delete(RolePermission rolePermission)
    {
      this.dbSet.Remove(rolePermission);
    }
  }
}