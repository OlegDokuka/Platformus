﻿// Copyright © 2015 Dmitry Sikorsky. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System.Collections.Generic;

namespace Platformus.ViewModels.Shared
{
  public class FormViewModel : ViewModelBase
  {
    public int Id { get; set; }
    public string Name { get; set; }
    public IEnumerable<FieldViewModel> Fields { get; set; }
  }
}