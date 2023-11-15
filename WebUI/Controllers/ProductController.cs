using Business.Abstract;
using Entities.Concrete;
using Entities.RequestParameters;
using Microsoft.AspNetCore.Mvc;
using WebUI.Models;

namespace WebUI.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductService _productService;
        private readonly IProductColorService _productColorService;

        public ProductController(IProductService productService, IProductColorService productColorService)
        {
            _productService = productService;
            _productColorService = productColorService;
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

        public IActionResult Get([FromRoute(Name = "id")] int id)
        {


	        Product? result = _productService.FindByConditionWithAsNoTracking(id,true);
	        ViewBag.v1 = _productService.GetAll().Data;

            var result1  = _productColorService.GetProductColors().ToList();
            ViewBag.v5 = result1;
            return View(result);
        }
    }
}
