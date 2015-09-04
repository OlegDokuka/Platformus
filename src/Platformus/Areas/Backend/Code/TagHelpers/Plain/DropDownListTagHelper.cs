﻿// Copyright © 2015 Dmitry Sikorsky. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System.Collections.Generic;
using Microsoft.AspNet.Mvc;
using Microsoft.AspNet.Mvc.Rendering;
using Microsoft.AspNet.Razor.Runtime.TagHelpers;
using Platformus.Areas.Backend.ViewModels.Shared;

namespace Platformus.Areas.Backend
{
  [TargetElement("drop-down-list", Attributes = ForAttributeName + "," + OptionsAttributeName)]
  public class DropDownListTagHelper : DropDownListTagHelperBase
  {
    private const string ForAttributeName = "asp-for";
    private const string OptionsAttributeName = "asp-options";

    [HtmlAttributeNotBound]
    [ViewContext]
    public ViewContext ViewContext { get; set; }

    [HtmlAttributeName(ForAttributeName)] 
    public ModelExpression For { get; set; }

    [HtmlAttributeName(OptionsAttributeName)]
    public IEnumerable<OptionViewModel> Options { get; set; }

    public override void Process(TagHelperContext context, TagHelperOutput output)
    {
      if (this.ViewContext == null || this.For == null || this.Options == null)
        return;

      output.SuppressOutput();
      output.Content.Clear();
      output.Content.Append(this.GenerateDropDownList(this.ViewContext, this.For, this.Options));
    }
  }
}