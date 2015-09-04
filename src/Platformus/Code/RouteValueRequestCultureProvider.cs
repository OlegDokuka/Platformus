// Copyright © 2015 Dmitry Sikorsky. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System.Globalization;
using System.Threading.Tasks;
using Microsoft.AspNet.Http;
using Microsoft.AspNet.Localization;
using Microsoft.Framework.Globalization;

namespace Platformus
{
  public class RouteValueRequestCultureProvider : RequestCultureProvider
  {
    public override Task<RequestCulture> DetermineRequestCulture(HttpContext httpContext)
    {
      string cultureCode = null;

      if (httpContext.Request.Path.HasValue && httpContext.Request.Path.Value.Length >= 4 && httpContext.Request.Path.Value[0] == '/' && httpContext.Request.Path.Value[3] == '/')
        cultureCode = httpContext.Request.Path.Value.Substring(1, 2);

      else cultureCode = "en";

      CultureInfo culture = CultureInfoCache.GetCultureInfo(cultureCode);
      CultureInfo uiCulture = CultureInfoCache.GetCultureInfo(cultureCode);

      RequestCulture requestCulture = new RequestCulture(culture, uiCulture);

      requestCulture = this.ValidateRequestCulture(requestCulture);

      return Task.FromResult(requestCulture);
    }
  }
}