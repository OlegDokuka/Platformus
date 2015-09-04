// Copyright © 2015 Dmitry Sikorsky. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System.Linq;
using Platformus.Data;
using Platformus.Models;

namespace Platformus.Areas.Backend.ViewModels.Shared
{
  public class MenuViewModelBuilder : ViewModelBuilderBase
  {
    public MenuViewModelBuilder(IHandler handler)
      : base(handler)
    {
    }

    public MenuViewModel Build(Menu menu)
    {
      return new MenuViewModel()
      {
        Id = menu.Id,
        Name = this.handler.Storage.GetRepository<ILocalizationRepository>().FilteredByDictionaryId(menu.NameId).First().Value,
        MenuItems = this.handler.Storage.GetRepository<IMenuItemRepository>().FilteredByMenuId(menu.Id).Select(
          mi => new MenuItemViewModelBuilder(this.handler).Build(mi)
        )
      };
    }
  }
}