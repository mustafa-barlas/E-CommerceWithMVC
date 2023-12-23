using System.Text.Json.Serialization;
using Entities.Concrete;
using WebUI.Infrastructure.Extensions;

namespace WebUI.Models;

public class SessionCart : Cart
{
    [JsonIgnore]
    public ISession? Session { get; set; }

    public static Cart GetCart(IServiceProvider services)
    {
        ISession? session = services.GetRequiredService<IHttpContextAccessor>()
            .HttpContext?.Session;

        SessionCart cart = session?.GetJson<SessionCart>("cart") ?? new SessionCart();
        cart.Session = session;
        return cart;
    }

    public void AddItem(Product product, int quantity)
    {
        base.AddItem(product, quantity);
        Session?.SetJson<SessionCart>("cart", this);
    }

    public void Clear()
    {

        Session?.Remove("cart");
    }

    public void RemoveLine(Product product)
    {
        Session?.SetJson<SessionCart>("cart", this);
    }
}