using Business.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace WebUI.Components;

public class ProductFilterAndSearchMenuViewComponent : ViewComponent
{
    private readonly IProductService _productService;

    public ProductFilterAndSearchMenuViewComponent(IProductService productService)
    {
        _productService = productService;
    }

    public IViewComponentResult Invoke()
    {
        return View();
    }
}