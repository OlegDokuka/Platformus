﻿// Copyright © 2015 Dmitry Sikorsky. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using Microsoft.AspNet.Mvc;
using Platformus.Data;

namespace Platformus.ViewComponents
{
  public abstract class ViewComponentBase : ViewComponent, IHandler
  {
    public IStorage Storage { get; private set; }

    public ViewComponentBase(IStorage storage)
    {
      this.Storage = storage;
    }
  }
}