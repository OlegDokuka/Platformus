﻿// Copyright © 2015 Dmitry Sikorsky. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using Microsoft.AspNet.Mvc;
using Platformus.Areas.Backend.ViewModels.MenuItems;
using Platformus.Data;
using Platformus.Models;

namespace Platformus.Areas.Backend.Controllers
{
  [Area("Backend")]
  public class MenuItemsController : ControllerBase
  {
    public MenuItemsController(IStorage storage)
      : base(storage)
    {
    }

    [HttpGet]
    [ImportModelStateFromTempData]
    public IActionResult CreateOrEdit(int? id)
    {
      return this.View(new CreateOrEditViewModelBuilder(this).Build(id));
    }

    [HttpPost]
    [ExportModelStateToTempData]
    public IActionResult CreateOrEdit(CreateOrEditViewModel createOrEdit)
    {
      if (this.ModelState.IsValid)
      {
        MenuItem menuItem = new CreateOrEditViewModelMapper(this).Map(createOrEdit);

        this.CreateOrEditEntityLocalizations(menuItem);

        if (createOrEdit.Id == null)
          this.Storage.GetRepository<IMenuItemRepository>().Create(menuItem);

        else this.Storage.GetRepository<IMenuItemRepository>().Edit(menuItem);

        this.Storage.Save();
        this.CacheMenu(menuItem);
        return this.RedirectToAction("Index", "Menus");
      }

      return this.CreateRedirectToSelfResult();
    }

    public ActionResult Delete(int id)
    {
      MenuItem menuItem = this.Storage.GetRepository<IMenuItemRepository>().WithKey(id);
      Menu menu = this.GetMenu(menuItem);

      this.Storage.GetRepository<IMenuItemRepository>().Delete(menuItem);
      this.Storage.Save();
      new CacheManager(this).CacheMenu(menu);
      return this.RedirectToAction("Index", "Menus");
    }

    private void CacheMenu(MenuItem menuItem)
    {
      new CacheManager(this).CacheMenu(this.GetMenu(menuItem));
    }

    private Menu GetMenu(MenuItem menuItem)
    {
      while (menuItem.MenuId == null)
        menuItem = this.Storage.GetRepository<IMenuItemRepository>().WithKey((int)menuItem.MenuItemId);

      return this.Storage.GetRepository<IMenuRepository>().WithKey((int)menuItem.MenuId);
    }
  }
}