using Core.Entities;

namespace Entities.Concrete;

public class Tag : IEntity
{
    public int  Id { get; set; }
    public string Name { get; set; }

    public virtual ICollection<ProductTag> ProductTags { get; set; } = new List<ProductTag>();

}