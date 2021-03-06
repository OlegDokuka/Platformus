﻿// Copyright © 2015 Dmitry Sikorsky. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System.Collections.Generic;
using Platformus.Models;

namespace Platformus.Data
{
  public interface IMenuRepository : IRepository
  {
    Menu WithKey(int id);
    Menu WithCode(string code);
    IEnumerable<Menu> All();
    void Create(Menu menu);
    void Edit(Menu menu);
    void Delete(int id);
    void Delete(Menu menu);
  }
}