// Copyright © 2015 Dmitry Sikorsky. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;
using Platformus.Data;
using Platformus.Models;

namespace Platformus.ViewModels.Shared
{
  public class MenuItemViewModelBuilder : ViewModelBuilderBase
  {
    public MenuItemViewModelBuilder(IHandler handler)
      : base(handler)
    {
    }

    public MenuItemViewModel Build(MenuItem menuItem)
    {
      string url = string.Empty;

      if (menuItem.ObjectId == null)
        url = menuItem.Url;
      
      url = this.handler.Storage.GetRepository<IObjectRepository>().WithKey((int)menuItem.ObjectId).Url;

      return new MenuItemViewModel()
      {
        Name = this.GetObjectLocalizationValue(menuItem.NameId),
        Url = url,
        MenuItems = this.handler.Storage.GetRepository<IMenuItemRepository>().FilteredByMenuItemId(menuItem.Id).Select(
          mi => new MenuItemViewModelBuilder(this.handler).Build(mi)
        )
      };
    }

    public MenuItemViewModel Build(CachedMenuItem cachedMenuItem)
    {
      IEnumerable<CachedMenuItem> cachedMenuItems = new CachedMenuItem[] { };

      if (!string.IsNullOrEmpty(cachedMenuItem.CachedMenuItems))
        cachedMenuItems = JsonConvert.DeserializeObject<IEnumerable<CachedMenuItem>>(cachedMenuItem.CachedMenuItems);

      return new MenuItemViewModel()
      {
        Name = cachedMenuItem.Name,
        Url = cachedMenuItem.Url,
        MenuItems = cachedMenuItems.OrderBy(cmi => cmi.Position).Select(
          cmi => new MenuItemViewModelBuilder(this.handler).Build(cmi)
        )
      };
    }
  }
}