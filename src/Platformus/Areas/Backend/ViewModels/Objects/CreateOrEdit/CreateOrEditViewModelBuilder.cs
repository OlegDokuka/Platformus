﻿// Copyright © 2015 Dmitry Sikorsky. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System.Collections.Generic;
using System.Linq;
using Platformus.Areas.Backend.ViewModels.Shared;
using Platformus.Data;
using Platformus.Models;

namespace Platformus.Areas.Backend.ViewModels.Objects
{
  public class CreateOrEditViewModelBuilder : ViewModelBuilderBase
  {
    public CreateOrEditViewModelBuilder(IHandler handler)
      : base(handler)
    {
    }

    public CreateOrEditViewModel Build(int? id, int? classId, int? objectId)
    {
      if (id == null)
        return new CreateOrEditViewModel()
        {
          _Url = "/",
          Class = new ClassViewModelBuilder(this.handler).Build(
            this.handler.Storage.GetRepository<IClassRepository>().WithKey((int)classId)
          ),
          MembersByTabs = this.GetMembersByTabs(null, classId, objectId)
        };

      Object @object = this.handler.Storage.GetRepository<IObjectRepository>().WithKey((int)id);

      return new CreateOrEditViewModel()
      {
        Id = @object.Id,
        _Url = @object.Url,
        Class = new ClassViewModelBuilder(this.handler).Build(
          this.handler.Storage.GetRepository<IClassRepository>().WithKey(@object.ClassId)
        ),
        MembersByTabs = this.GetMembersByTabs(@object)
      };
    }

    private IDictionary<TabViewModel, IEnumerable<MemberViewModel>> GetMembersByTabs(Object @object, int? classId = null, int? objectId = null)
    {
      Dictionary<TabViewModel, IEnumerable<MemberViewModel>> membersByTabs = new Dictionary<TabViewModel, IEnumerable<MemberViewModel>>();

      membersByTabs.Add(new TabViewModel() { Name = "General" }, new List<MemberViewModel>());

      foreach (Tab tab in this.handler.Storage.GetRepository<ITabRepository>().FilteredByClassId(@object != null ? @object.ClassId : (int)classId))
        membersByTabs.Add(new TabViewModelBuilder(this.handler).Build(tab), new List<MemberViewModel>());

      foreach (Member member in this.handler.Storage.GetRepository<IMemberRepository>().FilteredByClassId(@object != null ? @object.ClassId : (int)classId))
      {
        TabViewModel tab = null;

        if (member.TabId == null)
          tab = membersByTabs.Keys.FirstOrDefault(t => t.Id == 0);

        else tab = membersByTabs.Keys.FirstOrDefault(t => t.Id == (int)member.TabId);

        (membersByTabs[tab] as List<MemberViewModel>).Add(new MemberViewModelBuilder(this.handler).Build(member, @object, objectId));
      }

      return membersByTabs;
    }
  }
}