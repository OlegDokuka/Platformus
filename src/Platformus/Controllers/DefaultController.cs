// Copyright © 2015 Dmitry Sikorsky. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System.Linq;
using System.Text;
using Microsoft.AspNet.Mvc;
using Platformus.Data;
using Platformus.Models;
using Platformus.ViewModels.Shared;

namespace Platformus.Controllers
{
  public class DefaultController : ControllerBase
  {
    public DefaultController(IStorage storage)
      : base(storage)
    {
    }

    public IActionResult Index(string url)
    {
      url = string.Format("/{0}", url);

      CachedObject cachedObject = this.Storage.GetRepository<ICachedObjectRepository>().WithCultureIdAndUrl(
        CultureProvider.GetCulture(this.Storage).Id, url
      );

      if (cachedObject == null)
      {
        Object @object = this.Storage.GetRepository<IObjectRepository>().WithUrl(url);

        if (@object == null)
          return this.HttpNotFound();

        ObjectViewModel result = new ObjectViewModelBuilder(this).Build(@object);

        return this.View(result.Class.ViewName, result);
      }

      {
        ObjectViewModel result = new ObjectViewModelBuilder(this).Build(cachedObject);

        return this.View(result.Class.ViewName, result);
      }
    }

    [HttpPost]
    public IActionResult Form()
    {
      StringBuilder body = new StringBuilder();
      Form form = this.Storage.GetRepository<IFormRepository>().WithKey(int.Parse(this.Request.Form["formId"]));

      foreach (Field field in this.Storage.GetRepository<IFieldRepository>().FilteredByFormId(form.Id))
      {
        string value = this.Request.Form[string.Format("field{0}", field.Id)];

        body.AppendFormat(
          "<p>{0}: {1}</p>",
          this.Storage.GetRepository<ILocalizationRepository>().FilteredByDictionaryId(field.NameId).First().Value,
          value
        );
      }

      return null;
    }
  }
}