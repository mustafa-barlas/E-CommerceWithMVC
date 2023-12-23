using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using Business.Abstract;
using Entities.Concrete.Identity;

namespace WebUI.Components;

public class CartSummaryViewComponent : ViewComponent
{
    private readonly ICartService _cartService;

    public CartSummaryViewComponent(ICartService cartService)
    {
        _cartService = cartService;
    }

    public string Invoke()
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

        return cart.ProductOrders.Count().ToString() ?? "0";
    }
    
}