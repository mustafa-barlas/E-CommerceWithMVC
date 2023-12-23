using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Security.Claims;

namespace WebUI.Controllers
{
    [AllowAnonymous]
    [Authorize]
    public class OrderController : Controller
    {
        private readonly IOrderService _orderService;
        private readonly ICartService _cartService;
        private readonly IAddressService _addressService;
        string userId = null;

        public OrderController(IOrderService orderService, IAddressService addressService, ICartService cartService)
        {
            _orderService = orderService;
            _addressService = addressService;
            _cartService = cartService;
        }

        public IActionResult Index()
        {


            if (HttpContext.User.Identity is ClaimsIdentity claimsIdentity)
            {
                var userIdClaim = claimsIdentity.FindFirst(ClaimTypes.Sid);

                if (userIdClaim != null)
                {
                    userId = userIdClaim.Value;

                }

            }


            var result = _orderService.GetOrdersWithDetail(Convert.ToInt32(userId)).ToList();
            return View(result);
        }


        [HttpGet]
        public IActionResult Checkout()
        {
            TempData["address"] = "Please fill the form.";
            ViewBag.Adr = GetAddressesList();

            return View(new Order());  // burası çok önemli
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Checkout([FromForm] Order order)
        {

            if (HttpContext.User.Identity is ClaimsIdentity claimsIdentity)
            {
                var userIdClaim = claimsIdentity.FindFirst(ClaimTypes.Sid);

                if (userIdClaim != null)
                {
                    userId = userIdClaim.Value;


                }

            }

            //_cart.ProductOrder.ToArray();

            var result = _cartService.GetCart(HttpContext, userId);

            order.UserId = Convert.ToInt32(userId);

            order.ProductOrders = result.ProductOrders.ToArray();  // burası önemli

            if (result is not null)
            {
                order.Shipped = false;


                _orderService.SaveOrder(order);
                _cartService.Clear(HttpContext, userId);

            }


            return RedirectToPage("/CompleteMessage", new { OrderId = order.OrderId });

        }


        public SelectList GetAddressesList()
        {

            if (HttpContext.User.Identity is ClaimsIdentity claimsIdentity)
            {
                var userIdClaim = claimsIdentity.FindFirst(ClaimTypes.Sid);

                if (userIdClaim != null)
                {
                    userId = userIdClaim.Value;


                }

            }

            var result = _addressService.GetAddressWitDetails(Convert.ToInt32(userId)).ToList();
            return new SelectList(result, "AddressId", "Title", "1");
        }

        [HttpPost]
        public IActionResult Cancel([FromForm] int id)
        {
            _orderService.Cancel(id);

            return RedirectToAction("Index");
        }
    }
}
