using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebUI.Infrastructure.Extensions;

namespace WebUI.Pages
{
    public class CartModel : PageModel
    {
        private readonly IProductService _productService;

        public Cart Cart { get; set; } // IoC
        public string ReturnUrl { get; set; } = "/";

        public CartModel(IProductService productService, Cart _cartService)
        {
            _productService = productService;
            Cart = _cartService;
        }


        public void OnGet(string returnUrl)
        {
            ReturnUrl = returnUrl ?? "/";
            //Cart = HttpContext.Session.GetJson<Cart>("cart") ?? new Cart();
        }

        public IActionResult OnPost(int productId, string returnUrl)
        {
            Product? product = _productService
                .FindByConditionWithAsNoTracking(productId, false);

            if (product is not null)
            {
                //Cart = HttpContext.Session.GetJson<Cart>("cart") ?? new Cart();
                Cart.AddItem(product, 1);
                //HttpContext.Session.SetJson<Cart>("cart",Cart);
            }
            return RedirectToPage(new { returnUrl = returnUrl }); // returnUrl
        }

        public IActionResult OnPostRemove(int id, string returnUrl)
        {
            //Cart = HttpContext.Session.GetJson<Cart>("cart") ?? new Cart();
            Cart.RemoveLine(Cart.Lines.First(cl => cl.Product.ProductId.Equals(id)).Product);
            //HttpContext.Session.SetJson<Cart>("cart",Cart);
            return Page();
        }
    }
}
