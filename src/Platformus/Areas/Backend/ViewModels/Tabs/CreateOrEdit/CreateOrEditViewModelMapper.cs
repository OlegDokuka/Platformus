// Copyright © 2015 Dmitry Sikorsky. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using Platformus.Data;
using Platformus.Models;

namespace Platformus.Areas.Backend.ViewModels.Tabs
{
  public class CreateOrEditViewModelMapper : ViewModelBuilderBase
  {
    public CreateOrEditViewModelMapper(IHandler handler)
      : base(handler)
    {
    }

    public Tab Map(CreateOrEditViewModel createOrEdit)
    {
      Tab tab = new Tab();

      if (createOrEdit.Id != null)
        tab = this.handler.Storage.GetRepository<ITabRepository>().WithKey((int)createOrEdit.Id);

      else tab.ClassId = createOrEdit.ClassId;

      tab.Name = createOrEdit.Name;
      tab.Position = createOrEdit.Position;
      return tab;
    }
  }
}