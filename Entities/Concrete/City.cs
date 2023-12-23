using Core.Entities;

namespace Entities.Concrete;

public class City : IEntity
{
    public int CityId { get; set; }

    public string Name { get; set; }

    public bool Status { get; set; } = true;

    public virtual ICollection<Address> Addresses { get; set; } = new List<Address>();
}