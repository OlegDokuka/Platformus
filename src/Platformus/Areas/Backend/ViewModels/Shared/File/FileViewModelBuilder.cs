﻿// Copyright © 2015 Dmitry Sikorsky. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using Platformus.Models;

namespace Platformus.Areas.Backend.ViewModels.Shared
{
  public class FileViewModelBuilder : ViewModelBuilderBase
  {
    public FileViewModelBuilder(IHandler handler)
      : base(handler)
    {
    }

    public FileViewModel Build(File file)
    {
      return new FileViewModel()
      {
        Id = file.Id,
        Name = file.Name,
        Size = file.Size
      };
    }
  }
}