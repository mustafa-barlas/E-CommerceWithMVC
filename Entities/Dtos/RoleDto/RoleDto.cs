using Core.Entities;

namespace Entities.Dtos.RoleDto;

public record RoleDto : IDto
{
    public int Id { get; set; }

    public string Name { get; set; }
}