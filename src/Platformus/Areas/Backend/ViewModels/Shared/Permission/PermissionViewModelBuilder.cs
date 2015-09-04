// Copyright © 2015 Dmitry Sikorsky. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using Platformus.Models;

namespace Platformus.Areas.Backend.ViewModels.Shared
{
  public class PermissionViewModelBuilder : ViewModelBuilderBase
  {
    public PermissionViewModelBuilder(IHandler handler)
      : base(handler)
    {
    }

    public PermissionViewModel Build(Permission permission)
    {
      return new PermissionViewModel()
      {
        Id = permission.Id,
        Name = permission.Name,
        Position = permission.Position
      };
    }
  }
}