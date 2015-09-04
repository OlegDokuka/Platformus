// Copyright © 2015 Dmitry Sikorsky. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using Microsoft.Framework.Configuration;
using Platformus.Data;
using Platformus.Models;

namespace Platformus
{
  public class StorageConfigurationSource : ConfigurationSource
  {
    private IStorage storage;

    public StorageConfigurationSource(IStorage storage)
    {
      this.storage = storage;
    }

    public override bool TryGet(string key, out string value)
    {
      try
      {
        string[] codes = key.Split(':');
        string configurationCode = codes[0];
        Platformus.Models.Configuration configuration = storage.GetRepository<IConfigurationRepository>().WithCode(configurationCode);
        string variableCode = codes[1];
        Variable variable = storage.GetRepository<IVariableRepository>().WithConfigurationIdAndCode(configuration.Id, variableCode);

        value = variable.Value;
        return true;
      }

      catch
      {
        value = null;
        return false;
      }
    }
  }

  public static class ConfigurationExtensions
  {
    public static IConfigurationBuilder AddStorage(this IConfigurationBuilder configuration, IStorage storage)
    {
      configuration.Add(new StorageConfigurationSource(storage));
      return configuration;
    }
  }
}