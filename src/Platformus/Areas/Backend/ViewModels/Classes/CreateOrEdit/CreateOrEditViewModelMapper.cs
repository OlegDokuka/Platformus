// Copyright © 2015 Dmitry Sikorsky. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using Platformus.Data;
using Platformus.Models;

namespace Platformus.Areas.Backend.ViewModels.Classes
{
  public class CreateOrEditViewModelMapper : ViewModelBuilderBase
  {
    public CreateOrEditViewModelMapper(IHandler handler)
      : base(handler)
    {
    }

    public Class Map(CreateOrEditViewModel createOrEdit)
    {
      Class @class = new Class();

      if (createOrEdit.Id != null)
        @class = this.handler.Storage.GetRepository<IClassRepository>().WithKey((int)createOrEdit.Id);

      @class.Name = createOrEdit.Name;
      @class.PluralizedName = createOrEdit.PluralizedName;
      @class.IsStandalone = createOrEdit.IsStandalone ? true : (bool?)null;
      @class.ViewName = createOrEdit.ViewName;
      return @class;
    }
  }
}