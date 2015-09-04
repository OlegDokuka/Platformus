// Copyright © 2015 Dmitry Sikorsky. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

namespace Platformus.Areas.Backend.ViewModels.Shared
{
  public class TakeSelectorViewModelBuilder : ViewModelBuilderBase
  {
    public TakeSelectorViewModelBuilder(IHandler handler)
      : base(handler)
    {
    }

    public TakeSelectorViewModel Build(int take)
    {
      return new TakeSelectorViewModel()
      {
        TakeOptions = new OptionViewModel[] {
          new OptionViewModelBuilder(this.handler).Build("По 10", "10"),
          new OptionViewModelBuilder(this.handler).Build("По 25", "25"),
          new OptionViewModelBuilder(this.handler).Build("По 50", "50"),
          new OptionViewModelBuilder(this.handler).Build("По 100", "100")
        }
      };
    }
  }
}