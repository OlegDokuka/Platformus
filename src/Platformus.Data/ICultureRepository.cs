// Copyright © 2015 Dmitry Sikorsky. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System.Collections.Generic;
using Platformus.Models;

namespace Platformus.Data
{
  public interface ICultureRepository : IRepository
  {
    Culture WithKey(int id);
    Culture WithCode(string code);
    IEnumerable<Culture> All();
    IEnumerable<Culture> Range(string orderBy, string direction, int skip, int take);
    void Create(Culture culture);
    void Edit(Culture culture);
    void Delete(int id);
    void Delete(Culture culture);
    int Count();
  }
}