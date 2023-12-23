using System.Security.Claims;
using Business.Abstract;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using WebUI.Models;

namespace WebUI.Controllers
{
    [AllowAnonymous]
    [Authorize]
    public class FavoriteController : Controller
    {
        private const string SESSIONKEY = "favorites";
        private int? _userId;
        private readonly IProductService _productService;

        public FavoriteController(IProductService productService)
        {
            _productService = productService;
        }

        private List<FavoriteModel> GetSession(int userId)
        {
            var favorites = new List<FavoriteModel>();

            var favoritesJson = HttpContext.Session.GetString(SESSIONKEY);

            if (!string.IsNullOrWhiteSpace(favoritesJson))
            {
                favorites = JsonConvert.DeserializeObject<List<FavoriteModel>>(favoritesJson);

                favorites = favorites.Where(f => f.UserId == userId).ToList();
            }

            return favorites;
        }

        private void SetSession(List<FavoriteModel> favoritesList)
        {
            var favoritesJson = JsonConvert.SerializeObject(favoritesList);

            HttpContext.Session.SetString(SESSIONKEY, favoritesJson);
        }

        public IActionResult GetFavorites()
        {

            if (HttpContext.User.Identity is ClaimsIdentity claimsIdentity)
            {
                _userId = Convert.ToInt32(claimsIdentity.FindFirst(ClaimTypes.Sid).Value);

            }

            var favorites = GetSession(_userId.Value);
            ViewBag.fav = favorites.Count().ToString() ?? "0";

            return View("Favorites", favorites);
        }

        [HttpPost]
        public IActionResult AddToFavorites(int productId)
        {
            if (HttpContext.User.Identity is ClaimsIdentity claimsIdentity)
            {
                _userId = Convert.ToInt32(claimsIdentity.FindFirst(ClaimTypes.Sid).Value);

            }

            var favorites = GetSession(_userId.Value);

            var product = _productService.FindByConditionWithAsNoTracking(productId, true);

            if (favorites.Any(x => x.ProductId == product.ProductId && x.UserId == _userId))
            {
                return Json(new { success = false, message = $"{product.ProductName} ." });
            }
            else
            {
                var favoritesItem = new FavoriteModel(product.ProductId, _userId.Value, product.ProductName);
                favorites.Add(favoritesItem);
                SetSession(favorites);

                return Json(new { success = true, message = $"{product.ProductName} is already in favorites" });
            }
        }


        public IActionResult ClearFavorites()
        {
            if (HttpContext.User.Identity is ClaimsIdentity claimsIdentity)
            {
                _userId = Convert.ToInt32(claimsIdentity.FindFirst(ClaimTypes.Sid).Value);

            }

            var favorites = GetSession(_userId.Value);

            favorites.RemoveAll(f => f.UserId == _userId);

            SetSession(favorites);

            return RedirectToAction(nameof(GetFavorites));
        }

        public IActionResult RemoveFromFavorites(int productId)
        {
            if (HttpContext.User.Identity is ClaimsIdentity claimsIdentity)
            {
                _userId = Convert.ToInt32(claimsIdentity.FindFirst(ClaimTypes.Sid).Value);

            }
            var favorites = GetSession(_userId.Value);

            favorites.RemoveAll(x => x.ProductId.Equals(productId) && x.UserId.Equals(_userId));

            SetSession(favorites);
            return RedirectToAction("GetFavorites");
        }
    }
}
