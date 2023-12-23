using Core.Entities;
using Entities.Concrete;

namespace Entities.Dtos.OrderDto;

public record OrderDto : IEntity
{
    public int? OrderId { get; set; }

    public bool? GiftWrap { get; set; }

    public bool? Shipped { get; set; }

    public DateTime? OrderedAt { get; set; } = DateTime.Now;

    public int? AddressId { get; set; } 

    public int? UserId { get; set; }

    public virtual ICollection<ProductOrder> ProductOrders { get; set; } = new List<ProductOrder>();
}