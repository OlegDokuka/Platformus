﻿// Copyright © 2015 Dmitry Sikorsky. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System.Collections.Generic;
using Platformus.Models;

namespace Platformus.Data
{
  public interface IRoleRepository : IRepository
  {
    Role WithKey(int id);
    IEnumerable<Role> All();
    IEnumerable<Role> Range(string orderBy, string direction, int skip, int take);
    void Create(Role role);
    void Edit(Role role);
    void Delete(int id);
    void Delete(Role role);
    int Count();
  }
}