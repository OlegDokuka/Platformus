// Copyright © 2015 Dmitry Sikorsky. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNet.Mvc;
using Microsoft.AspNet.Mvc.Rendering;
using Platformus.Areas.Backend.ViewModels.Shared;

namespace Platformus.Areas.Backend
{
  public abstract class DropDownListTagHelperBase : TagHelperBase
  {
    protected TagBuilder GenerateDropDownList(ViewContext viewContext, ModelExpression modelExpression, IEnumerable<OptionViewModel> options)
    {
      TagBuilder tb = new TagBuilder("div");

      tb.AddCssClass("drop-down-list");

      if (!this.IsValid(viewContext, modelExpression))
        tb.AddCssClass("input-validation-error");

      tb.MergeAttribute("id", this.GetIdentity(modelExpression));
      this.HandleAttributes(tb, modelExpression);
      tb.InnerHtml = new CompositeHtmlContent(
        this.GenerateText(viewContext, modelExpression, options),
        this.GenerateDropDownListItems(options),
        this.GenerateInput(viewContext, modelExpression, options)
      );

      return tb;
    }

    private TagBuilder GenerateText(ViewContext viewContext, ModelExpression modelExpression, IEnumerable<OptionViewModel> options)
    {
      TagBuilder tb = new TagBuilder("a");

      tb.AddCssClass("text");
      tb.Attributes.Add("href", "#");
      tb.SetInnerText(this.GetText(viewContext, modelExpression, options));
      return tb;
    }

    private TagBuilder GenerateDropDownListItems(IEnumerable<OptionViewModel> options)
    {
      TagBuilder tb = new TagBuilder("div");

      tb.AddCssClass("drop-down-list-items");
      tb.InnerHtml = new CompositeHtmlContent(options.Select(o => this.GenerateDropDownListItem(o)).ToArray());
      return tb;
    }

    private TagBuilder GenerateDropDownListItem(OptionViewModel option)
    {
      TagBuilder tb = new TagBuilder("a");

      tb.AddCssClass("drop-down-list-item");
      tb.Attributes.Add("data-value", option.Value);
      tb.Attributes.Add("href", "#");
      tb.SetInnerText(option.Text);
      return tb;
    }

    private TagBuilder GenerateInput(ViewContext viewContext, ModelExpression modelExpression, IEnumerable<OptionViewModel> options)
    {
      TagBuilder tb = new TagBuilder("input");

      tb.Attributes.Add("name", this.GetIdentity(modelExpression));
      tb.Attributes.Add("type", "hidden");
      tb.Attributes.Add("value", this.GetValue(viewContext, modelExpression, options));
      return tb;
    }

    private string GetText(ViewContext viewContext, ModelExpression modelExpression, IEnumerable<OptionViewModel> options)
    {
      OptionViewModel option = this.GetOption(viewContext, modelExpression, options);

      if (option == null)
        return null;

      return option.Text;
    }

    private string GetValue(ViewContext viewContext, ModelExpression modelExpression, IEnumerable<OptionViewModel> options)
    {
      OptionViewModel option = this.GetOption(viewContext, modelExpression, options);

      if (option == null)
        return null;

      return option.Value;
    }

    private OptionViewModel GetOption(ViewContext viewContext, ModelExpression modelExpression, IEnumerable<OptionViewModel> options)
    {
      string value = this.GetValue(viewContext, modelExpression);
      OptionViewModel option = null;

      if (!string.IsNullOrEmpty(value))
        option = options.FirstOrDefault(o => o.Value == value);

      if (option == null)
        if (modelExpression.Model != null)
          option = options.FirstOrDefault(o => o.Value == modelExpression.Model.ToString());

      if (option == null)
        option = options.FirstOrDefault();

      return option;
    }
  }
}