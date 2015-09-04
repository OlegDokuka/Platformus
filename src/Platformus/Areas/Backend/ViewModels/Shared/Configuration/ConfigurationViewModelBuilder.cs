// Copyright © 2015 Dmitry Sikorsky. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System.Linq;
using Platformus.Data;

namespace Platformus.Areas.Backend.ViewModels.Shared
{
  public class ConfigurationViewModelBuilder : ViewModelBuilderBase
  {
    public ConfigurationViewModelBuilder(IHandler handler)
      : base(handler)
    {
    }

    public ConfigurationViewModel Build(Platformus.Models.Configuration configuration)
    {
      return new ConfigurationViewModel()
      {
        Id = configuration.Id,
        Name = configuration.Name,
        Variables = this.handler.Storage.GetRepository<IVariableRepository>().FilteredByConfigurationId(configuration.Id).Select(
          v => new VariableViewModelBuilder(this.handler).Build(v)
        )
      };
    }
  }
}