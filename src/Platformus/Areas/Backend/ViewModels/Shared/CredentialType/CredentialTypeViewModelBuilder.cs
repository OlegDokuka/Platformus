// Copyright © 2015 Dmitry Sikorsky. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using Platformus.Models;

namespace Platformus.Areas.Backend.ViewModels.Shared
{
  public class CredentialTypeViewModelBuilder : ViewModelBuilderBase
  {
    public CredentialTypeViewModelBuilder(IHandler handler)
      : base(handler)
    {
    }

    public CredentialTypeViewModel Build(CredentialType credentialType)
    {
      return new CredentialTypeViewModel()
      {
        Id = credentialType.Id,
        Name = credentialType.Name,
        Position = credentialType.Position
      };
    }
  }
}