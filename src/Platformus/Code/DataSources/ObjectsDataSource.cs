﻿// Copyright © 2015 Dmitry Sikorsky. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System.Collections.Generic;
using System.Linq;
using Platformus.Data;
using Platformus.Models;

namespace Platformus.DataSources
{
  public class ObjectsDataSource : DataSourceBase
  {
    public override IEnumerable<Object> GetObjects()
    {
      return this.handler.Storage.GetRepository<IObjectRepository>().All().Where(o => o.ClassId == int.Parse(this.args["ClassId"]));
    }

    public override IEnumerable<CachedObject> GetCachedObjects()
    {
      return this.handler.Storage.GetRepository<ICachedObjectRepository>().FilteredByCultureId(CultureProvider.GetCulture(this.handler.Storage).Id).Where(o => o.ClassId == int.Parse(this.args["ClassId"]));
    }
  }
}