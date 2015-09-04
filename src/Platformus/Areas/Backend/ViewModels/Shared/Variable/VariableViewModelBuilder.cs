// Copyright © 2015 Dmitry Sikorsky. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using Platformus.Models;

namespace Platformus.Areas.Backend.ViewModels.Shared
{
  public class VariableViewModelBuilder : ViewModelBuilderBase
  {
    public VariableViewModelBuilder(IHandler handler)
      : base(handler)
    {
    }

    public VariableViewModel Build(Variable variable)
    {
      return new VariableViewModel()
      {
        Id = variable.Id,
        Name = variable.Name,
        Value = variable.Value
      };
    }
  }
}