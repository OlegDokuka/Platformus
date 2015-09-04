// Copyright © 2015 Dmitry Sikorsky. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using Microsoft.Data.Entity;
using Platformus.Models;

namespace Platformus.Data.EntityFramework.Sqlite
{
  public abstract class RepositoryBase<TEntity> : IRepository where TEntity : class, IEntity
  {
    protected PlatformusDbContext dbContext;
    protected DbSet<TEntity> dbSet;

    public void SetContext(IDbContext dbContext)
    {
      this.dbContext = dbContext as PlatformusDbContext;
      this.dbSet = this.dbContext.Set<TEntity>();
    }
  }
}