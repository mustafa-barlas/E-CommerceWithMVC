using Business.Abstract;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin,User")]
    public class OrderController : Controller
    {
        private readonly IOrderService _orderService;

        public OrderController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        public IActionResult Index()
        {
            var result = _orderService.GetOrdersWithDetail();
            return View(result);
        }


        [HttpPost]
        public IActionResult Complete([FromForm] int id)
        {
            _orderService.Complete(id);

            return RedirectToAction("Index");
        }


        [HttpPost]
        public IActionResult Cancel([FromForm] int id)
        {
            _orderService.Cancel(id);

            return RedirectToAction("Index");
        }

        
    }
}
