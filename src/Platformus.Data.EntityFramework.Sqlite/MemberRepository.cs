﻿// Copyright © 2015 Dmitry Sikorsky. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System.Collections.Generic;
using System.Linq;
using Microsoft.Data.Entity;
using Platformus.Models;

namespace Platformus.Data.EntityFramework.Sqlite
{
  public class MemberRepository : RepositoryBase<Member>, IMemberRepository
  {
    public Member WithKey(int id)
    {
      return this.dbSet.FirstOrDefault(m => m.Id == id);
    }

    public IEnumerable<Member> FilteredByClassId(int classId)
    {
      return this.dbSet.Where(m => m.ClassId == classId).OrderBy(m => m.Position);
    }

    public IEnumerable<Member> FilteredByClassIdDisplayInList(int classId)
    {
      return this.dbSet.Where(m => m.ClassId == classId && m.DisplayInList == true).OrderBy(m => m.Position);
    }

    public IEnumerable<Member> FilteredByRelationClassIdRelationSingleParent(int relationClassId)
    {
      return this.dbSet.Where(m => m.RelationClassId == relationClassId && m.IsRelationSingleParent == true).OrderBy(m => m.Position);
    }

    public IEnumerable<Member> Range(int classId, string orderBy, string direction, int skip, int take)
    {
      return this.dbSet.Where(m => m.ClassId == classId).OrderBy(m => m.Position).Skip(skip).Take(take);
    }

    public void Create(Member member)
    {
      this.dbSet.Add(member);
    }

    public void Edit(Member member)
    {
      this.dbContext.Entry(member).State = EntityState.Modified;
    }

    public void Delete(int id)
    {
      this.Delete(this.WithKey(id));
    }

    public void Delete(Member member)
    {
      this.dbContext.Database.ExecuteSqlCommand(
        @"
          DELETE FROM CachedObjects WHERE ClassId IN (SELECT ClassId FROM Members WHERE Id = {0});
          CREATE TEMP TABLE TempDictionaries (Id INT PRIMARY KEY);
          INSERT INTO TempDictionaries SELECT HtmlId FROM Properties WHERE MemberId = {0};
          DELETE FROM Properties WHERE MemberId = {0};
          DELETE FROM Localizations WHERE DictionaryId IN (SELECT Id FROM TempDictionaries);
          DELETE FROM Dictionaries WHERE Id IN (SELECT Id FROM TempDictionaries);
        ",
        member.Id
      );

      this.dbSet.Remove(member);
    }

    public int CountByClassId(int classId)
    {
      return this.dbSet.Count(m => m.ClassId == classId);
    }
  }
}