using Business.Abstract;
using Entities.Dtos.ProductDto;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin,User")]
    public class ProductController : Controller
    {
        private readonly IProductService _productService;
        private readonly ICategoryService _categoryService;
        private readonly IColorService _colorService;

        public ProductController(IProductService productService, ICategoryService categoryService, IColorService colorService)
        {
            _productService = productService;
            _categoryService = categoryService;
            _colorService = colorService;
        }


        public IActionResult Index()
        {
            var result = _productService.GetProducts();
            return View(result);


        }

        public IActionResult Create()
        {
            ViewBag.Categories = GetCategoriesSelectList();
            ViewBag.Colors = GetColorList();

            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([FromForm] ProductDtoForInsertion productDtoForInsertion, IFormFile file)
        {

            // file operation
            string path = Path.Combine(Directory.GetCurrentDirectory(),
                "wwwroot", "img", file.FileName);

            using (var stream = new FileStream(path, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }

            productDtoForInsertion.ImageUrl = String.Concat("/img/", file.FileName);



            _productService.CreateProduct(productDtoForInsertion);

            return RedirectToAction("Index");

        }



        [HttpGet]
        public IActionResult Update([FromRoute(Name = "id")] int id)
        {

            var result = _productService.GetOneProductForUpdate(id, true);
            ViewBag.Colors = GetColorList();
            ViewBag.Categories = GetCategoriesSelectList();


            return View(result);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(int id, [FromForm] ProductDtoForUpdate productDtoForUpdate, IFormFile file)
        {
            if (id != productDtoForUpdate.ProductId)
            {
                return BadRequest();
            }


            if (file != null)
            {
                // Dosya işlemi
                string path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "img", file.FileName);

                using (var stream = new FileStream(path, FileMode.Create))
                {
                    await file.CopyToAsync(stream);
                }

                productDtoForUpdate.ImageUrl = String.Concat("/img/", file.FileName);
            }


            _productService.UpdateProduct(productDtoForUpdate);


            return RedirectToAction("Index");


        }

        public IActionResult Delete([FromRoute(Name = "id")] int id)
        {
            var result = _productService.GetProducts().SingleOrDefault(x => x.ProductId.Equals(id));

            _productService.DeleteProduct(result);
            return RedirectToAction("Index");
        }

        private SelectList GetCategoriesSelectList()
        {
            return new SelectList(_categoryService.GetActiveCategories().Data, "Id", "Name", "1");
        }

        private SelectList GetColorList()
        {
            return new SelectList(_colorService.GetActiveColors(), "Id", "Name", "1");
        }

        public JsonResult IndexJson()
        {
            var result = _productService.GetProducts().ToList();

            var options = new JsonSerializerOptions
            {
                ReferenceHandler = ReferenceHandler.Preserve,
                MaxDepth = 64 // Döngü derinliğini artırma iç içe geçmiş veriler için normali 32 dir
            };
            return Json(result, options);
        }

        public IActionResult IndexXml()
        {
            var result = _productService.GetProducts().ToList();

            if (result.IsNullOrEmpty())
                return new EmptyResult();

            var xml = "<?xml version=\"1.0\" encoding=\"utf-8\" ?>";
            xml += "<Products>";
            foreach (var product in result)
            {
                xml += "<Product>";
                xml += "<Name>" + product.ProductName + "</Name>";
                xml += "<Name>" + product.Color.Name + "</Name>";
                xml += "<Description>" + product.Description + "</Description>";
                xml += "<Status>" + product.Status + "</Status>";
                xml += "<Price>" + product.Price + "</Price>";
                xml += "<Category>" + product?.Category?.Name + "</Category>";
                xml += "<ImageUrl>" + product?.ImageUrl + "</ImageUrl>";
                xml += "</Product>";
            }
            xml += "</Products>";


            return Content(xml, "application/xml", Encoding.UTF8);
        }
    }
}
