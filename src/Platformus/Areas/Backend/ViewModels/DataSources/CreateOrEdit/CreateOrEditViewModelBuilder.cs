// Copyright © 2015 Dmitry Sikorsky. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Platformus.Areas.Backend.ViewModels.Shared;
using Platformus.Data;
using Platformus.DataSources;
using Platformus.Models;

namespace Platformus.Areas.Backend.ViewModels.DataSources
{
  public class CreateOrEditViewModelBuilder : ViewModelBuilderBase
  {
    public CreateOrEditViewModelBuilder(IHandler handler)
      : base(handler)
    {
    }

    public CreateOrEditViewModel Build(int? id)
    {
      if (id == null)
        return new CreateOrEditViewModel()
        {
          CSharpClassNameOptions = this.GetCSharpClassNameOptions()
        };

      DataSource dataSource = this.handler.Storage.GetRepository<IDataSourceRepository>().WithKey((int)id);

      return new CreateOrEditViewModel()
      {
        Id = dataSource.Id,
        Code = dataSource.Code,
        CSharpClassName = dataSource.CSharpClassName,
        CSharpClassNameOptions = this.GetCSharpClassNameOptions(),
        Parameters = dataSource.Parameters
      };
    }

    private IEnumerable<OptionViewModel> GetCSharpClassNameOptions()
    {
      return this.GetType().GetTypeInfo().Assembly.GetTypes().Where(t => typeof(IDataSource).IsAssignableFrom(t) && t.GetTypeInfo().IsClass && t != typeof(DataSourceBase)).Select(
        t => new OptionViewModelBuilder(this.handler).Build(t.FullName)
      );
    }
  }
}