// Copyright © 2015 Dmitry Sikorsky. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System;
using Platformus.Data;
using Platformus.Models;

namespace Platformus.Areas.Backend.ViewModels.Users
{
  public class CreateOrEditViewModelMapper : ViewModelBuilderBase
  {
    public CreateOrEditViewModelMapper(IHandler handler)
      : base(handler)
    {
    }

    public User Map(CreateOrEditViewModel createOrEdit)
    {
      User user = new User();

      if (createOrEdit.Id != null)
        user = this.handler.Storage.GetRepository<IUserRepository>().WithKey((int)createOrEdit.Id);

      else user.Created = DateTime.Now;

      user.Name = createOrEdit.Name;
      return user;
    }
  }
}