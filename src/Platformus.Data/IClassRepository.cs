// Copyright © 2015 Dmitry Sikorsky. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System.Collections.Generic;
using Platformus.Models;

namespace Platformus.Data
{
  public interface IClassRepository : IRepository
  {
    Class WithKey(int id);
    IEnumerable<Class> All();
    IEnumerable<Class> Range(string orderBy, string direction, int skip, int take);
    IEnumerable<Class> StandaloneNotRelationSingleParent();
    IEnumerable<Class> EmbeddedNotRelationSingleParent();
    void Create(Class @class);
    void Edit(Class @class);
    void Delete(int id);
    void Delete(Class @class);
    int Count();
  }
}