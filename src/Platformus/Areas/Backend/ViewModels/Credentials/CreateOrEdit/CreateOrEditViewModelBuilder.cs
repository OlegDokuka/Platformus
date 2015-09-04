// Copyright © 2015 Dmitry Sikorsky. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System.Collections.Generic;
using System.Linq;
using Platformus.Areas.Backend.ViewModels.Shared;
using Platformus.Data;
using Platformus.Models;

namespace Platformus.Areas.Backend.ViewModels.Credentials
{
  public class CreateOrEditViewModelBuilder : ViewModelBuilderBase
  {
    public CreateOrEditViewModelBuilder(IHandler handler)
      : base(handler)
    {
    }

    public CreateOrEditViewModel Build(int? id)
    {
      if (id == null)
        return new CreateOrEditViewModel()
        {
          CredentialTypeOptions = this.GetCredentialTypeOptions()
        };

      Credential credential = this.handler.Storage.GetRepository<ICredentialRepository>().WithKey((int)id);

      return new CreateOrEditViewModel()
      {
        Id = credential.Id,
        CredentialTypeId = credential.CredentialTypeId,
        CredentialTypeOptions = this.GetCredentialTypeOptions(),
        Identifier = credential.Identifier
      };
    }

    private IEnumerable<OptionViewModel> GetCredentialTypeOptions()
    {
      return this.handler.Storage.GetRepository<ICredentialTypeRepository>().All().Select(
        ct => new OptionViewModelBuilder(this.handler).Build(ct.Name, ct.Id.ToString())
      );
    }
  }
}