﻿// Copyright © 2015 Dmitry Sikorsky. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System.Collections.Generic;
using System.Linq;
using Platformus.Models;

namespace Platformus.Data.EntityFramework.SqlServer
{
  public class CredentialTypeRepository : RepositoryBase<CredentialType>, ICredentialTypeRepository
  {
    public CredentialType WithKey(int id)
    {
      return this.dbSet.FirstOrDefault(ct => ct.Id == id);
    }

    public CredentialType WithCode(string code)
    {
      return this.dbSet.FirstOrDefault(ct => string.Equals(ct.Code, code, System.StringComparison.OrdinalIgnoreCase));
    }

    public IEnumerable<CredentialType> All()
    {
      return this.dbSet.OrderBy(ct => ct.Position);
    }
  }
}