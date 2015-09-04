﻿// Copyright © 2015 Dmitry Sikorsky. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using Platformus.Data;
using Platformus.Models;

namespace Platformus.Areas.Backend.ViewModels.Cultures
{
  public class CreateOrEditViewModelMapper : ViewModelBuilderBase
  {
    public CreateOrEditViewModelMapper(IHandler handler)
      : base(handler)
    {
    }

    public Culture Map(CreateOrEditViewModel createOrEdit)
    {
      Culture culture = new Culture();

      if (createOrEdit.Id != null)
        culture = this.handler.Storage.GetRepository<ICultureRepository>().WithKey((int)createOrEdit.Id);

      culture.Code = createOrEdit.Code;
      culture.Name = createOrEdit.Name;
      return culture;
    }
  }
}