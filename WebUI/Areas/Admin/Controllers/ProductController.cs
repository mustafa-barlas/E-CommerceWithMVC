using Business.Abstract;
using DataAccess.Concrete.EntityFramework.Contexts;
using Entities.Concrete;
using Entities.Dtos.ProductDto;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProductController : Controller
    {
        private readonly IProductService _productService;
        private readonly ICategoryService _categoryService;
        private readonly IProductColorService _productColorService;
        private readonly IColorService _colorService;

        public ProductController(IProductService productService, ICategoryService categoryService, IColorService colorService, IProductColorService productColorService)
        {
            _productService = productService;
            _categoryService = categoryService;
            _colorService = colorService;
            _productColorService = productColorService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var result = _productService.GetProducts();
            return View(result);


        }

        public IActionResult Create()
        {
            TempData["info"] = "Please fill the form.";
            ViewBag.Categories = GetCategoriesSelectList();

            ViewBag.Colors = _colorService.FindAllWithAsNoTracking(false);

            return View();
        }

        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([FromForm] ProductDtoForInsertion productDto, IFormFile file, List<int> selectedColors)
        {

            // file operation
            string path = Path.Combine(Directory.GetCurrentDirectory(),
                "wwwroot", "img", file.FileName);

            using (var stream = new FileStream(path, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }

            productDto.ImageUrl = String.Concat("/img/", file.FileName);

            

            _productService.CreateProduct(productDto,selectedColors);
            var result = _productService.GetAll().Data.Last();
            _productColorService.CreateProductColor(result.ProductId,selectedColors);

            ViewBag.Colors = _colorService.GetAll().ToList();
            return RedirectToAction("Index");
           
        }



        [HttpGet]
        public IActionResult Update([FromRoute(Name = "id")] int id)
        {
            ViewBag.categories = GetCategoriesSelectList();
            var result = _productService.GetOneProductForUpdate(id, true);
            //var result = _productService.FindByConditionWithAsNoTracking(id, true);
            return View(result);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update([FromForm] ProductDtoForUpdate productDto, IFormFile file)
        {
            // file operation
            string path = Path.Combine(Directory.GetCurrentDirectory(),
                "wwwroot", "img", file.FileName);

            using (var stream = new FileStream(path, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }
            productDto.ImageUrl = String.Concat("/img/", file.FileName);

            _productService.UpdateProduct(productDto);
            return RedirectToAction("Index");
        }

        public IActionResult Delete([FromRoute(Name = "id")] int id)
        {
            var result = _productService.FindByConditionWithAsNoTracking(id, true);
            _productService.DeleteProduct(result);
            return RedirectToAction("Index");
        }

        private SelectList GetCategoriesSelectList()
        {
            return new SelectList(_categoryService.GetAll().Data, "Id", "Name", "1");
        }
    }
}
