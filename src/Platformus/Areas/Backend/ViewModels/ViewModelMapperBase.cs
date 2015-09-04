// Copyright © 2015 Dmitry Sikorsky. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

namespace Platformus.Areas.Backend.ViewModels
{
  public abstract class ViewModelMapperBase : Platformus.ViewModels.ViewModelMapperBase
  {
    public ViewModelMapperBase(IHandler handler)
      : base(handler)
    {
      this.handler = handler;
    }
  }
}