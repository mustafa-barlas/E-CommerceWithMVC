using Core.Entities;

namespace Entities.Concrete;

public class Category : IEntity
{
    public int Id { get; set; }

    public string Name { get; set; }

    public string? Description { get; set; }

    public string? ImageUrl { get; set; }

    public bool Status { get; set; } = true;

    public virtual ICollection<Product> Products { get; set; } = new List<Product>();

}