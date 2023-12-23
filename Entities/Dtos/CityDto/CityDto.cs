using Core.Entities;

namespace Entities.Dtos.CityDto;

public record CityDto : IDto
{
    public int CityId { get; set; }

    public string Name { get; set; }

    public bool Status { get; set; }

}