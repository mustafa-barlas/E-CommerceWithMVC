using Business.Abstract;
using Entities.Dtos.AddressDto;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Security.Claims;

namespace WebUI.Controllers
{
    [AllowAnonymous]
    [Authorize]
    public class AddressController : Controller
    {
        private readonly IAddressService _addressService;
        private readonly ICityService _cityService;

        public AddressController(IAddressService addressService, ICityService cityService)
        {
            _addressService = addressService;
            _cityService = cityService;
        }

        public IActionResult Index()
        {
            string userId = null;

            if (HttpContext.User.Identity is ClaimsIdentity claimsIdentity)
            {
                var userIdClaim = claimsIdentity.FindFirst(ClaimTypes.Sid);

                if (userIdClaim != null)
                {
                    userId = userIdClaim.Value;


                }

            }


            var result = _addressService.GetAddressWitDetails(Convert.ToInt32(userId)).ToList();

            return View(result);
        }

        public IActionResult Create()
        {
            TempData["info"] = "Please fill the form.";
            ViewBag.Cities = GetCitiesSelectList();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([FromForm] AddressDtoForInsertion forInsertion)
        {
            if (HttpContext.User.Identity is ClaimsIdentity claimsIdentity)
            {
                var userIdClaim = claimsIdentity.FindFirst(ClaimTypes.Sid);
                var userNameClaim = claimsIdentity.FindFirst(ClaimTypes.Name);
                var userSurnameClaim = claimsIdentity.FindFirst(ClaimTypes.Surname);

                if (userIdClaim != null)
                {
                    string userId = userIdClaim.Value;
                    forInsertion.UserId = Convert.ToInt32(userId);
                    forInsertion.FirstName = userNameClaim.Value;
                    forInsertion.LastName = userSurnameClaim.Value;
                }

            }

            _addressService.CreateAddress(forInsertion);
            return RedirectToAction("Index", "Address");
        }

        [HttpGet]
        public IActionResult Update([FromRoute(Name = "id")] int id)
        {
            ViewBag.cities = GetCitiesSelectList();
            var result = _addressService.GetOneAddressForUpdate(id, true);

            return View(result);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Update([FromForm] AddressDtoForUpdate addressDtoForUpdate)
        {
            if (HttpContext.User.Identity is ClaimsIdentity claimsIdentity)
            {
                var userIdClaim = claimsIdentity.FindFirst(ClaimTypes.Sid);
                var userNameClaim = claimsIdentity.FindFirst(ClaimTypes.Name);
                var userSurnameClaim = claimsIdentity.FindFirst(ClaimTypes.Surname);

                if (userIdClaim != null)
                {
                    string userId = userIdClaim.Value;
                    addressDtoForUpdate.UserId = Convert.ToInt32(userId);
                    addressDtoForUpdate.FirstName = userNameClaim.Value;
                    addressDtoForUpdate.LastName = userSurnameClaim.Value;
                }

            }


            _addressService.UpdateAddress(addressDtoForUpdate);
            return RedirectToAction("Index", "Address");
        }

        public IActionResult Delete(int id)
        {
            var result = _addressService.FindByConditionWithAsNoTracking(id, true);
            _addressService.DeleteAddress(result);

            return RedirectToAction("Index", "Address");
        }


        private SelectList GetCitiesSelectList()
        {
            return new SelectList(_cityService.GetActiveCities(), "CityId", "Name", "1");
        }
    }
}
