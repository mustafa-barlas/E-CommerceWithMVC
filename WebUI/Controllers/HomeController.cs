using Business.Abstract;
using Entities.RequestParameters;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebUI.Models;

namespace WebUI.Controllers
{
    [AllowAnonymous]
    public class HomeController : Controller
    {
        private readonly IProductService _productService;
        

        public HomeController(IProductService productService)
        {
	        _productService = productService;
          
        }

        [HttpGet]
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
                Pagination = pagination

            });
        }

    }
}
