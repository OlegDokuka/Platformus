// Copyright © 2015 Dmitry Sikorsky. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System.Collections.Generic;
using Platformus.Models;

namespace Platformus.Data
{
  public interface ICredentialRepository : IRepository
  {
    Credential WithKey(int id);
    Credential WithCredentialTypeIdAndIdentifierAndSecret(int credentialTypeId, string identifier, string secret);
    IEnumerable<Credential> Range(int userId, string orderBy, string direction, int skip, int take);
    void Create(Credential credential);
    void Edit(Credential credential);
    void Delete(int id);
    void Delete(Credential credential);
    int CountByUserId(int userId);
  }
}