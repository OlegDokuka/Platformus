﻿// Copyright © 2015 Dmitry Sikorsky. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using Microsoft.AspNet.Mvc;
using Microsoft.AspNet.Mvc.Rendering;
using Microsoft.AspNet.Razor.Runtime.TagHelpers;

namespace Platformus.Areas.Backend
{
  [TargetElement("unbound-check-box", Attributes = IdentityAttributeName + "," + TextAttributeName + "," + CheckedAttributeName)]
  public class UnboundCheckBoxTagHelper : TagHelperBase
  {
    private const string IdentityAttributeName = "asp-identity";
    private const string TextAttributeName = "asp-text";
    private const string CheckedAttributeName = "asp-checked";

    [HtmlAttributeNotBound]
    [ViewContext]
    public ViewContext ViewContext { get; set; }

    [HtmlAttributeName(IdentityAttributeName)]
    public string Identity { get; set; }

    [HtmlAttributeName(TextAttributeName)]
    public string Text { get; set; }

    [HtmlAttributeName(CheckedAttributeName)]
    public bool Checked { get; set; }

    public override void Process(TagHelperContext context, TagHelperOutput output)
    {
      if (string.IsNullOrEmpty(this.Identity))
        return;

      output.SuppressOutput();
      output.Content.Clear();
      output.Content.Append(this.GenerateCheckBox());
    }

    private TagBuilder GenerateCheckBox()
    {
      TagBuilder tb = new TagBuilder("a");

      tb.AddCssClass("checkbox");
      tb.MergeAttribute("id", this.Identity);
      tb.MergeAttribute("href", "#");
      tb.InnerHtml = new CompositeHtmlContent(
        this.GenerateIndicator(),
        this.GenerateText(),
        this.GenerateInput()
      );

      return tb;
    }

    private TagBuilder GenerateIndicator()
    {
      TagBuilder tb = new TagBuilder("span");

      if (this.GetValue() == true.ToString().ToLower())
        tb.Attributes.Add("class", "indicator checked");

      else tb.Attributes.Add("class", "indicator");

      return tb;
    }

    private TagBuilder GenerateText()
    {
      TagBuilder tb = new TagBuilder("span");

      tb.Attributes.Add("class", "text");
      tb.SetInnerText(this.Text);
      return tb;
    }

    private TagBuilder GenerateInput()
    {
      TagBuilder tb = new TagBuilder("input");

      tb.Attributes.Add("name", this.Identity);
      tb.Attributes.Add("type", "hidden");
      tb.Attributes.Add("value", this.GetValue());
      return tb;
    }

    private string GetValue()
    {
      return this.Checked.ToString().ToLower();
    }
  }
}