using Entities.Concrete;
using Microsoft.AspNetCore.Http;
namespace Business.Abstract;

public interface ICartService
{
    Cart GetCart(HttpContext context, string userId);
    
    void DecreaseQuantity(HttpContext context, Product product, string userId);

    void AddItem(HttpContext context, string userId, Product product, int quantity);

    void RemoveItem(HttpContext context, string userId, Product product);

    void Clear(HttpContext context, string userId);
}

