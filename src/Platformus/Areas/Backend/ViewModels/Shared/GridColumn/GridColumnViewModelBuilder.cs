﻿// Copyright © 2015 Dmitry Sikorsky. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

namespace Platformus.Areas.Backend.ViewModels.Shared
{
  public class GridColumnViewModelBuilder : ViewModelBuilderBase
  {
    public GridColumnViewModelBuilder(IHandler handler)
      : base(handler)
    {
    }

    public GridColumnViewModel Build(string name, string orderBy = null)
    {
      return new GridColumnViewModel()
      {
        Name = name,
        OrderBy = string.IsNullOrEmpty(orderBy) ? null : orderBy.ToLower()
      };
    }

    public GridColumnViewModel BuildEmpty()
    {
      return new GridColumnViewModel()
      {
        Name = "&nbsp;"
      };
    }
  }
}