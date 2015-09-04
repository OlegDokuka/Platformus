// Copyright © 2015 Dmitry Sikorsky. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using Platformus.Data;
using Platformus.Models;

namespace Platformus.Areas.Backend.ViewModels.Menus
{
  public class CreateOrEditViewModelBuilder : ViewModelBuilderBase
  {
    public CreateOrEditViewModelBuilder(IHandler handler)
      : base(handler)
    {
    }

    public CreateOrEditViewModel Build(int? id)
    {
      if (id == null)
        return new CreateOrEditViewModel()
        {
          NameLocalizations = this.GetLocalizations()
        };

      Menu menu = this.handler.Storage.GetRepository<IMenuRepository>().WithKey((int)id);

      return new CreateOrEditViewModel()
      {
        Id = menu.Id,
        Code = menu.Code,
        NameLocalizations = this.GetLocalizations(this.handler.Storage.GetRepository<IDictionaryRepository>().WithKey(menu.NameId))
      };
    }
  }
}