// Copyright © 2015 Dmitry Sikorsky. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using Platformus.Data;
using Platformus.Models;

namespace Platformus.Areas.Backend.ViewModels.Shared
{
  public class PropertyViewModelBuilder : ViewModelBuilderBase
  {
    public PropertyViewModelBuilder(IHandler handler)
      : base(handler)
    {
    }

    public PropertyViewModel Build(Property property)
    {
      //Member member = this.controller.Storage.GetRepository<IMemberRepository>().WithKey(property.MemberId);

      //ModelState modelState;

      //if (this.controller.ModelState.TryGetValue(string.Format("property{0}{1}", property.Id, "en"), out modelState) && modelState.Value != null)
      //  ;

      return new PropertyViewModel()
      {
        Id = property.Id,
        HtmlLocalizations = this.GetLocalizations(
          this.handler.Storage.GetRepository<IDictionaryRepository>().WithKey(property.HtmlId)
        )
      };
    }
  }
}