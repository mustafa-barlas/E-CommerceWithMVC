using Business.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
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
        public IActionResult Complete([FromForm ] int id)
        {
            _orderService.Complete(id);

            return RedirectToAction("Index");
        }
    }
}
