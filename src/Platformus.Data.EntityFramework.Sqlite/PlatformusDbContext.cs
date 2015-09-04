// Copyright © 2015 Dmitry Sikorsky. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using Microsoft.Data.Entity;
using Platformus.Models;

namespace Platformus.Data.EntityFramework.Sqlite
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
      optionsBuilder.UseSqlite(this.connectionString);
    }

    protected override void OnModelCreating(ModelBuilder modelbuilder)
    {
      base.OnModelCreating(modelbuilder);

      modelbuilder.Entity<CachedObject>(etb =>
        {
          etb.Key(e => new { e.CultureId, e.ObjectId });
          etb.ToSqliteTable("CachedObjects");
        }
      );

      modelbuilder.Entity<CachedMenu>(etb =>
        {
          etb.Key(e => new { e.CultureId, e.MenuId });
          etb.ToSqliteTable("CachedMenus");
        }
      );

      modelbuilder.Entity<CachedForm>(etb =>
        {
          etb.Key(e => new { e.CultureId, e.FormId });
          etb.ToSqliteTable("CachedForms");
        }
      );

      modelbuilder.Entity<Class>(etb =>
        {
          etb.Key(e => e.Id);
          etb.Property(e => e.Id);// .UseSqlServerIdentityColumn();
          etb.ToSqliteTable("Classes");
        }
      );

      modelbuilder.Entity<Tab>(etb =>
        {
          etb.Key(e => e.Id);
          etb.Property(e => e.Id);// .UseSqlServerIdentityColumn();
          etb.ToSqliteTable("Tabs");
        }
      );

      modelbuilder.Entity<DataType>(etb =>
        {
          etb.Key(e => e.Id);
          etb.Property(e => e.Id);// .UseSqlServerIdentityColumn();
          etb.ToSqliteTable("DataTypes");
        }
      );

      modelbuilder.Entity<Member>(etb =>
        {
          etb.Key(e => e.Id);
          etb.Property(e => e.Id);// .UseSqlServerIdentityColumn();
          etb.ToSqliteTable("Members");
        }
      );

      modelbuilder.Entity<DataSource>(etb =>
        {
          etb.Key(e => e.Id);
          etb.Property(e => e.Id);// .UseSqlServerIdentityColumn();
          etb.ToSqliteTable("DataSources");
        }
      );

      modelbuilder.Entity<Object>(etb =>
        {
          etb.Key(e => e.Id);
          etb.Property(e => e.Id);// .UseSqlServerIdentityColumn();
          etb.ToSqliteTable("Objects");
        }
      );

       modelbuilder.Entity<Property>(etb =>
        {
          etb.Key(e => e.Id);
          etb.Property(e => e.Id);// .UseSqlServerIdentityColumn();
          etb.ToSqliteTable("Properties");
        }
      );

      modelbuilder.Entity<Relation>(etb =>
        {
          etb.Key(e => e.Id);
          etb.Property(e => e.Id);// .UseSqlServerIdentityColumn();
          etb.ToSqliteTable("Relations");
        }
      );

      modelbuilder.Entity<Menu>(etb =>
        {
          etb.Key(e => e.Id);
          etb.Property(e => e.Id);// .UseSqlServerIdentityColumn();
          etb.ToSqliteTable("Menus");
        }
      );

      modelbuilder.Entity<MenuItem>(etb =>
        {
          etb.Key(e => e.Id);
          etb.Property(e => e.Id);// .UseSqlServerIdentityColumn();
          etb.ToSqliteTable("MenuItems");
        }
      );

      modelbuilder.Entity<Form>(etb =>
        {
          etb.Key(e => e.Id);
          etb.Property(e => e.Id);// .UseSqlServerIdentityColumn();
          etb.ToSqliteTable("Forms");
        }
      );

      modelbuilder.Entity<FieldType>(etb =>
        {
          etb.Key(e => e.Id);
          etb.Property(e => e.Id);// .UseSqlServerIdentityColumn();
          etb.ToSqliteTable("FieldTypes");
        }
      );

      modelbuilder.Entity<Field>(etb =>
        {
          etb.Key(e => e.Id);
          etb.Property(e => e.Id);// .UseSqlServerIdentityColumn();
          etb.ToSqliteTable("Fields");
        }
      );

      modelbuilder.Entity<FieldOption>(etb =>
        {
          etb.Key(e => e.Id);
          etb.Property(e => e.Id);// .UseSqlServerIdentityColumn();
          etb.ToSqliteTable("FieldOptions");
        }
      );

      modelbuilder.Entity<File>(etb =>
        {
          etb.Key(e => e.Id);
          etb.Property(e => e.Id);// .UseSqlServerIdentityColumn();
          etb.ToSqliteTable("Files");
        }
      );

      modelbuilder.Entity<Configuration>(etb =>
        {
          etb.Key(e => e.Id);
          etb.Property(e => e.Id);// .UseSqlServerIdentityColumn();
          etb.ToSqliteTable("Configurations");
        }
      );

      modelbuilder.Entity<Variable>(etb =>
        {
          etb.Key(e => e.Id);
          etb.Property(e => e.Id);// .UseSqlServerIdentityColumn();
          etb.ToSqliteTable("Variables");
        }
      );

      modelbuilder.Entity<Dictionary>(etb =>
        {
          etb.Key(e => e.Id);
          etb.Property(e => e.Id);// .UseSqlServerIdentityColumn();
          etb.ToSqliteTable("Dictionaries");
        }
      );

      modelbuilder.Entity<Culture>(etb =>
        {
          etb.Key(e => e.Id);
          etb.Property(e => e.Id);// .UseSqlServerIdentityColumn();
          etb.ToSqliteTable("Cultures");
        }
      );

      modelbuilder.Entity<Localization>(etb =>
        {
          etb.Key(e => e.Id);
          etb.Property(e => e.Id);// .UseSqlServerIdentityColumn();
          etb.ToSqliteTable("Localizations");
        }
      );

      modelbuilder.Entity<Permission>(etb =>
        {
          etb.Key(e => e.Id);
          etb.Property(e => e.Id);// .UseSqlServerIdentityColumn();
          etb.ToSqliteTable("Permissions");
        }
      );

      modelbuilder.Entity<Role>(etb =>
        {
          etb.Key(e => e.Id);
          etb.Property(e => e.Id);// .UseSqlServerIdentityColumn();
          etb.ToSqliteTable("Roles");
        }
      );

      modelbuilder.Entity<RolePermission>(etb =>
        {
          etb.Key(e => new { e.RoleId, e.PermissionId });
          etb.ToSqliteTable("RolePermissions");
        }
      );

      modelbuilder.Entity<User>(etb =>
        {
          etb.Key(e => e.Id);
          etb.Property(e => e.Id);// .UseSqlServerIdentityColumn();
          etb.ToSqliteTable("Users");
        }
      );

      modelbuilder.Entity<UserRole>(etb =>
        {
          etb.Key(e => new { e.UserId, e.RoleId });
          etb.ToSqliteTable("UserRoles");
        }
      );

      modelbuilder.Entity<CredentialType>(etb =>
        {
          etb.Key(e => e.Id);
          etb.Property(e => e.Id);// .UseSqlServerIdentityColumn();
          etb.ToSqliteTable("CredentialTypes");
        }
      );

      modelbuilder.Entity<Credential>(etb =>
        {
          etb.Key(e => e.Id);
          etb.Property(e => e.Id);// .UseSqlServerIdentityColumn();
          etb.ToSqliteTable("Credentials");
        }
      );
    }
  }
}