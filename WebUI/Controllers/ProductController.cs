using Business.Abstract;
using Entities.Concrete;
using Entities.RequestParameters;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebUI.Models;

namespace WebUI.Controllers
{
    [AllowAnonymous]
    public class ProductController : Controller
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        public IActionResult Index(ProductRequestParameters parameters)
        {

            var products = _productService.GetProductsWithDetails(parameters);

            var pagination = new Pagination()
            {
                CurrentPage = parameters.PageNumber,
                ItemsPerPage = parameters.PageSize,
                TotalItems = _productService.GetActiveProducts().Count()
            };


            return View(new ProductListViewModel()
            {
                Products = products,
                Pagination = pagination,
            });

        }




        public IActionResult Get([FromRoute(Name = "id")] int id)
        {

            Product? result = _productService.GetActiveProducts().SingleOrDefault(x => x.ProductId.Equals(id));
            ViewBag.v1 = _productService.GetActiveProducts();


            if (result == null)
            {
                return View("_Error", "This product was not found! you can look at something else");
            }

            return View(result);
        }

    }
}
