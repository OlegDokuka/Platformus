﻿// Copyright © 2015 Dmitry Sikorsky. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

namespace Platformus.ViewModels.Shared
{
  public class ClassViewModelBuilder : ViewModelBuilderBase
  {
    public ClassViewModelBuilder(IHandler handler)
      : base(handler)
    {
    }

    public ClassViewModel Build(int id, string viewName)
    {
      return new ClassViewModel()
      {
        Id = id,
        ViewName = viewName
      };
    }
  }
}