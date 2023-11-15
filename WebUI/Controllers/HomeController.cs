using Business.Abstract;
using Entities.RequestParameters;
using Microsoft.AspNetCore.Mvc;
using WebUI.Models;

namespace WebUI.Controllers
{
    public class HomeController : Controller
    {
        private readonly IProductService _productService;
        private readonly ICategoryService _categoryService;
        

        public HomeController(IProductService productService, ICategoryService categoryService)
        {
	        _productService = productService;
	        _categoryService = categoryService;
          
        }

        [HttpGet]
        public IActionResult Index(ProductRequestParameters parameters)
        {
            var products = _productService.GetProductsWithDetails(parameters);

            var pagination = new Pagination()
            {
                CurrentPage = parameters.PageNumber,
                ItemsPerPage = parameters.PageSize,
                TotalItems = _productService.GetAll().Data.Count()
            };


            return View(new ProductListViewModel()
            {
                Products = products,
                Pagination = pagination

            });
        }


        //[HttpGet]
        //public IActionResult _Cart()
        //{
        //    CartModel _cartModel = null;

        //    ViewBag.v3 = _cartModel;

        //    return PartialView();
        //}

    }
}
