﻿// Copyright © 2015 Dmitry Sikorsky. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System.Linq;
using Platformus.Data;
using Platformus.Models;

namespace Platformus.Areas.Backend.ViewModels.Shared
{
  public class FormViewModelBuilder : ViewModelBuilderBase
  {
    public FormViewModelBuilder(IHandler handler)
      : base(handler)
    {
    }

    public FormViewModel Build(Form form)
    {
      return new FormViewModel()
      {
        Id = form.Id,
        Name = this.handler.Storage.GetRepository<ILocalizationRepository>().FilteredByDictionaryId(form.NameId).First().Value,
        Fields = this.handler.Storage.GetRepository<IFieldRepository>().FilteredByFormId(form.Id).Select(
          f => new FieldViewModelBuilder(this.handler).Build(f)
        )
      };
    }
  }
}