// Copyright © 2015 Dmitry Sikorsky. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using Microsoft.Dnx.Runtime;
using Microsoft.Framework.Configuration;
using Platformus.Data;

namespace Platformus
{
  public class Configuration : IConfiguration
  {
    private Microsoft.Framework.Configuration.IConfiguration configuration;

    public Configuration(IApplicationEnvironment applicationEnvironment, IStorage storage)
    {
      ConfigurationBuilder configurationBuilder = new ConfigurationBuilder(applicationEnvironment.ApplicationBasePath);

      configurationBuilder.AddJsonFile("config.json");
      configurationBuilder.AddEnvironmentVariables();
      configurationBuilder.AddStorage(storage);
      this.configuration = configurationBuilder.Build();
    }

    public string Get(string key)
    {
      return this.configuration[key];
    }
  }
}