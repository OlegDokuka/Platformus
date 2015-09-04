﻿// Copyright © 2015 Dmitry Sikorsky. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using Platformus.Data;
using Platformus.Models;

namespace Platformus.Areas.Backend.ViewModels.FieldOptions
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
          ValueLocalizations = this.GetLocalizations()
        };

      FieldOption fieldOption = this.handler.Storage.GetRepository<IFieldOptionRepository>().WithKey((int)id);

      return new CreateOrEditViewModel()
      {
        Id = fieldOption.Id,
        ValueLocalizations = this.GetLocalizations(this.handler.Storage.GetRepository<IDictionaryRepository>().WithKey(fieldOption.ValueId)),
        Position = fieldOption.Position
      };
    }
  }
}