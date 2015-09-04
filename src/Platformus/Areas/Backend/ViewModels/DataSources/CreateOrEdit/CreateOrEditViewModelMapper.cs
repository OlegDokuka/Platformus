﻿// Copyright © 2015 Dmitry Sikorsky. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using Platformus.Data;
using Platformus.Models;

namespace Platformus.Areas.Backend.ViewModels.DataSources
{
  public class CreateOrEditViewModelMapper : ViewModelBuilderBase
  {
    public CreateOrEditViewModelMapper(IHandler handler)
      : base(handler)
    {
    }

    public DataSource Map(CreateOrEditViewModel createOrEdit)
    {
      DataSource dataSource = new DataSource();

      if (createOrEdit.Id != null)
        dataSource = this.handler.Storage.GetRepository<IDataSourceRepository>().WithKey((int)createOrEdit.Id);

      else dataSource.ClassId = createOrEdit.ClassId;

      dataSource.Code = createOrEdit.Code;
      dataSource.CSharpClassName = createOrEdit.CSharpClassName;
      dataSource.Parameters = createOrEdit.Parameters;
      return dataSource;
    }
  }
}