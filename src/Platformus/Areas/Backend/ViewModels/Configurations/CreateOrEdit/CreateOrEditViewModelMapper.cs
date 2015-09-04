// Copyright © 2015 Dmitry Sikorsky. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using Platformus.Data;

namespace Platformus.Areas.Backend.ViewModels.Configurations
{
  public class CreateOrEditViewModelMapper : ViewModelBuilderBase
  {
    public CreateOrEditViewModelMapper(IHandler handler)
      : base(handler)
    {
    }

    public Platformus.Models.Configuration Map(CreateOrEditViewModel createOrEdit)
    {
      Platformus.Models.Configuration configuration = new Platformus.Models.Configuration();

      if (createOrEdit.Id != null)
        configuration = this.handler.Storage.GetRepository<IConfigurationRepository>().WithKey((int)createOrEdit.Id);

      configuration.Code = createOrEdit.Code;
      configuration.Name = createOrEdit.Name;
      return configuration;
    }
  }
}