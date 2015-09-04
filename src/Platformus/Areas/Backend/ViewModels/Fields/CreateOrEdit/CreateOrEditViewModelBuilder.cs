// Copyright © 2015 Dmitry Sikorsky. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System.Collections.Generic;
using System.Linq;
using Platformus.Areas.Backend.ViewModels.Shared;
using Platformus.Data;
using Platformus.Models;

namespace Platformus.Areas.Backend.ViewModels.Fields
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
          FieldTypeOptions = this.GetFieldTypeOptions(),
          NameLocalizations = this.GetLocalizations()
        };

      Field field = this.handler.Storage.GetRepository<IFieldRepository>().WithKey((int)id);

      return new CreateOrEditViewModel()
      {
        Id = field.Id,
        NameLocalizations = this.GetLocalizations(this.handler.Storage.GetRepository<IDictionaryRepository>().WithKey(field.NameId)),
        FieldTypeId = field.FieldTypeId,
        FieldTypeOptions = this.GetFieldTypeOptions(),
        Position = field.Position
      };
    }

    private IEnumerable<OptionViewModel> GetFieldTypeOptions()
    {
      return this.handler.Storage.GetRepository<IFieldTypeRepository>().All().Select(
        ft => new OptionViewModelBuilder(this.handler).Build(ft.Name, ft.Id.ToString())
      );
    }
  }
}