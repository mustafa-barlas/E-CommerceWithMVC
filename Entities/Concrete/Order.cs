using Core.Entities;

namespace Entities.Concrete;

public class Order : IEntity
{
    public int OrderId { get; set; }

    public string? Name { get; set; }

    public string? Line1 { get; set; }

    public string? Line2 { get; set; }

    public string? Line3 { get; set; }

    public string? City { get; set; }

    public bool GiftWrap { get; set; }

    public bool? Shipped { get; set; }

    public DateTime OrderedAt { get; set; } = DateTime.Now;

    public virtual ICollection<CartLine> Lines { get; set; } = new List<CartLine>();
}