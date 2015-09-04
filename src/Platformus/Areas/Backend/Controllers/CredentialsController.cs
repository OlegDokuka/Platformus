﻿// Copyright © 2015 Dmitry Sikorsky. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using Microsoft.AspNet.Mvc;
using Platformus.Areas.Backend.ViewModels.Credentials;
using Platformus.Data;
using Platformus.Models;

namespace Platformus.Areas.Backend.Controllers
{
  [Area("Backend")]
  public class CredentialsController : ControllerBase
  {
    public CredentialsController(IStorage storage)
      : base(storage)
    {
    }

    public IActionResult Index(int userId, string orderBy = "identifier", string direction = "asc", int skip = 0, int take = 10)
    {
      return this.View(new IndexViewModelBuilder(this).Build(userId, orderBy, direction, skip, take));
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
        Credential credential = new CreateOrEditViewModelMapper(this).Map(createOrEdit);

        if (createOrEdit.Id == null)
          this.Storage.GetRepository<ICredentialRepository>().Create(credential);

        else this.Storage.GetRepository<ICredentialRepository>().Edit(credential);

        this.Storage.Save();
        return this.Redirect(this.Request.CombineUrl("/backend/credentials"));
      }

      return this.CreateRedirectToSelfResult();
    }

    public ActionResult Delete(int id)
    {
      Credential credential = this.Storage.GetRepository<ICredentialRepository>().WithKey(id);

      this.Storage.GetRepository<ICredentialRepository>().Delete(credential);
      this.Storage.Save();
      return this.Redirect(string.Format("/backend/credentials?userid={0}", credential.UserId));
    }
  }
}