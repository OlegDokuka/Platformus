// Copyright © 2015 Dmitry Sikorsky. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

namespace Platformus.Areas.Backend.ViewModels.Shared
{
  public class OptionViewModelBuilder : ViewModelBuilderBase
  {
    public OptionViewModelBuilder(IHandler handler)
      : base(handler)
    {
    }

    public OptionViewModel Build(string text, string value = null)
    {
      return new OptionViewModel()
      {
        Text = text,
        Value = value == null ? text : value
      };
    }
  }
}