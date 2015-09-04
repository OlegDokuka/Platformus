// Copyright © 2015 Dmitry Sikorsky. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System.Linq;
using Platformus.Data;
using Platformus.Models;

namespace Platformus.Areas.Backend.ViewModels.Shared
{
  public class MenuItemViewModelBuilder : ViewModelBuilderBase
  {
    public MenuItemViewModelBuilder(IHandler handler)
      : base(handler)
    {
    }

    public MenuItemViewModel Build(MenuItem menuItem)
    {
      return new MenuItemViewModel()
      {
        Id = menuItem.Id,
        Name = this.handler.Storage.GetRepository<ILocalizationRepository>().FilteredByDictionaryId(menuItem.NameId).First().Value,
        MenuItems = this.handler.Storage.GetRepository<IMenuItemRepository>().FilteredByMenuItemId(menuItem.Id).Select(
          mi => new MenuItemViewModelBuilder(this.handler).Build(mi)
        )
      };
    }
  }
}