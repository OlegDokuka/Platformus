// Copyright © 2015 Dmitry Sikorsky. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System.Linq;
using Platformus.Areas.Backend.ViewModels.Shared;
using Platformus.Data;

namespace Platformus.Areas.Backend.ViewModels.DataSources
{
  public class IndexViewModelBuilder : ViewModelBuilderBase
  {
    public IndexViewModelBuilder(IHandler handler)
      : base(handler)
    {
    }

    public IndexViewModel Build(int classId, string orderBy, string direction, int skip, int take)
    {
      IDataSourceRepository dataSourceRepository = this.handler.Storage.GetRepository<IDataSourceRepository>();

      return new IndexViewModel()
      {
        ClassId = classId,
        Grid = new GridViewModelBuilder(this.handler).Build(
          orderBy, direction, skip, take, dataSourceRepository.CountByClassId(classId),
          new[] {
            new GridColumnViewModelBuilder(this.handler).Build("C# class name"),
            new GridColumnViewModelBuilder(this.handler).BuildEmpty()
          },
          dataSourceRepository.FilteredByClassIdRange(classId, orderBy, direction, skip, take).Select(ds => new DataSourceViewModelBuilder(this.handler).Build(ds)),
          "_DataSource"
        )
      };
    }
  }
}