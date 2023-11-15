using Core.Entities;

namespace Entities.Concrete;

public class ProductSize : IEntity
{
	public int Id { get; set; }
	public string Name { get; set; }
}