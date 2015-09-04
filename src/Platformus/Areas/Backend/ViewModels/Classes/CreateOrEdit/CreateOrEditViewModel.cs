﻿// Copyright © 2015 Dmitry Sikorsky. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System.ComponentModel.DataAnnotations;

namespace Platformus.Areas.Backend.ViewModels.Classes
{
  public class CreateOrEditViewModel : ViewModelBase
  {
    public int? Id { get; set; }

    [Display(Name = "Name")]
    [Required]
    [StringLength(64)]
    public string Name { get; set; }

    [Display(Name = "Pluralized name")]
    [Required]
    [StringLength(64)]
    public string PluralizedName { get; set; }

    [Display(Name = "Is standalone")]
    public bool IsStandalone { get; set; }

    [Display(Name = "View name")]
    [StringLength(32)]
    public string ViewName { get; set; }
  }
}