// Copyright © 2015 Dmitry Sikorsky. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System.Collections.Generic;
using Platformus.Models;

namespace Platformus.Data
{
  public interface ICredentialTypeRepository : IRepository
  {
    CredentialType WithKey(int id);
    CredentialType WithCode(string code);
    IEnumerable<CredentialType> All();
  }
}