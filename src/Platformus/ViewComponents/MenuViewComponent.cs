// Copyright © 2015 Dmitry Sikorsky. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using Microsoft.AspNet.Mvc;
using Platformus.Data;
using Platformus.Models;
using Platformus.ViewModels.Shared;

namespace Platformus.ViewComponents
{
  public class MenuViewComponent : ViewComponentBase
  {
    public MenuViewComponent(IStorage storage)
      : base(storage)
    {
    }

    public IViewComponentResult Invoke(string code)
    {
      CachedMenu cachedMenu = this.Storage.GetRepository<ICachedMenuRepository>().WithCultureIdAndCode(
        CultureProvider.GetCulture(this.Storage).Id, code
      );

      if (cachedMenu == null)
      {
        Menu menu = this.Storage.GetRepository<IMenuRepository>().WithCode(code);

        if (menu == null)
          return null;

        return this.View(new MenuViewModelBuilder(this).Build(menu));
      }

      return this.View(new MenuViewModelBuilder(this).Build(cachedMenu));
    }
  }
}