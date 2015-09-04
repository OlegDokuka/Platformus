// Copyright © 2015 Dmitry Sikorsky. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System.Linq;
using Platformus.Areas.Backend.ViewModels.Shared;
using Platformus.Data;

namespace Platformus.Areas.Backend.ViewModels.Users
{
  public class IndexViewModelBuilder : ViewModelBuilderBase
  {
    public IndexViewModelBuilder(IHandler handler)
      : base(handler)
    {
    }

    public IndexViewModel Build(string orderBy, string direction, int skip, int take)
    {
      IUserRepository userRepository = this.handler.Storage.GetRepository<IUserRepository>();

      return new IndexViewModel()
      {
        Grid = new GridViewModelBuilder(this.handler).Build(
          orderBy, direction, skip, take, userRepository.Count(),
          new[] {
            new GridColumnViewModelBuilder(this.handler).Build("Name", "Name"),
            new GridColumnViewModelBuilder(this.handler).Build("Credentials"),
            new GridColumnViewModelBuilder(this.handler).Build("Created", "Created"),
            new GridColumnViewModelBuilder(this.handler).BuildEmpty()
          },
          userRepository.Range(orderBy, direction, skip, take).Select(u => new UserViewModelBuilder(this.handler).Build(u)),
          "_User"
        )
      };
    }
  }
}