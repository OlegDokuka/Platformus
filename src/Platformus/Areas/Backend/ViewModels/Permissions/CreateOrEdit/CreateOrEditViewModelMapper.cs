// Copyright © 2015 Dmitry Sikorsky. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using Platformus.Data;
using Platformus.Models;

namespace Platformus.Areas.Backend.ViewModels.Permissions
{
  public class CreateOrEditViewModelMapper : ViewModelBuilderBase
  {
    public CreateOrEditViewModelMapper(IHandler handler)
      : base(handler)
    {
    }

    public Permission Map(CreateOrEditViewModel createOrEdit)
    {
      Permission permission = new Permission();

      if (createOrEdit.Id != null)
        permission = this.handler.Storage.GetRepository<IPermissionRepository>().WithKey((int)createOrEdit.Id);

      permission.Code = createOrEdit.Code;
      permission.Name = createOrEdit.Name;
      permission.Position = createOrEdit.Position;
      return permission;
    }
  }
}