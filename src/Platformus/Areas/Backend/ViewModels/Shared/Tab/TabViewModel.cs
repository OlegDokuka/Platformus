﻿// Copyright © 2015 Dmitry Sikorsky. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

namespace Platformus.Areas.Backend.ViewModels.Shared
{
  public class TabViewModel : ViewModelBase
  {
    public int Id { get; set; }
    public string Name { get; set; }
    public int? Position { get; set; }
  }
}