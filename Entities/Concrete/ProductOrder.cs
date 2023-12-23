using Core.Entities;

namespace Entities.Concrete;

public class ProductOrder : IEntity
{

    public int Quantity { get; set; }

    public int? OrderID { get; set; }

    public int? ProductID { get; set; }

    public Order Order { get; set; }

    public Product Product { get; set; }

}
