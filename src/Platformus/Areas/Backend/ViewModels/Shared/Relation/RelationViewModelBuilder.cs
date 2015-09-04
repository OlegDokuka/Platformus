// Copyright © 2015 Dmitry Sikorsky. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using Platformus.Models;

namespace Platformus.Areas.Backend.ViewModels.Shared
{
  public class RelationViewModelBuilder : ViewModelBuilderBase
  {
    public RelationViewModelBuilder(IHandler handler)
      : base(handler)
    {
    }

    public RelationViewModel Build(Relation relation)
    {
      return new RelationViewModel()
      {
        Id = relation.Id,
        PrimaryId = relation.PrimaryId
      };
    }
  }
}