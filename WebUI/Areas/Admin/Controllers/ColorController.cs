using Business.Abstract;
using Entities.Dtos.ColorDto;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class ColorController : Controller
    {
        private readonly IColorService _colorService;

        public ColorController(IColorService colorService)
        {
            _colorService = colorService;
        }

        public IActionResult Index()
        {
            var result = _colorService.FindAllWithAsNoTracking(true);
            return View(result);
        }

        public IActionResult Create([FromRoute(Name = "id")] int id)
        {
            var result = _colorService.GetOneColorForUpdate(id, true);
            return View(result);
        }

        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public IActionResult Create([FromForm] ColorDto colorDto)
        {
            if (ModelState.IsValid)
            {
                _colorService.Add(colorDto);
            }

            return RedirectToAction("Index");
        }

        public IActionResult Update([FromRoute(Name = "id")] int id)
        {
            var result = _colorService.GetOneColorForUpdate(id, true);
            return View(result);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Update([FromForm] ColorDto colorDto)
        {
            _colorService.Update(colorDto);
            return RedirectToAction("Index");
        }


        public IActionResult Delete([FromRoute(Name = "id")] int id)
        {
            var result = _colorService.FindByConditionWithAsNoTracking(id, true);
            _colorService.Delete(result);

            return RedirectToAction("Index");
        }
    }
}
