using Core.Entities;

namespace Entities.Dtos.CategoryDto;

public record class CategoryDto : IEntity
{
    public int Id { get; init ; }

    public string Name { get; init; }

    public string Description { get; init; }

    public string ImageUrl { get; set; }
}