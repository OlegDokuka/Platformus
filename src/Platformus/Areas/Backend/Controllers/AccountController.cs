// Copyright © 2015 Dmitry Sikorsky. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using Microsoft.AspNet.Mvc;
using Platformus.Areas.Backend.ViewModels.Account;
using Platformus.Data;
using Platformus.Models;

namespace Platformus.Areas.Backend.Controllers
{
  [Area("Backend")]
  public class AccountController : ControllerBase
  {
    public AccountController(IStorage storage)
      : base(storage)
    {
    }

    [HttpGet]
    [ImportModelStateFromTempData]
    public IActionResult SignIn()
    {
      return this.View();
    }

    [HttpPost]
    [ExportModelStateToTempData]
    public IActionResult SignIn(SignInViewModel signIn)
    {
      if (this.ModelState.IsValid)
      {
        UserManager userManager = new UserManager(this);
        User user = userManager.Validate("Email", signIn.Email, signIn.Password);

        if (user != null)
        {
          userManager.SignIn(user);
          return this.RedirectToAction("Index", "Default");
        }
      }

      return this.CreateRedirectToSelfResult();
    }
  }
}