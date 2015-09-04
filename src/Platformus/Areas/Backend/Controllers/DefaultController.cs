﻿// Copyright © 2015 Dmitry Sikorsky. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System.Text;
using Microsoft.AspNet.Mvc;
using Platformus.Areas.Backend.ViewModels.Default;
using Platformus.Data;
using Platformus.Models;

namespace Platformus.Areas.Backend.Controllers
{
  [Area("Backend")]
  public class DefaultController : ControllerBase
  {
    public DefaultController(IStorage storage)
      : base(storage)
    {
    }

    public IActionResult Index()
    {
      return this.View();
    }

    public ActionResult DeleteForm(string targetUrl)
    {
      return this.PartialView("_DeleteForm", new DeleteFormViewModelBuilder(this).Build(targetUrl));
    }

    public ActionResult FileSelectorForm()
    {
      return this.PartialView("_FileSelectorForm", new FileSelectorFormViewModelBuilder(this).Build());
    }

    public ActionResult ObjectSelectorForm(int classId, string objectIds)
    {
      return this.PartialView("_ObjectSelectorForm", new ObjectSelectorFormViewModelBuilder(this).Build(classId, objectIds));
    }

    public ActionResult GetObjectDisplayValues(string objectIds)
    {
      StringBuilder objectDisplayValues = new StringBuilder();

      if (!string.IsNullOrEmpty(objectIds))
      {
        foreach (string objectId in objectIds.Split(','))
        {
          Object @object = this.Storage.GetRepository<IObjectRepository>().WithKey(int.Parse(objectId));
          
          objectDisplayValues.AppendFormat(
            "<div class=\"display-value\">{0}</div>",
            string.Join(" ", new ObjectManager(this).GetDisplayProperties(@object))
          );
        }
      }

      return this.Content(objectDisplayValues.ToString());
    }
  }
}