// Copyright © 2015 Dmitry Sikorsky. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System.Collections.Generic;
using Platformus.Models;

namespace Platformus.Data
{
  public interface IFieldRepository : IRepository
  {
    Field WithKey(int id);
    IEnumerable<Field> FilteredByFormId(int formId);
    void Create(Field field);
    void Edit(Field field);
    void Delete(int id);
    void Delete(Field field);
  }
}