// Copyright © 2015 Dmitry Sikorsky. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using Platformus.Models;

namespace Platformus.Areas.Backend.ViewModels.Shared
{
  public class DataSourceViewModelBuilder : ViewModelBuilderBase
  {
    public DataSourceViewModelBuilder(IHandler handler)
      : base(handler)
    {
    }

    public DataSourceViewModel Build(DataSource dataSource)
    {
      return new DataSourceViewModel()
      {
        Id = dataSource.Id,
        CShartClassName = dataSource.CSharpClassName
      };
    }
  }
}