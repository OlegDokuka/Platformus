﻿// Copyright © 2015 Dmitry Sikorsky. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Platformus.Areas.Backend.ViewModels.Shared;

namespace Platformus.Areas.Backend.ViewModels.Objects
{
  public class CreateOrEditViewModel : ViewModelBase
  {
    public int? Id { get; set; }
    public int? ClassId { get; set; }

    [Display(Name = "URL")]
    [Required]
    [StringLength(128)]
    public string _Url { get; set; }

    public ClassViewModel Class { get; set; }
    public IDictionary<TabViewModel, IEnumerable<MemberViewModel>> MembersByTabs { get; set; }
  }
}