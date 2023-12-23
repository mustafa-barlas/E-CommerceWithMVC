using Core.Entities;

namespace Entities.Concrete;

public class Product : IEntity
{
    public int ProductId { get; set; }

    public string ProductName { get; set; } = string.Empty;

    public string? Description { get; set; }

    public decimal? Price { get; set; }

    public string? Summary { get; set; } = string.Empty;

    public string? ImageUrl { get; set; }

    public bool ShowCase { get; set; }

    public int? CategoryId { get; set; } // foreign key

    public bool Status { get; set; } = true;

    public int? ColorId { get; set; }

    public virtual Color Color { get; set; }

    public virtual Category? Category { get; set; } // navigation property

    public virtual ICollection<ProductOrder> ProductOrders { get; set; } = new List<ProductOrder>();


}