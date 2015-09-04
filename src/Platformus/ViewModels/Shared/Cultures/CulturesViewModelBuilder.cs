// Copyright © 2015 Dmitry Sikorsky. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System.Linq;
using Platformus.Data;

namespace Platformus.ViewModels.Shared
{
  public class CulturesViewModelBuilder : ViewModelBuilderBase
  {
    public CulturesViewModelBuilder(IHandler handler)
      : base(handler)
    {
    }

    public CulturesViewModel Build()
    {
      return new CulturesViewModel()
      {
        Cultures = this.handler.Storage.GetRepository<ICultureRepository>().All().Select(
          c => new CultureViewModelBuilder(this.handler).Build(c)
        )
      };
    }
  }
}