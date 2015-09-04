// Copyright © 2015 Dmitry Sikorsky. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System.Collections.Generic;
using System.Linq;
using Platformus.Areas.Backend.ViewModels.Shared;
using Platformus.Data;
using Platformus.Models;

namespace Platformus.Areas.Backend.ViewModels.Members
{
  public class CreateOrEditViewModelBuilder : ViewModelBuilderBase
  {
    public CreateOrEditViewModelBuilder(IHandler handler)
      : base(handler)
    {
    }

    public CreateOrEditViewModel Build(int? id, int? classId)
    {
      if (id == null)
        return new CreateOrEditViewModel()
        {
          TabOptions = this.GetTabOptions((int)classId),
          RelationClassOptions = this.GetRelationClassOptions(),
          PropertyDataTypeOptions = this.GetPropertyDataTypeOptions()
        };

      Member member = this.handler.Storage.GetRepository<IMemberRepository>().WithKey((int)id);

      return new CreateOrEditViewModel()
      {
        Id = member.Id,
        TabId = member.TabId,
        TabOptions = this.GetTabOptions(member.ClassId),
        Code = member.Code,
        Name = member.Name,
        DisplayInList = member.DisplayInList == true,
        Position = member.Position,
        RelationClassId = member.RelationClassId,
        RelationClassOptions = this.GetRelationClassOptions(),
        IsRelationSingleParent = member.IsRelationSingleParent == true,
        PropertyDataTypeId = member.PropertyDataTypeId,
        PropertyDataTypeOptions = this.GetPropertyDataTypeOptions()
      };
    }

    private IEnumerable<OptionViewModel> GetTabOptions(int classId)
    {
      List<OptionViewModel> options = new List<OptionViewModel>();

      options.Add(new OptionViewModelBuilder(this.handler).Build("Tab not specified", string.Empty));
      options.AddRange(
        this.handler.Storage.GetRepository<ITabRepository>().FilteredByClassId(classId).Select(
          t => new OptionViewModelBuilder(this.handler).Build(t.Name, t.Id.ToString())
        )
      );

      return options;
    }

    private IEnumerable<OptionViewModel> GetRelationClassOptions()
    {
      List<OptionViewModel> options = new List<OptionViewModel>();

      options.Add(new OptionViewModelBuilder(this.handler).Build("Relation class not specified", string.Empty));
      options.AddRange(
        this.handler.Storage.GetRepository<IClassRepository>().All().Select(
          c => new OptionViewModelBuilder(this.handler).Build(c.Name, c.Id.ToString())
        )
      );

      return options;
    }

    private IEnumerable<OptionViewModel> GetPropertyDataTypeOptions()
    {
      List<OptionViewModel> options = new List<OptionViewModel>();

      options.Add(new OptionViewModelBuilder(this.handler).Build("Property data type not specified", string.Empty));
      options.AddRange(
        this.handler.Storage.GetRepository<IDataTypeRepository>().All().Select(
          dt => new OptionViewModelBuilder(this.handler).Build(dt.Name, dt.Id.ToString())
        )
      );

      return options;
    }
  }
}