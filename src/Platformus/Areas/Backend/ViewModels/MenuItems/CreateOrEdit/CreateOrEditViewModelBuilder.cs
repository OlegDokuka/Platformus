// Copyright © 2015 Dmitry Sikorsky. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System.Collections.Generic;
using System.Linq;
using Platformus.Areas.Backend.ViewModels.Shared;
using Platformus.Data;
using Platformus.Models;

namespace Platformus.Areas.Backend.ViewModels.MenuItems
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
          NameLocalizations = this.GetLocalizations(),
          ObjectOptions = this.GetObjectOptions()
        };

      MenuItem menuItem = this.handler.Storage.GetRepository<IMenuItemRepository>().WithKey((int)id);

      return new CreateOrEditViewModel()
      {
        Id = menuItem.Id,
        NameLocalizations = this.GetLocalizations(this.handler.Storage.GetRepository<IDictionaryRepository>().WithKey(menuItem.NameId)),
        ObjectId = menuItem.ObjectId,
        ObjectOptions = this.GetObjectOptions(),
        Url = menuItem.Url,
        Position = menuItem.Position
      };
    }

    private IEnumerable<OptionViewModel> GetObjectOptions()
    {
      List<OptionViewModel> options = new List<OptionViewModel>();

      options.Add(new OptionViewModelBuilder(this.handler).Build("Object not specified", string.Empty));

      ObjectManager objectManager = new ObjectManager(this.handler);

      options.AddRange(
        this.handler.Storage.GetRepository<IObjectRepository>().Standalone().Select(
          o => new OptionViewModelBuilder(this.handler).Build(string.Join(" ", objectManager.GetDisplayProperties(o)), o.Id.ToString())
        )
      );

      return options;
    }
  }
}