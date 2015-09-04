// Copyright © 2015 Dmitry Sikorsky. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System.Collections.Generic;

namespace Platformus.Models
{
  public class Object : IEntity
  {
    //[Key]
    //[Required]
    public int Id { get; set; }

    //[Required]
    public int ClassId { get; set; }

    //[StringLength(128)]
    public string Url { get; set; }

    public virtual Class Class { get; set; }
    public virtual ICollection<Property> Properties { get; set; }
  }
}