// Copyright © 2015 Dmitry Sikorsky. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System.Linq;
using Platformus.Areas.Backend.ViewModels.Shared;
using Platformus.Data;

namespace Platformus.Areas.Backend.ViewModels.DataTypes
{
  public class IndexViewModelBuilder : ViewModelBuilderBase
  {
    public IndexViewModelBuilder(IHandler handler)
      : base(handler)
    {
    }

    public IndexViewModel Build(string orderBy, string direction, int skip, int take)
    {
      IDataTypeRepository dataTypeRepository = this.handler.Storage.GetRepository<IDataTypeRepository>();

      return new IndexViewModel()
      {
        Grid = new GridViewModelBuilder(this.handler).Build(
          orderBy, direction, skip, take, dataTypeRepository.Count(),
          new[] {
            new GridColumnViewModelBuilder(this.handler).Build("Name", "Name"),
            new GridColumnViewModelBuilder(this.handler).Build("Position", "Position"),
            new GridColumnViewModelBuilder(this.handler).BuildEmpty()
          },
          dataTypeRepository.Range(orderBy, direction, skip, take).Select(dt => new DataTypeViewModelBuilder(this.handler).Build(dt)),
          "_DataType"
        )
      };
    }
  }
}