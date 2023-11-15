using Core.Entities;

namespace Entities.Concrete;

public class ProductColor : IEntity
{
    public int ProductId { get; set; }

    public int ColorId { get; set; }

    public virtual Product Product { get; set; }

    public virtual Color Color { get; set; }

}