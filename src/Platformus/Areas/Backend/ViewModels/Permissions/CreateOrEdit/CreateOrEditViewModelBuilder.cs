// Copyright © 2015 Dmitry Sikorsky. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using Platformus.Data;
using Platformus.Models;

namespace Platformus.Areas.Backend.ViewModels.Permissions
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
        };

      Permission permission = this.handler.Storage.GetRepository<IPermissionRepository>().WithKey((int)id);

      return new CreateOrEditViewModel()
      {
        Id = permission.Id,
        Code = permission.Code,
        Name = permission.Name,
        Position = permission.Position
      };
    }
  }
}