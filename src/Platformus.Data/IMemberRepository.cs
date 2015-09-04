﻿// Copyright © 2015 Dmitry Sikorsky. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System.Collections.Generic;
using Platformus.Models;

namespace Platformus.Data
{
  public interface IMemberRepository : IRepository
  {
    Member WithKey(int id);
    IEnumerable<Member> FilteredByClassId(int classId);
    IEnumerable<Member> FilteredByClassIdDisplayInList(int classId);
    IEnumerable<Member> FilteredByRelationClassIdRelationSingleParent(int relationClassId);
    IEnumerable<Member> Range(int classId, string orderBy, string direction, int skip, int take);
    void Create(Member member);
    void Edit(Member member);
    void Delete(int id);
    void Delete(Member member);
    int CountByClassId(int classId);
  }
}