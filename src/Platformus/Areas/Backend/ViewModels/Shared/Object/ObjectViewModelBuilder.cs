﻿// Copyright © 2015 Dmitry Sikorsky. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System.Collections.Generic;
using System.Linq;
using Platformus.Data;
using Platformus.Models;

namespace Platformus.Areas.Backend.ViewModels.Shared
{
  public class ObjectViewModelBuilder : ViewModelBuilderBase
  {
    public ObjectViewModelBuilder(IHandler handler)
      : base(handler)
    {
    }

    public ObjectViewModel Build(Object @object)
    {
      List<Class> relatedClasses = new List<Class>();

      foreach (Member member in this.handler.Storage.GetRepository<IMemberRepository>().FilteredByRelationClassIdRelationSingleParent(@object.ClassId))
      {
        Class @class = this.handler.Storage.GetRepository<IClassRepository>().WithKey((int)member.ClassId);

        relatedClasses.Add(@class);
      }

      return new ObjectViewModel()
      {
        Id = @object.Id,
        Url = @object.Url,
        Class = new ClassViewModelBuilder(this.handler).Build(
          this.handler.Storage.GetRepository<IClassRepository>().WithKey(@object.ClassId)
        ),
        Properties = new ObjectManager(this.handler).GetDisplayProperties(@object),
        RelatedClasses = relatedClasses.Select(
          c => new ClassViewModelBuilder(this.handler).Build(c)
        )
      };
    }
  }
}