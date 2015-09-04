// Copyright © 2015 Dmitry Sikorsky. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using Microsoft.AspNet.Http;
using Platformus.Data;

namespace Platformus
{
  public interface IHandler
  {
    HttpContext Context { get; }
    IStorage Storage { get; }
  }
}