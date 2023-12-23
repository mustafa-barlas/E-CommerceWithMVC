using Core.Entities;
using Entities.Concrete.Identity;

namespace Entities.Concrete;

public class Address : IEntity
{
    public int AddressId { get; set; }

    public string Title { get; set; }

    public string PhoneNumber { get; set; }

    public string District { get; set; }

    public string Street { get; set; }

    public string DetailedAddress { get; set; }

    public int? UserId { get; set; }

    public virtual User? User { get; set; }

    public int? CityId { get; set; } 

    public virtual City? City { get; set; }
}