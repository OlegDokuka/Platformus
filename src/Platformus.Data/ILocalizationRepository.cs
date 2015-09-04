﻿// Copyright © 2015 Dmitry Sikorsky. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System.Collections.Generic;
using Platformus.Models;

namespace Platformus.Data
{
  public interface ILocalizationRepository : IRepository
  {
    Localization WithKey(int id);
    Localization WithDictionaryIdAndCultureId(int dictionaryId, int cultureId);
    IEnumerable<Localization> FilteredByDictionaryId(int dictionaryId);
    void Create(Localization localization);
    void Edit(Localization localization);
    void Delete(int id);
    void Delete(Localization localization);
  }
}