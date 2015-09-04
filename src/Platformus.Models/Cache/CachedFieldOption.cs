// Copyright © 2015 Dmitry Sikorsky. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

namespace Platformus.Models
{
  public class CachedFieldOption : IEntity
  {
    public int FieldOptionId { get; set; }
    public string Value { get; set; }
    public int? Position { get; set; }
  }
}