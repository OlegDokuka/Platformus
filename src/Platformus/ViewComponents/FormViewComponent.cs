// Copyright © 2015 Dmitry Sikorsky. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using Microsoft.AspNet.Mvc;
using Platformus.Data;
using Platformus.Models;
using Platformus.ViewModels.Shared;

namespace Platformus.ViewComponents
{
  public class FormViewComponent : ViewComponentBase
  {
    public FormViewComponent(IStorage storage)
      : base(storage)
    {
    }

    public IViewComponentResult Invoke(string code)
    {
      CachedForm cachedForm = this.Storage.GetRepository<ICachedFormRepository>().WithCultureIdAndCode(
        CultureProvider.GetCulture(this.Storage).Id, code
      );

      if (cachedForm == null)
      {
        Form form = this.Storage.GetRepository<IFormRepository>().WithCode(code);

        if (form == null)
          return null;

        return this.View(new FormViewModelBuilder(this).Build(form));
      }

      return this.View(new FormViewModelBuilder(this).Build(cachedForm));
    }
  }
}