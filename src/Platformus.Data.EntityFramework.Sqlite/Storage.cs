// Copyright © 2015 Dmitry Sikorsky. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System;
using System.Reflection;

namespace Platformus.Data.EntityFramework.Sqlite
{
  public class Storage : IStorage
  {
    public static string ConnectionString { get; set; }

    public PlatformusDbContext DbContext { get; private set; }

    public Storage()
    {
      this.DbContext = new PlatformusDbContext(Storage.ConnectionString);

      if (this.DbContext.Database.EnsureCreated())
        this.CreateDefaultData();
    }

    private void CreateDefaultData()
    {
    }

    public TRepository GetRepository<TRepository>() where TRepository : IRepository
    {
      foreach (Type type in this.GetType().GetTypeInfo().Assembly.GetTypes())
      {
        if (typeof(TRepository).IsAssignableFrom(type) && type.GetTypeInfo().IsClass)
        {
          TRepository result = (TRepository)Activator.CreateInstance(type);

          result.SetContext(this.DbContext);
          return result;
        }
      }

      return default(TRepository);
    }

    public void Save()
    {
      this.DbContext.SaveChanges();
    }
  }
}