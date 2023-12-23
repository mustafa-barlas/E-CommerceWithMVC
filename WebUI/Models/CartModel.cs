using Business.Abstract;
using Entities.Concrete;

namespace WebUI.Models;

public class CartModel 
{
    private readonly IProductService _productService;

    public Cart Cart { get; set; } // IoC
    public string ReturnUrl { get; set; } = "/";

    public CartModel(IProductService productService, Cart cartService)
    {
        _productService = productService ?? throw new ArgumentNullException(nameof(productService));
        Cart = cartService ?? throw new ArgumentNullException(nameof(cartService));
    }

    public CartModel()
    {
        
    }

    public void OnGet(string returnUrl)
    {
        ReturnUrl = returnUrl ?? "/";
        //Cart = HttpContext.Session.GetJson<Cart>("cart") ?? new Cart();
    }

    

}