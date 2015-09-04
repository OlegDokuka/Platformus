// Copyright © 2015 Dmitry Sikorsky. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System.Linq;
using Platformus.Areas.Backend.ViewModels.Shared;
using Platformus.Data;

namespace Platformus.Areas.Backend.ViewModels.Configurations
{
  public class IndexViewModelBuilder : ViewModelBuilderBase
  {
    public IndexViewModelBuilder(IHandler handler)
      : base(handler)
    {
    }

    public IndexViewModel Build()
    {
      return new IndexViewModel()
      {
        Configurations = this.handler.Storage.GetRepository<IConfigurationRepository>().All().Select(
          c => new ConfigurationViewModelBuilder(this.handler).Build(c)
        )
      };
    }
  }
}