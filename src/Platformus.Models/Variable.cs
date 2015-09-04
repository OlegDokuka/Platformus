// Copyright © 2015 Dmitry Sikorsky. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

namespace Platformus.Models
{
  public class Variable : IEntity
  {
    //[Key]
    //[Required]
    public int Id { get; set; }

    //[Required]
    public int ConfigurationId { get; set; }

    //[Required]
    //[StringLength(32)]
    public string Code { get; set; }

    //[Required]
    //[StringLength(64)]
    public string Name { get; set; }

    //[Required]
    //[StringLength(1024)]
    public string Value { get; set; }
    public int? Position { get; set; }

    public virtual Configuration Configuration { get; set; }
  }
}