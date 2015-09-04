// Copyright © 2015 Dmitry Sikorsky. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using Platformus.Data;
using Platformus.Models;

namespace Platformus.Areas.Backend.ViewModels.MenuItems
{
  public class CreateOrEditViewModelMapper : ViewModelBuilderBase
  {
    public CreateOrEditViewModelMapper(IHandler handler)
      : base(handler)
    {
    }

    public MenuItem Map(CreateOrEditViewModel createOrEdit)
    {
      MenuItem menuItem = new MenuItem();

      if (createOrEdit.Id != null)
        menuItem = this.handler.Storage.GetRepository<IMenuItemRepository>().WithKey((int)createOrEdit.Id);

      else
      {
        menuItem.MenuId = createOrEdit.MenuId;
        menuItem.MenuItemId = createOrEdit.MenuItemId;
      }

      menuItem.ObjectId = createOrEdit.ObjectId;
      menuItem.Url = createOrEdit.Url;
      menuItem.Position = createOrEdit.Position;
      return menuItem;
    }
  }
}