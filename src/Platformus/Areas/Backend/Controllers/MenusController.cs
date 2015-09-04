﻿// Copyright © 2015 Dmitry Sikorsky. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using Microsoft.AspNet.Mvc;
using Platformus.Areas.Backend.ViewModels.Menus;
using Platformus.Data;
using Platformus.Models;

namespace Platformus.Areas.Backend.Controllers
{
  [Area("Backend")]
  public class MenusController : ControllerBase
  {
    public MenusController(IStorage storage)
      : base(storage)
    {
    }

    public IActionResult Index()
    {
      return this.View(new IndexViewModelBuilder(this).Build());
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
        Menu menu = new CreateOrEditViewModelMapper(this).Map(createOrEdit);

        this.CreateOrEditEntityLocalizations(menu);

        if (createOrEdit.Id == null)
          this.Storage.GetRepository<IMenuRepository>().Create(menu);

        else this.Storage.GetRepository<IMenuRepository>().Edit(menu);

        this.Storage.Save();
        new CacheManager(this).CacheMenu(menu);
        return this.RedirectToAction("Index");
      }

      return this.CreateRedirectToSelfResult();
    }

    public ActionResult Delete(int id)
    {
      this.Storage.GetRepository<IMenuRepository>().Delete(id);
      this.Storage.Save();
      return this.RedirectToAction("Index");
    }
  }
}