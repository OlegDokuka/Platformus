// Copyright © 2015 Dmitry Sikorsky. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using Platformus.Data;
using Platformus.Models;

namespace Platformus.Areas.Backend.ViewModels.Variables
{
  public class CreateOrEditViewModelMapper : ViewModelBuilderBase
  {
    public CreateOrEditViewModelMapper(IHandler handler)
      : base(handler)
    {
    }

    public Variable Map(CreateOrEditViewModel createOrEdit)
    {
      Variable variable = new Variable();

      if (createOrEdit.Id != null)
        variable = this.handler.Storage.GetRepository<IVariableRepository>().WithKey((int)createOrEdit.Id);

      else variable.ConfigurationId = createOrEdit.ConfigurationId;

      variable.Code = createOrEdit.Code;
      variable.Name = createOrEdit.Name;
      variable.Value = createOrEdit.Value;
      variable.Position = createOrEdit.Position;
      return variable;
    }
  }
}