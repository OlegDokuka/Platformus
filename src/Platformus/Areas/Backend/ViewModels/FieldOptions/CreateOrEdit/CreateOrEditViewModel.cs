// Copyright © 2015 Dmitry Sikorsky. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Platformus.Areas.Backend.ViewModels.Shared;

namespace Platformus.Areas.Backend.ViewModels.FieldOptions
{
  public class CreateOrEditViewModel : ViewModelBase
  {
    public int? Id { get; set; }
    public int FieldId { get; set; }

    [Multilingual]
    [Display(Name = "Value")]
    [Required]
    [StringLength(64)]
    public string Value { get; set; }
    public IEnumerable<LocalizationViewModel> ValueLocalizations { get; set; }

    [Display(Name = "Position")]
    public int? Position { get; set; }
  }
}