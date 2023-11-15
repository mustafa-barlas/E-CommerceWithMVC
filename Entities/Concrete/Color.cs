using Core.Entities;

namespace Entities.Concrete;

public class Color : IEntity
{
	public int Id { get; set; }
	public string Name { get; set; }

    public virtual ICollection<ProductColor> ProductColors { get; set; } = new List<ProductColor>();
}