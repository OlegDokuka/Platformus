// Copyright © 2015 Dmitry Sikorsky. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using Platformus.Data;
using Platformus.Models;

namespace Platformus.Areas.Backend.ViewModels.Forms
{
  public class CreateOrEditViewModelMapper : ViewModelBuilderBase
  {
    public CreateOrEditViewModelMapper(IHandler handler)
      : base(handler)
    {
    }

    public Form Map(CreateOrEditViewModel createOrEdit)
    {
      Form form = new Form();

      if (createOrEdit.Id != null)
        form = this.handler.Storage.GetRepository<IFormRepository>().WithKey((int)createOrEdit.Id);

      form.Code = createOrEdit.Code;
      form.Email = createOrEdit.Email;
      return form;
    }
  }
}