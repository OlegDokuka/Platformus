// Copyright © 2015 Dmitry Sikorsky. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using Platformus.Data;
using Platformus.Models;

namespace Platformus.Areas.Backend.ViewModels.DataTypes
{
  public class CreateOrEditViewModelMapper : ViewModelBuilderBase
  {
    public CreateOrEditViewModelMapper(IHandler handler)
      : base(handler)
    {
    }

    public DataType Map(CreateOrEditViewModel createOrEdit)
    {
      DataType dataType = new DataType();

      if (createOrEdit.Id != null)
        dataType = this.handler.Storage.GetRepository<IDataTypeRepository>().WithKey((int)createOrEdit.Id);

      dataType.JavaScriptEditorClassName = createOrEdit.JavaScriptEditorClassName;
      dataType.Name = createOrEdit.Name;
      dataType.Position = createOrEdit.Position;
      return dataType;
    }
  }
}