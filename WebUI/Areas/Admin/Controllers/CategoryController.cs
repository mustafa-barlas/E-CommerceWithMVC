using Business.Abstract;
using Entities.Dtos.CategoryDto;
using Microsoft.AspNetCore.Mvc;

namespace WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CategoryController : Controller
    {
        private readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        public IActionResult Index()
        {
            var result = _categoryService.GetAll().Data;
            return View(result);
        }


        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([FromForm] CategoryDtoForInsertion dtoForInsertion, IFormFile file)
        {
            // File Operations

            string path = Path.Combine(Directory.GetCurrentDirectory(),"wwwroot","img",file.FileName);

            using (var stream = new FileStream(path,FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }

            dtoForInsertion.ImageUrl = String.Concat("/img/",file.FileName);
            _categoryService.CreateCategory(dtoForInsertion);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Update([FromRoute(Name = "id")] int id)
        {
            var result = _categoryService.GetOneCategoryForUpdate(id,true);
            return View(result);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update([FromForm]CategoryDtoForUpdate dtoForUpdate, IFormFile file)
        {
            //File Operations 

            string path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "img", file.FileName);

            using (var stream = new FileStream(path,FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }
            dtoForUpdate.ImageUrl = string.Concat("/img/",file.FileName);
            _categoryService.UpdateCategory(dtoForUpdate);
            return RedirectToAction("Index");
        }

        public IActionResult Delete([FromRoute(Name = "id")] int id)
        {
            var result = _categoryService.FindByConditionWithAsNoTracking(id, true);
            _categoryService.DeleteCategory(result);
            return RedirectToAction("Index");
        }
    }
}
