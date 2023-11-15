using Business.Abstract;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace WebUI.Infrastructure.TagHelpers;

[HtmlTargetElement("div", Attributes = "products")]
public class LatestProductsTagHelper : TagHelper
{
    private readonly IProductService _productService;

    [HtmlAttributeName("number")]
    public int Number { get; set; }

    public LatestProductsTagHelper(IProductService productService)
    {
        _productService = productService;
    }

    public override void Process(TagHelperContext context, TagHelperOutput output)
    {
        TagBuilder div = new TagBuilder("div");
        div.Attributes.Add("class", "my-3");

        TagBuilder h6 = new TagBuilder("h6");
        h6.Attributes.Add("class", "lead");

        TagBuilder icon = new TagBuilder("i");
        icon.Attributes.Add("class", "fa fa-box text-secondary");


        h6.InnerHtml.AppendHtml(icon);
        h6.InnerHtml.AppendHtml("Latest Products");


        TagBuilder ul = new TagBuilder("ul");

        var products = _productService.GetLatestProducts(Number);

        foreach (var item in products)
        {
            TagBuilder li = new TagBuilder("li");
            TagBuilder a = new TagBuilder("a");
            a.Attributes.Add("href", $"/product/get/{item.ProductId}");
            a.InnerHtml.AppendHtml(item.ProductName);

            li.InnerHtml.AppendHtml(a);
            ul.InnerHtml.AppendHtml(li);
        }

        div.InnerHtml.AppendHtml(h6);
        div.InnerHtml.AppendHtml(ul);
        output.Content.AppendHtml(div);
    }


}