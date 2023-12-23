using Core.Entities;
using Entities.Concrete.Identity;

namespace Entities.Concrete;

public class Order : IEntity
{
    public int OrderId { get; set; }

    public bool GiftWrap { get; set; }

    public bool? Shipped { get; set; }

    public DateTime OrderedAt { get; set; } = DateTime.Now;

    public bool Cancel { get; set; } = true;

    public int? UserId { get; set; }

    public int? AddressId { get; set; }

    public virtual Address Address { get; set; }

    public virtual User? User { get; set; }

    public virtual ICollection<ProductOrder> ProductOrders { get; set; } = new List<ProductOrder>();

}