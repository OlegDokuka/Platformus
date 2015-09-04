﻿// Copyright © 2015 Dmitry Sikorsky. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using Microsoft.AspNet.Mvc;
using Platformus.Areas.Backend.ViewModels.Variables;
using Platformus.Data;
using Platformus.Models;

namespace Platformus.Areas.Backend.Controllers
{
  [Area("Backend")]
  public class VariablesController : ControllerBase
  {
    public VariablesController(IStorage storage)
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
        Variable variable = new CreateOrEditViewModelMapper(this).Map(createOrEdit);

        if (createOrEdit.Id == null)
          this.Storage.GetRepository<IVariableRepository>().Create(variable);

        else this.Storage.GetRepository<IVariableRepository>().Edit(variable);

        this.Storage.Save();
        return this.RedirectToAction("Index", "Configurations");
      }

      return this.CreateRedirectToSelfResult();
    }

    public ActionResult Delete(int id)
    {
      this.Storage.GetRepository<IVariableRepository>().Delete(id);
      this.Storage.Save();
      return this.RedirectToAction("Index", "Configurations");
    }
  }
}