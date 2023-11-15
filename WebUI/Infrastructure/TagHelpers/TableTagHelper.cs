using Microsoft.AspNetCore.Razor.TagHelpers;

namespace WebUI.Infrastructure.TagHelpers;

[HtmlTargetElement("Table")]
public class TableTagHelper : TagHelper
{
    public override void Process(TagHelperContext context, TagHelperOutput output)
    {
        output.Attributes.SetAttribute("class","table");
    }
}