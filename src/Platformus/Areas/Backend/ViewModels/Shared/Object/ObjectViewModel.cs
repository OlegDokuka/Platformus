﻿// Copyright © 2015 Dmitry Sikorsky. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System.Collections.Generic;

namespace Platformus.Areas.Backend.ViewModels.Shared
{
  public class ObjectViewModel : ViewModelBase
  {
    public int Id { get; set; }
    public string Url { get; set; }
    public ClassViewModel Class { get; set; }
    public IEnumerable<string> Properties { get; set; }
    public IEnumerable<ClassViewModel> RelatedClasses { get; set; }
  }
}