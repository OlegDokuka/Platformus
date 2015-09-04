// Copyright © 2015 Dmitry Sikorsky. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using Microsoft.Data.Entity;
using Platformus.Models;

namespace Platformus.Data.EntityFramework.SqlServer
{
  public class PlatformusDbContext : DbContext, IDbContext
  {
    private string connectionString { get; set; }

    public DbSet<CachedObject> CachedObjects { get; set; }
    public DbSet<CachedMenu> CachedMenus { get; set; }
    public DbSet<CachedForm> CachedForms { get; set; }
    public DbSet<Class> Classes { get; set; }
    public DbSet<Tab> Tabs { get; set; }
    public DbSet<DataType> DataTypes { get; set; }
    public DbSet<Member> Members { get; set; }
    public DbSet<DataSource> DataSources { get; set; }
    public DbSet<Object> Objects { get; set; }
    public DbSet<Property> Properties { get; set; }
    public DbSet<Relation> Relations { get; set; }
    public DbSet<Menu> Menus { get; set; }
    public DbSet<MenuItem> MenuItems { get; set; }
    public DbSet<Form> Forms { get; set; }
    public DbSet<FieldType> FieldTypes { get; set; }
    public DbSet<Field> Fields { get; set; }
    public DbSet<FieldOption> FieldOptions { get; set; }
    public DbSet<File> Files { get; set; }
    public DbSet<Configuration> Configurations { get; set; }
    public DbSet<Variable> Variables { get; set; }
    public DbSet<Dictionary> Dictionaries { get; set; }
    public DbSet<Culture> Cultures { get; set; }
    public DbSet<Localization> Localizations { get; set; }
    public DbSet<Permission> Permissions { get; set; }
    public DbSet<Role> Roles { get; set; }
    public DbSet<RolePermission> RolePermissions { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<UserRole> UserRoles { get; set; }
    public DbSet<CredentialType> CredentialTypes { get; set; }
    public DbSet<Credential> Credentials { get; set; }

    public PlatformusDbContext(string connectionString)
    {
      this.connectionString = connectionString;
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
      base.OnConfiguring(optionsBuilder);
      optionsBuilder.UseSqlServer(this.connectionString);
    }

    protected override void OnModelCreating(ModelBuilder modelbuilder)
    {
      base.OnModelCreating(modelbuilder);

      modelbuilder.Entity<CachedObject>(etb =>
        {
          etb.Key(e => new { e.CultureId, e.ObjectId });
          etb.ToSqlServerTable("CachedObjects");
        }
      );

      modelbuilder.Entity<CachedMenu>(etb =>
        {
          etb.Key(e => new { e.CultureId, e.MenuId });
          etb.ToSqlServerTable("CachedMenus");
        }
      );

      modelbuilder.Entity<CachedForm>(etb =>
        {
          etb.Key(e => new { e.CultureId, e.FormId });
          etb.ToSqlServerTable("CachedForms");
        }
      );

      modelbuilder.Entity<Class>(etb =>
        {
          etb.Key(e => e.Id);
          etb.Property(e => e.Id).UseSqlServerIdentityColumn();
          etb.ToSqlServerTable("Classes");
        }
      );

      modelbuilder.Entity<Tab>(etb =>
        {
          etb.Key(e => e.Id);
          etb.Property(e => e.Id).UseSqlServerIdentityColumn();
          etb.ToSqlServerTable("Tabs");
        }
      );

      modelbuilder.Entity<DataType>(etb =>
        {
          etb.Key(e => e.Id);
          etb.Property(e => e.Id).UseSqlServerIdentityColumn();
          etb.ToSqlServerTable("DataTypes");
        }
      );

      modelbuilder.Entity<Member>(etb =>
        {
          etb.Key(e => e.Id);
          etb.Property(e => e.Id).UseSqlServerIdentityColumn();
          etb.ToSqlServerTable("Members");
        }
      );

      modelbuilder.Entity<DataSource>(etb =>
        {
          etb.Key(e => e.Id);
          etb.Property(e => e.Id).UseSqlServerIdentityColumn();
          etb.ToSqlServerTable("DataSources");
        }
      );

      modelbuilder.Entity<Object>(etb =>
        {
          etb.Key(e => e.Id);
          etb.Property(e => e.Id).UseSqlServerIdentityColumn();
          etb.ToSqlServerTable("Objects");
        }
      );

       modelbuilder.Entity<Property>(etb =>
        {
          etb.Key(e => e.Id);
          etb.Property(e => e.Id).UseSqlServerIdentityColumn();
          etb.ToSqlServerTable("Properties");
        }
      );

      modelbuilder.Entity<Relation>(etb =>
        {
          etb.Key(e => e.Id);
          etb.Property(e => e.Id).UseSqlServerIdentityColumn();
          etb.ToSqlServerTable("Relations");
        }
      );

      modelbuilder.Entity<Menu>(etb =>
        {
          etb.Key(e => e.Id);
          etb.Property(e => e.Id).UseSqlServerIdentityColumn();
          etb.ToSqlServerTable("Menus");
        }
      );

      modelbuilder.Entity<MenuItem>(etb =>
        {
          etb.Key(e => e.Id);
          etb.Property(e => e.Id).UseSqlServerIdentityColumn();
          etb.ToSqlServerTable("MenuItems");
        }
      );

      modelbuilder.Entity<Form>(etb =>
        {
          etb.Key(e => e.Id);
          etb.Property(e => e.Id).UseSqlServerIdentityColumn();
          etb.ToSqlServerTable("Forms");
        }
      );

      modelbuilder.Entity<FieldType>(etb =>
        {
          etb.Key(e => e.Id);
          etb.Property(e => e.Id).UseSqlServerIdentityColumn();
          etb.ToSqlServerTable("FieldTypes");
        }
      );

      modelbuilder.Entity<Field>(etb =>
        {
          etb.Key(e => e.Id);
          etb.Property(e => e.Id).UseSqlServerIdentityColumn();
          etb.ToSqlServerTable("Fields");
        }
      );

      modelbuilder.Entity<FieldOption>(etb =>
        {
          etb.Key(e => e.Id);
          etb.Property(e => e.Id).UseSqlServerIdentityColumn();
          etb.ToSqlServerTable("FieldOptions");
        }
      );

      modelbuilder.Entity<File>(etb =>
        {
          etb.Key(e => e.Id);
          etb.Property(e => e.Id).UseSqlServerIdentityColumn();
          etb.ToSqlServerTable("Files");
        }
      );

      modelbuilder.Entity<Configuration>(etb =>
        {
          etb.Key(e => e.Id);
          etb.Property(e => e.Id).UseSqlServerIdentityColumn();
          etb.ToSqlServerTable("Configurations");
        }
      );

      modelbuilder.Entity<Variable>(etb =>
        {
          etb.Key(e => e.Id);
          etb.Property(e => e.Id).UseSqlServerIdentityColumn();
          etb.ToSqlServerTable("Variables");
        }
      );

      modelbuilder.Entity<Dictionary>(etb =>
        {
          etb.Key(e => e.Id);
          etb.Property(e => e.Id).UseSqlServerIdentityColumn();
          etb.ToSqlServerTable("Dictionaries");
        }
      );

      modelbuilder.Entity<Culture>(etb =>
        {
          etb.Key(e => e.Id);
          etb.Property(e => e.Id).UseSqlServerIdentityColumn();
          etb.ToSqlServerTable("Cultures");
        }
      );

      modelbuilder.Entity<Localization>(etb =>
        {
          etb.Key(e => e.Id);
          etb.Property(e => e.Id).UseSqlServerIdentityColumn();
          etb.ToSqlServerTable("Localizations");
        }
      );

      modelbuilder.Entity<Permission>(etb =>
        {
          etb.Key(e => e.Id);
          etb.Property(e => e.Id).UseSqlServerIdentityColumn();
          etb.ToSqlServerTable("Permissions");
        }
      );

      modelbuilder.Entity<Role>(etb =>
        {
          etb.Key(e => e.Id);
          etb.Property(e => e.Id).UseSqlServerIdentityColumn();
          etb.ToSqlServerTable("Roles");
        }
      );

      modelbuilder.Entity<RolePermission>(etb =>
        {
          etb.Key(e => new { e.RoleId, e.PermissionId });
          etb.ToSqlServerTable("RolePermissions");
        }
      );

      modelbuilder.Entity<User>(etb =>
        {
          etb.Key(e => e.Id);
          etb.Property(e => e.Id).UseSqlServerIdentityColumn();
          etb.ToSqlServerTable("Users");
        }
      );

      modelbuilder.Entity<UserRole>(etb =>
        {
          etb.Key(e => new { e.UserId, e.RoleId });
          etb.ToSqlServerTable("UserRoles");
        }
      );

      modelbuilder.Entity<CredentialType>(etb =>
        {
          etb.Key(e => e.Id);
          etb.Property(e => e.Id).UseSqlServerIdentityColumn();
          etb.ToSqlServerTable("CredentialTypes");
        }
      );

      modelbuilder.Entity<Credential>(etb =>
        {
          etb.Key(e => e.Id);
          etb.Property(e => e.Id).UseSqlServerIdentityColumn();
          etb.ToSqlServerTable("Credentials");
        }
      );
    }
  }
}