﻿// Copyright © 2015 Dmitry Sikorsky. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System.Collections.Generic;
using System.Linq;
using Microsoft.Data.Entity;
using Platformus.Models;

namespace Platformus.Data.EntityFramework.Sqlite
{
  public class MenuItemRepository : RepositoryBase<MenuItem>, IMenuItemRepository
  {
    public MenuItem WithKey(int id)
    {
      return this.dbSet.FirstOrDefault(mi => mi.Id == id);
    }

    public IEnumerable<MenuItem> FilteredByMenuId(int menuId)
    {
      return this.dbSet.Where(mi => mi.MenuId == menuId).OrderBy(mi => mi.Position);
    }

    public IEnumerable<MenuItem> FilteredByMenuItemId(int menuItemId)
    {
      return this.dbSet.Where(mi => mi.MenuItemId == menuItemId).OrderBy(mi => mi.Position);
    }

    public void Create(MenuItem menuItem)
    {
      this.dbSet.Add(menuItem);
    }

    public void Edit(MenuItem menuItem)
    {
      this.dbContext.Entry(menuItem).State = EntityState.Modified;
    }

    public void Delete(int id)
    {
      this.Delete(this.WithKey(id));
    }

    public void Delete(MenuItem menuItem)
    {
      this.dbContext.Database.ExecuteSqlCommand(
        @"
          CREATE TEMP TABLE TempMenuItems (Id INT PRIMARY KEY);
          INSERT INTO TempMenuItems VALUES ({0});
          WHILE @@ROWCOUNT > 0
            INSERT INTO TempMenuItems 
              SELECT DISTINCT MenuItems.Id 
              FROM MenuItems
              INNER JOIN TempMenuItems ON MenuItems.MenuItemId = TempMenuItems.Id
              WHERE MenuItems.Id NOT IN (SELECT Id FROM TempMenuItems);
          CREATE TEMP TABLE TempDictionaries (Id INT PRIMARY KEY);
          INSERT INTO TempDictionaries SELECT NameId FROM MenuItems WHERE Id IN (SELECT Id FROM TempMenuItems);
          DELETE FROM MenuItems WHERE Id IN (SELECT Id FROM TempMenuItems);
          DELETE FROM Localizations WHERE DictionaryId IN (SELECT Id FROM TempDictionaries);
          DELETE FROM Dictionaries WHERE Id IN (SELECT Id FROM TempDictionaries);
        ",
        menuItem.Id
      );
    }
  }
}