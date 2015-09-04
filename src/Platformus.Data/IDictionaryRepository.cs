﻿// Copyright © 2015 Dmitry Sikorsky. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using Platformus.Models;

namespace Platformus.Data
{
  public interface IDictionaryRepository : IRepository
  {
    Dictionary WithKey(int id);
    void Create(Dictionary dictionary);
    void Edit(Dictionary dictionary);
    void Delete(int id);
    void Delete(Dictionary dictionary);
  }
}