// Copyright © 2015 Dmitry Sikorsky. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using Microsoft.AspNet.Mvc;
using Platformus.Data;
using Platformus.ViewModels.Shared;

namespace Platformus.ViewComponents
{
  public class CulturesViewComponent : ViewComponentBase
  {
    public CulturesViewComponent(IStorage storage)
      : base(storage)
    {
    }

    public IViewComponentResult Invoke()
    {
      return this.View(new CulturesViewModelBuilder(this).Build());
    }
  }
}