using Business.Abstract;
using Entities.Dtos.CityDto;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class CityController : Controller
    {
        private readonly ICityService _cityService;

        public CityController(ICityService cityService)
        {
            _cityService = cityService;
        }
        [HttpGet]
        public IActionResult Index()
        {
            var result = _cityService.GetAllCities();
            return View(result);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([FromForm] CityDtoForInsertion dtoForInsertion)
        {
            _cityService.Add(dtoForInsertion);
            return RedirectToAction("Index");
        }

        public IActionResult Delete([FromRoute(Name = "id")] int id)
        {
            var result = _cityService.GetCity(id);

            if (result != null) _cityService.Delete(result);
            return RedirectToAction("Index");
        }


        public IActionResult Update([FromRoute(Name = "id")] int id)
        {
            var entity = _cityService.GetOneCityForUpdate(id);
            return View(entity);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Update([FromForm]  CityDtoForUpdate forUpdate)
        {

             _cityService.Update(forUpdate);
            return RedirectToAction("Index");
        }
    }
}
