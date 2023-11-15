using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace WebUI.Controllers
{
    public class OrderController : Controller
    {
        private readonly IOrderService _orderService;
        private readonly Cart _cart;

        public OrderController(IOrderService orderService, Cart cart)
        {
            _orderService = orderService;
            _cart = cart;
        }

        public ViewResult Checkout() => View(new Order());


        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Checkout([FromForm] Order order)
        {

            //ViewBag.data = order;
            //ViewBag.data2 = _cart.ComputeTotalValue().ToString("C0");

            if (ModelState.IsValid)
            {
                order.Lines = _cart.Lines.ToArray();
                _orderService.SaveOrder(order);
                


                return RedirectToPage("/CompleteMessage", new { OrderId = order.OrderId });

                //_cart.Clear();
            }

            else
            {
                return View();
            }
        }

        
    }
}
