﻿// Copyright © 2015 Dmitry Sikorsky. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System.Collections.Generic;
using Platformus.Models;

namespace Platformus.DataSources
{
  public interface IDataSource
  {
    void Initialize(IHandler context, Object @object, params KeyValuePair<string, string>[] args);
    void Initialize(IHandler context, CachedObject cachedObject, params KeyValuePair<string, string>[] args);
    IEnumerable<Object> GetObjects();
    IEnumerable<CachedObject> GetCachedObjects();
  }
}