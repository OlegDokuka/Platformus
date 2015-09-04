// Copyright © 2015 Dmitry Sikorsky. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System.Collections.Generic;
using System.Linq;
using Platformus.Areas.Backend.ViewModels.Shared;
using Platformus.Data;

namespace Platformus.Areas.Backend.ViewModels.Default
{
  public class ObjectSelectorFormViewModelBuilder : ViewModelBuilderBase
  {
    public ObjectSelectorFormViewModelBuilder(IHandler handler)
      : base(handler)
    {
    }

    public ObjectSelectorFormViewModel Build(int classId, string objectIds)
    {
      return new ObjectSelectorFormViewModel()
      {
        Class = new ClassViewModelBuilder(this.handler).Build(
          this.handler.Storage.GetRepository<IClassRepository>().WithKey(classId)
        ),
        GridColumns = this.GetGridColumns(classId),
        Objects = this.handler.Storage.GetRepository<IObjectRepository>().FilteredByClassId(classId).Select(
          o => new ObjectViewModelBuilder(this.handler).Build(o)
        ),
        ObjectIds = string.IsNullOrEmpty(objectIds) ? new int[] { } : objectIds.Split(',').Select(objectId => int.Parse(objectId))
      };
    }

    private IEnumerable<GridColumnViewModel> GetGridColumns(int classId)
    {
      return this.handler.Storage.GetRepository<IMemberRepository>().FilteredByClassIdDisplayInList((int)classId).Select(m => new GridColumnViewModelBuilder(this.handler).Build(m.Name));
    }
  }
}