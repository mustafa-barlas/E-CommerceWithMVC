using Business.Abstract;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using WebUI.Models;

namespace WebUI.Controllers
{
    [AllowAnonymous]
    [Authorize]
    public class MyCartController : Controller
    {
        private readonly ICartService _cartService;
        private readonly IProductService _productService;
        private int _colorId;



        public MyCartController(ICartService cartService, IProductService productService)
        {
            _cartService = cartService;
            _productService = productService;
        }

        public IActionResult Index(string returnUrl)
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
            var cart = _cartService.GetCart(HttpContext, userId);


            var cartModel = new CartModel
            {
                Cart = cart,
                ReturnUrl = returnUrl ?? "/"
            };

            return View(cartModel);
        }

        [HttpPost]
        public IActionResult AddToCart(int productId, int quantity)
        {
            var product = _productService.FindByConditionWithAsNoTracking(productId, true);

            if (product != null)
            {

                var userId = HttpContext.User.FindFirst(ClaimTypes.Sid)?.Value;

                quantity += 1;

                _cartService.AddItem(HttpContext, userId, product, quantity);
            }


            return Json(new { success = true, message = $"{product.ProductName}." });
        }



        [HttpPost]
        public IActionResult RemoveFromCart(int productId)
        {
            var product = _productService.FindByConditionWithAsNoTracking(productId, true);

            var userId = HttpContext.User.FindFirst(ClaimTypes.Sid)?.Value;

            _cartService.RemoveItem(HttpContext, userId, product);

            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult DecreaseQuantity(int productId)
        {
            // İlgili ürünün miktarını azaltma işlemini gerçekleştir
            var product = _productService.FindByConditionWithAsNoTracking(productId, false);

            var userId = HttpContext.User.FindFirst(ClaimTypes.Sid)?.Value;

            if (product != null)
            {
                _cartService.DecreaseQuantity(HttpContext, product, userId);
            }

            return RedirectToAction("Index");
        }

        public IActionResult Clear()
        {

            var userId = HttpContext.User.FindFirst(ClaimTypes.Sid)?.Value;

            _cartService.Clear(HttpContext, userId);

            return RedirectToAction("Index");
        }

    }


}
