// Copyright © 2015 Dmitry Sikorsky. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System.Collections.Generic;
using System.Linq;
using Platformus.Areas.Backend.ViewModels.Shared;
using Platformus.Data;
using Platformus.Models;

namespace Platformus.Areas.Backend.ViewModels.Roles
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
          RolePermissions = this.GetRolePermissions()
        };

      Role role = this.handler.Storage.GetRepository<IRoleRepository>().WithKey((int)id);

      return new CreateOrEditViewModel()
      {
        Id = role.Id,
        Code = role.Code,
        Name = role.Name,
        Position = role.Position,
        RolePermissions = this.GetRolePermissions(role)
      };
    }

    public IEnumerable<RolePermissionViewModel> GetRolePermissions(Role role = null)
    {
      return this.handler.Storage.GetRepository<IPermissionRepository>().All().Select(
        p => new RolePermissionViewModelBuilder(this.handler).Build(role, p)
      );
    }
  }
}