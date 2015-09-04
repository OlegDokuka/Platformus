﻿// Copyright © 2015 Dmitry Sikorsky. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using Platformus.Models;

namespace Platformus.Data
{
  public interface ICachedFormRepository : IRepository
  {
    CachedForm WithKey(int cultureId, int formId);
    CachedForm WithCultureIdAndCode(int cultureId, string code);
    void Create(CachedForm cachedForm);
    void Edit(CachedForm cachedForm);
    void Delete(int cultureId, int formId);
    void Delete(CachedForm cachedForm);
  }
}