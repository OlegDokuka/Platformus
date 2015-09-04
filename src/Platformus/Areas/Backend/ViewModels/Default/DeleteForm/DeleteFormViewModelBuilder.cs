// Copyright © 2015 Dmitry Sikorsky. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

namespace Platformus.Areas.Backend.ViewModels.Default
{
  public class DeleteFormViewModelBuilder : ViewModelBuilderBase
  {
    public DeleteFormViewModelBuilder(IHandler handler)
      : base(handler)
    {
    }

    public DeleteFormViewModel Build(string targetUrl)
    {
      return new DeleteFormViewModel()
      {
        TargetUrl = targetUrl
      };
    }
  }
}