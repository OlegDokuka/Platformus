// Copyright © 2015 Dmitry Sikorsky. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System.Collections.Generic;
using System.Linq;
using Platformus.Areas.Backend.ViewModels.Shared;
using Platformus.Data;
using Platformus.Models;

namespace Platformus.Areas.Backend.ViewModels
{
  public abstract class ViewModelBuilderBase : Platformus.ViewModels.ViewModelBuilderBase
  {
    public ViewModelBuilderBase(IHandler handler)
      : base(handler)
    {
      this.handler = handler;
    }

    protected IEnumerable<LocalizationViewModel> GetLocalizations(Dictionary dictionary = null)
    {
      List<LocalizationViewModel> localizations = new List<LocalizationViewModel>();

      foreach (Culture culture in this.handler.Storage.GetRepository<ICultureRepository>().All())
      {
        Localization localization = null;

        if (dictionary != null)
          localization = this.handler.Storage.GetRepository<ILocalizationRepository>().FilteredByDictionaryId(dictionary.Id).FirstOrDefault(l => l.CultureId == culture.Id);

        if (localization == null)
        {
          localization = new Localization();
          localization.Culture = culture;
        }

        localizations.Add(new LocalizationViewModelBuilder(this.handler).Build(localization));
      }

      return localizations;
    }
  }
}