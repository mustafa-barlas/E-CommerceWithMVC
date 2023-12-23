using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;

namespace Business.Concrete;

public class CartManager : ICartService
{
    public Cart GetCart(HttpContext context, string userId)
    {
        var cartJson = context.Request.Cookies[$"cart_{userId}"];

        if (cartJson != null)
        {
            return JsonConvert.DeserializeObject<Cart>(cartJson);
        }

        return new Cart();
    }

    public void AddItem(HttpContext context, string userId, Product product, int quantity)
    {
        var cart = GetCart(context, userId);

        cart.AddItem(product, quantity);

        context.Response.Cookies.Append($"cart_{userId}", JsonConvert.SerializeObject(cart));
    }

    public void RemoveItem(HttpContext context, string userId, Product product)
    {
        var cart = GetCart(context, userId);

        cart.RemoveLine(product);
        

        context.Response.Cookies.Append($"cart_{userId}", JsonConvert.SerializeObject(cart));
    }

    public void Clear(HttpContext context, string userId)
    {
        var cart = GetCart(context, userId);

        cart.Clear();

        context.Response.Cookies.Append($"cart_{userId}", JsonConvert.SerializeObject(cart));
    }

    public void DecreaseQuantity(HttpContext context, Product product,string userId)
    {
        var cart = GetCart(context, userId);

        var result = cart.ProductOrders.FirstOrDefault(item => item.Product.ProductId == product.ProductId);

        if (result != null)
        {
            if (result.Quantity > 1)
            {
                result.Quantity--;
            }
            else
            {
                // Eğer miktar 1 ise, ürünü tamamen sepetten kaldır
                cart.ProductOrders.Remove(result);
            }

            context.Response.Cookies.Append($"cart_{userId}", JsonConvert.SerializeObject(cart));
        }
    }

}
