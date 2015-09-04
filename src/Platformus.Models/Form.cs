﻿// Copyright © 2015 Dmitry Sikorsky. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System.Collections.Generic;

namespace Platformus.Models
{
  public class Form : IEntity
  {
    //[Key]
    //[Required]
    public int Id { get; set; }

    //[Required]
    //[StringLength(32)]
    public string Code { get; set; }

    //[Required]
    public int NameId { get; set; }

    //[Required]
    //[StringLength(64)]
    public string Email { get; set; }

    public virtual Dictionary Name { get; set; }
    public virtual ICollection<Field> Fields { get; set; }
  }
}