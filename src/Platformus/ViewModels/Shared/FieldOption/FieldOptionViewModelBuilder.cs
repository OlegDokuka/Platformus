// Copyright © 2015 Dmitry Sikorsky. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using Platformus.Models;

namespace Platformus.ViewModels.Shared
{
  public class FieldOptionViewModelBuilder : ViewModelBuilderBase
  {
    public FieldOptionViewModelBuilder(IHandler handler)
      : base(handler)
    {
    }

    public FieldOptionViewModel Build(FieldOption fieldOption)
    {
      return new FieldOptionViewModel()
      {
        Value = this.GetObjectLocalizationValue(fieldOption.ValueId)
      };
    }

    public FieldOptionViewModel Build(CachedFieldOption cachedFieldOption)
    {
      return new FieldOptionViewModel()
      {
        Value = cachedFieldOption.Value
      };
    }
  }
}