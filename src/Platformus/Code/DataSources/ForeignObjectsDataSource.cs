// Copyright © 2015 Dmitry Sikorsky. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System.Collections.Generic;
using Platformus.Data;
using Platformus.Models;

namespace Platformus.DataSources
{
  public class ForeignObjectsDataSource : DataSourceBase
  {
    public override IEnumerable<Object> GetObjects()
    {
      if (this.args.ContainsKey("MemberId"))
        return this.handler.Storage.GetRepository<IObjectRepository>().Foreign(int.Parse(this.args["MemberId"]), this.@object.Id);

      return this.handler.Storage.GetRepository<IObjectRepository>().Foreign(this.@object.Id);
    }

    public override IEnumerable<CachedObject> GetCachedObjects()
    {
      if (this.args.ContainsKey("MemberId"))
        return this.handler.Storage.GetRepository<ICachedObjectRepository>().Foreign(
          CultureProvider.GetCulture(this.handler.Storage).Id, int.Parse(this.args["MemberId"]), this.cachedObject.ObjectId
        );

      return this.handler.Storage.GetRepository<ICachedObjectRepository>().Foreign(
        CultureProvider.GetCulture(this.handler.Storage).Id, this.cachedObject.ObjectId
      );
    }
  }
}