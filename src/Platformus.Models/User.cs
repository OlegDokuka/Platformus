﻿// Copyright © 2015 Dmitry Sikorsky. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System.Collections.Generic;

namespace Platformus.Models
{
  public class User : IEntity
  {
    //[Key]
    //[Required]
    public int Id { get; set; }

    //[StringLength(64)]
    public string Name { get; set; }

    //[Required]
    public long Created { get; set; }

    public virtual ICollection<Credential> Credentials { get; set; }
  }
}