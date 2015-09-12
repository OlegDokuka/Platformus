// Copyright © 2015 Dmitry Sikorsky. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using Microsoft.AspNet.Authentication.Cookies;
using Microsoft.AspNet.Builder;
using Microsoft.AspNet.Hosting;
using Microsoft.AspNet.Http;
using Microsoft.AspNet.Localization;
using Microsoft.Dnx.Runtime;
using Microsoft.Framework.Configuration;
using Microsoft.Framework.DependencyInjection;
using Platformus.Data;
using Platformus.Data.EntityFramework.Sqlite;
//using Platformus.Data.EntityFramework.SqlServer;

namespace Platformus
{
  public class Startup
  {
    IConfigurationRoot startupConfiguration;

    public Startup(IHostingEnvironment hostingEnvironment, IApplicationEnvironment applicationEnvironment)
    {
      this.startupConfiguration = new ConfigurationBuilder(applicationEnvironment.ApplicationBasePath)
        .AddJsonFile("config.json")
        .Build();
    }

    public void ConfigureServices(IServiceCollection services)
    {
      services.AddCaching();
      services.AddSession();
      services.AddMvc();
      services.AddScoped(typeof(IConfiguration), typeof(Configuration));
      Storage.ConnectionString = this.startupConfiguration["Data:DefaultConnection:ConnectionString"];
      services.AddScoped(typeof(IStorage), typeof(Storage));
    }

    public void Configure(IApplicationBuilder applicationBuilder, IHostingEnvironment hostingEnvironment)
    {
      applicationBuilder.UseSession();

      if (hostingEnvironment.IsEnvironment("Development"))
      {
        applicationBuilder.UseStatusCodePages();
        applicationBuilder.UseErrorPage();
        applicationBuilder.UseBrowserLink();
      }

      else
      {
        applicationBuilder.UseStatusCodePages();
        applicationBuilder.UseErrorHandler("/Default/Error");
      }

      applicationBuilder.UseStaticFiles();
      applicationBuilder.UseCookieAuthentication(options => {
        options.AuthenticationScheme = CookieAuthenticationDefaults.AuthenticationScheme;
        options.AutomaticAuthentication = true;
        options.CookieName = "PLATFORMUS";
        options.ExpireTimeSpan = new System.TimeSpan(1, 0, 0);
        options.LoginPath = new PathString("/Backend/Account/SignIn");
      });

      RequestLocalizationOptions requestLocalizationOptions = new RequestLocalizationOptions();

      requestLocalizationOptions.RequestCultureProviders.Insert(0, new RouteValueRequestCultureProvider());
      applicationBuilder.UseRequestLocalization(requestLocalizationOptions);

      applicationBuilder.UseMvc(routes =>
        {
          // Backend
          routes.MapRoute(name: "Backend Create", template: "{area:exists}/{controller=Default}/create", defaults: new { action = "CreateOrEdit" });
          routes.MapRoute(name: "Backend Edit", template: "{area:exists}/{controller=Default}/edit/{id}", defaults: new { action = "CreateOrEdit" });
          routes.MapRoute(name: "Backend Default", template: "{area:exists}/{controller=Default}/{action=Index}/{id?}");

          // Frontend
          //routes.MapRoute(name: "Standard", template: "{controller=Default}/{action=Index}/{id?}", defaults: new { }, constraints: new { controller = " " });
          routes.MapRoute(name: "Default", template: "{culture=en}/{*url}", defaults: new { controller = "Default", action = "Index" });
        }
      );
    }
  }
}