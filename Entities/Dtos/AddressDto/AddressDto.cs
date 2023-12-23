using Core.Entities;

namespace Entities.Dtos.AddressDto;

public record AddressDto : IEntity
{
    public int AddressId { get; set; }

    public string? Title { get; set; }

    public string? FirstName { get; set; }

    public string? LastName { get; set; }

    public string? PhoneNumber { get; set; }

    public string? District { get; set; }

    public string? Street { get; set; }

    public string? DetailedAddress { get; set; }

    public int? UserId { get; set; }

    public int? CityId { get; set; } 

}