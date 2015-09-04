﻿// Copyright © 2015 Dmitry Sikorsky. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System.Linq;
using Platformus.Areas.Backend.ViewModels.Shared;
using Platformus.Data;

namespace Platformus.Areas.Backend.ViewModels.Members
{
  public class IndexViewModelBuilder : ViewModelBuilderBase
  {
    public IndexViewModelBuilder(IHandler handler)
      : base(handler)
    {
    }

    public IndexViewModel Build(int classId, string orderBy, string direction, int skip, int take)
    {
      IMemberRepository memberRepository = this.handler.Storage.GetRepository<IMemberRepository>();

      return new IndexViewModel()
      {
        ClassId = classId,
        Grid = new GridViewModelBuilder(this.handler).Build(
          orderBy, direction, skip, take, memberRepository.CountByClassId(classId),
          new[] {
            new GridColumnViewModelBuilder(this.handler).Build("Relation Class"),
            new GridColumnViewModelBuilder(this.handler).Build("Property Data Type"),
            new GridColumnViewModelBuilder(this.handler).Build("Name", "Name"),
            new GridColumnViewModelBuilder(this.handler).Build("Position", "Position"),
            new GridColumnViewModelBuilder(this.handler).BuildEmpty()
          },
          memberRepository.Range(classId, orderBy, direction, skip, take).Select(m => new MemberViewModelBuilder(this.handler).Build(m, null)),
          "_Member"
        )
      };
    }
  }
}