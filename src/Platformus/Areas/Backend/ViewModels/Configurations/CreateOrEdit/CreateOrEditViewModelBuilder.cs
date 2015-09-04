// Copyright © 2015 Dmitry Sikorsky. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using Platformus.Data;

namespace Platformus.Areas.Backend.ViewModels.Configurations
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
        };

      Platformus.Models.Configuration configuration = this.handler.Storage.GetRepository<IConfigurationRepository>().WithKey((int)id);

      return new CreateOrEditViewModel()
      {
        Id = configuration.Id,
        Code = configuration.Code,
        Name = configuration.Name
      };
    }
  }
}