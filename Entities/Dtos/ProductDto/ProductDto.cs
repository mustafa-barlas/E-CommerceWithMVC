using Core.Entities;

namespace Entities.Dtos.ProductDto;

public record ProductDto : IDto
{
    public int ProductId { get; init; }

    public string ProductName { get; init; }

    public bool Status { get; init; }

    public string? Description { get; init; }

    public decimal? Price { get; init; }

    public string? Summary { get; init; }

    public string ImageUrl { get; set; }

    public int? CategoryId { get; init; }

    public int? ColorId { get; init; }

}