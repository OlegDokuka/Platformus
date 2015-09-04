// Copyright © 2015 Dmitry Sikorsky. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System.Collections.Generic;
using Newtonsoft.Json;
using Platformus.Data;
using Platformus.Models;

namespace Platformus
{
  public class CacheManager
  {
    public IHandler handler;

    public CacheManager(IHandler handler)
    {
      this.handler = handler;
    }

    public void CacheObject(Object @object)
    {
      foreach (Culture culture in this.handler.Storage.GetRepository<ICultureRepository>().All())
      {
        CachedObject cachedObject = this.handler.Storage.GetRepository<ICachedObjectRepository>().WithKey(culture.Id, @object.Id);

        if (cachedObject == null)
          this.handler.Storage.GetRepository<ICachedObjectRepository>().Create(this.CacheObject(culture, @object));

        else
        {
          CachedObject temp = this.CacheObject(culture, @object);

          cachedObject.ClassId = temp.ClassId;
          cachedObject.ClassViewName = temp.ClassViewName;
          cachedObject.Url = temp.Url;
          cachedObject.CachedProperties = temp.CachedProperties;
          cachedObject.CachedDataSources = temp.CachedDataSources;
          this.handler.Storage.GetRepository<ICachedObjectRepository>().Edit(cachedObject);
        }
      }

      this.handler.Storage.Save();
    }

    public void CacheMenu(Menu menu)
    {
      foreach (Culture culture in this.handler.Storage.GetRepository<ICultureRepository>().All())
      {
        CachedMenu cachedMenu = this.handler.Storage.GetRepository<ICachedMenuRepository>().WithKey(culture.Id, menu.Id);

        if (cachedMenu == null)
          this.handler.Storage.GetRepository<ICachedMenuRepository>().Create(this.CacheMenu(culture, menu));

        else
        {
          CachedMenu temp = this.CacheMenu(culture, menu);

          cachedMenu.Code = temp.Code;
          cachedMenu.CachedMenuItems = temp.CachedMenuItems;
          this.handler.Storage.GetRepository<ICachedMenuRepository>().Edit(cachedMenu);
        }
      }

      this.handler.Storage.Save();
    }

    public void CacheForm(Form form)
    {
      foreach (Culture culture in this.handler.Storage.GetRepository<ICultureRepository>().All())
      {
        CachedForm cachedForm = this.handler.Storage.GetRepository<ICachedFormRepository>().WithKey(culture.Id, form.Id);

        if (cachedForm == null)
          this.handler.Storage.GetRepository<ICachedFormRepository>().Create(this.CacheForm(culture, form));

        else
        {
          CachedForm temp = this.CacheForm(culture, form);

          cachedForm.Code = temp.Code;
          cachedForm.Name = temp.Name;
          cachedForm.CachedFields = temp.CachedFields;
          this.handler.Storage.GetRepository<ICachedFormRepository>().Edit(cachedForm);
        }
      }

      this.handler.Storage.Save();
    }

    private CachedObject CacheObject(Culture culture, Object @object)
    {
      Class @class = this.handler.Storage.GetRepository<IClassRepository>().WithKey(@object.ClassId);
      List<CachedProperty> cachedProperties = new List<CachedProperty>();

      foreach (Member member in this.handler.Storage.GetRepository<IMemberRepository>().FilteredByClassId(@class.Id))
      {
        if (member.PropertyDataTypeId != null)
        {
          Property property = this.handler.Storage.GetRepository<IPropertyRepository>().WithObjectIdAndMemberId(@object.Id, member.Id);

          cachedProperties.Add(this.CacheProperty(culture, property));
        }
      }

      List<CachedDataSource> cachedDataSources = new List<CachedDataSource>();

      foreach (DataSource dataSource in this.handler.Storage.GetRepository<IDataSourceRepository>().FilteredByClassId(@class.Id))
        cachedDataSources.Add(this.CacheDataSource(culture, dataSource));

      CachedObject cachedObject = new CachedObject();

      cachedObject.ObjectId = @object.Id;
      cachedObject.ClassId = @class.Id;
      cachedObject.ClassViewName = @class.ViewName;
      cachedObject.Url = @object.Url;
      cachedObject.CultureId = culture.Id;

      if (cachedProperties.Count != 0)
        cachedObject.CachedProperties = this.SerializeObject(cachedProperties);

      if (cachedDataSources.Count != 0)
        cachedObject.CachedDataSources = this.SerializeObject(cachedDataSources);

      return cachedObject;
    }

    private CachedProperty CacheProperty(Culture culture, Property property)
    {
      CachedProperty cachedProperty = new CachedProperty();

      cachedProperty.PropertyId = property.Id;
      cachedProperty.MemberCode = this.handler.Storage.GetRepository<IMemberRepository>().WithKey(property.MemberId).Code;
      cachedProperty.Html = this.GetLocalizationValue(culture.Id, property.HtmlId);
      return cachedProperty;
    }

    private CachedDataSource CacheDataSource(Culture culture, DataSource dataSource)
    {
      CachedDataSource cachedDataSource = new CachedDataSource();

      cachedDataSource.DataSourceId = dataSource.Id;
      cachedDataSource.CSharpClassName = dataSource.CSharpClassName;
      cachedDataSource.Parameters = dataSource.Parameters;
      cachedDataSource.Code = dataSource.Code;
      return cachedDataSource;
    }

    private CachedMenu CacheMenu(Culture culture, Menu menu)
    {
      List<CachedMenuItem> cachedMenuItems = new List<CachedMenuItem>();

      foreach (MenuItem menuItem in this.handler.Storage.GetRepository<IMenuItemRepository>().FilteredByMenuId(menu.Id))
        cachedMenuItems.Add(this.CacheMenuItem(culture, menuItem));

      CachedMenu cachedForm = new CachedMenu();

      cachedForm.MenuId = menu.Id;
      cachedForm.CultureId = culture.Id;
      cachedForm.Code = menu.Code;

      if (cachedMenuItems.Count != 0)
        cachedForm.CachedMenuItems = this.SerializeObject(cachedMenuItems);

      return cachedForm;
    }

    private CachedMenuItem CacheMenuItem(Culture culture, MenuItem menuItem)
    {
      List<CachedMenuItem> cachedChildMenuItems = new List<CachedMenuItem>();

      foreach (MenuItem childMenuItem in this.handler.Storage.GetRepository<IMenuItemRepository>().FilteredByMenuItemId(menuItem.Id))
        cachedChildMenuItems.Add(this.CacheMenuItem(culture, childMenuItem));

      CachedMenuItem cachedMenuItem = new CachedMenuItem();

      cachedMenuItem.MenuItemId = menuItem.Id;
      cachedMenuItem.Name = this.GetLocalizationValue(culture.Id, menuItem.NameId);
      cachedMenuItem.Url = this.GetMenuItemUrl(menuItem);
      cachedMenuItem.Position = menuItem.Position;

      if (cachedChildMenuItems.Count != 0)
        cachedMenuItem.CachedMenuItems = this.SerializeObject(cachedChildMenuItems);

      return cachedMenuItem;
    }

    private string GetMenuItemUrl(MenuItem menuItem)
    {
      if (menuItem.ObjectId == null)
        return menuItem.Url;

      return this.handler.Storage.GetRepository<IObjectRepository>().WithKey((int)menuItem.ObjectId).Url;
    }

    private CachedForm CacheForm(Culture culture, Form form)
    {
      List<CachedField> cachedFields = new List<CachedField>();

      foreach (Field field in this.handler.Storage.GetRepository<IFieldRepository>().FilteredByFormId(form.Id))
        cachedFields.Add(this.CacheField(culture, field));

      CachedForm cachedForm = new CachedForm();

      cachedForm.FormId = form.Id;
      cachedForm.CultureId = culture.Id;
      cachedForm.Code = form.Code;
      cachedForm.Name = this.GetLocalizationValue(culture.Id, form.NameId);

      if (cachedFields.Count != 0)
        cachedForm.CachedFields = this.SerializeObject(cachedFields);

      return cachedForm;
    }

    private CachedField CacheField(Culture culture, Field field)
    {
      List<CachedFieldOption> cachedFieldOptions = new List<CachedFieldOption>();

      foreach (FieldOption fieldOption in this.handler.Storage.GetRepository<IFieldOptionRepository>().FilteredByFieldId(field.Id))
        cachedFieldOptions.Add(this.CacheFieldOption(culture, fieldOption));

      CachedField cachedField = new CachedField();

      cachedField.FieldId = field.Id;
      cachedField.FieldTypeCode = this.handler.Storage.GetRepository<IFieldTypeRepository>().WithKey(field.FieldTypeId).Code;
      cachedField.Name = this.GetLocalizationValue(culture.Id, field.NameId);
      cachedField.Position = field.Position;

      if (cachedFieldOptions.Count != 0)
        cachedField.CachedFieldOptions = this.SerializeObject(cachedFieldOptions);

      return cachedField;
    }

    private CachedFieldOption CacheFieldOption(Culture culture, FieldOption fieldOption)
    {
      CachedFieldOption cachedFieldOption = new CachedFieldOption();

      cachedFieldOption.FieldOptionId = fieldOption.Id;
      cachedFieldOption.Value = this.GetLocalizationValue(culture.Id, fieldOption.ValueId);
      cachedFieldOption.Position = fieldOption.Position;
      return cachedFieldOption;
    }

    private string GetLocalizationValue(int cultureId, int dictionaryId)
    {
      Localization localization = this.handler.Storage.GetRepository<ILocalizationRepository>().WithDictionaryIdAndCultureId(dictionaryId, cultureId);

      if (localization == null)
        return null;

      return localization.Value;
    }

    private string SerializeObject(object value)
    {
      string result = JsonConvert.SerializeObject(value);

      if (string.IsNullOrEmpty(result))
        return null;

      return result;
    }
  }
}