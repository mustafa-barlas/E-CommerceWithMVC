using Core.Entities;

namespace Entities.Dtos.ColorDto;

public record ColorDto : IEntity
{
    public int Id { get; set; }
    public string Name { get; set; }
    public bool Status { get; set; }
}