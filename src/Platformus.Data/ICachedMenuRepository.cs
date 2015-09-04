﻿// Copyright © 2015 Dmitry Sikorsky. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using Platformus.Models;

namespace Platformus.Data
{
  public interface ICachedMenuRepository : IRepository
  {
    CachedMenu WithKey(int cultureId, int menuId);
    CachedMenu WithCultureIdAndCode(int cultureId, string code);
    void Create(CachedMenu cachedMenu);
    void Edit(CachedMenu cachedMenu);
    void Delete(int cultureId, int menuId);
    void Delete(CachedMenu cachedMenu);
  }
}