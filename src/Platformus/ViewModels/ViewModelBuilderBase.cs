// Copyright © 2015 Dmitry Sikorsky. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using Platformus.Data;
using Platformus.Models;

namespace Platformus.ViewModels
{
  public abstract class ViewModelBuilderBase
  {
    protected IHandler handler;

    public ViewModelBuilderBase(IHandler handler)
    {
      this.handler = handler;
    }

    public string GetObjectLocalizationValue(int dictionaryId)
    {
      Localization localization = this.handler.Storage.GetRepository<ILocalizationRepository>().WithDictionaryIdAndCultureId(
        dictionaryId, CultureProvider.GetCulture(this.handler.Storage).Id
      );

      if (localization == null)
        return string.Empty;

      return localization.Value;
    }
  }
}