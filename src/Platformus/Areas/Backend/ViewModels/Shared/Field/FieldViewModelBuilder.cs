﻿// Copyright © 2015 Dmitry Sikorsky. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System.Linq;
using Platformus.Data;
using Platformus.Models;

namespace Platformus.Areas.Backend.ViewModels.Shared
{
  public class FieldViewModelBuilder : ViewModelBuilderBase
  {
    public FieldViewModelBuilder(IHandler handler)
      : base(handler)
    {
    }

    public FieldViewModel Build(Field field)
    {
      return new FieldViewModel()
      {
        Id = field.Id,
        Name = this.handler.Storage.GetRepository<ILocalizationRepository>().FilteredByDictionaryId(field.NameId).First().Value,
        FieldOptions = this.handler.Storage.GetRepository<IFieldOptionRepository>().FilteredByFieldId(field.Id).Select(
          fo => new FieldOptionViewModelBuilder(this.handler).Build(fo)
        )
      };
    }
  }
}