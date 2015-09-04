// Copyright © 2015 Dmitry Sikorsky. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System.Collections.Generic;
using Platformus.Areas.Backend.ViewModels.Shared;

namespace Platformus.Areas.Backend.ViewModels.Objects
{
  public class IndexViewModel : ViewModelBase
  {
    public ClassViewModel Class { get; set; }
    public IEnumerable<ClassViewModel> StandaloneClasses { get; set; }
    public IEnumerable<ClassViewModel> EmbeddedClasses { get; set; }
    public GridViewModel Grid { get; set; }
  }
}