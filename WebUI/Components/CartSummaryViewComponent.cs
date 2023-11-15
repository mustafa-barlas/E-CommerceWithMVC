using Entities.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace WebUI.Components;

public class CartSummaryViewComponent : ViewComponent
{
    private readonly Cart _cart;

    public CartSummaryViewComponent(Cart cart)
    {
        _cart = cart;
    }

    public string Invoke()
    {
        return  _cart.Lines.Count().ToString();  
       
    }
}