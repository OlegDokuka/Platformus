﻿// Copyright © 2015 Dmitry Sikorsky. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using Platformus.Data;
using Platformus.Models;

namespace Platformus.Areas.Backend.ViewModels.Roles
{
  public class CreateOrEditViewModelMapper : ViewModelBuilderBase
  {
    public CreateOrEditViewModelMapper(IHandler handler)
      : base(handler)
    {
    }

    public Role Map(CreateOrEditViewModel createOrEdit)
    {
      Role role = new Role();

      if (createOrEdit.Id != null)
        role = this.handler.Storage.GetRepository<IRoleRepository>().WithKey((int)createOrEdit.Id);

      role.Code = createOrEdit.Code;
      role.Name = createOrEdit.Name;
      role.Position = createOrEdit.Position;
      return role;
    }
  }
}