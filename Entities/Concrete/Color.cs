using Core.Entities;

namespace Entities.Concrete;

public class Color : IEntity
{
	public int Id { get; set; }

	public string Name { get; set; }

    public bool Status { get; set; } = true;

    public virtual ICollection<Product> Products { get; set; } = new List<Product>();
}