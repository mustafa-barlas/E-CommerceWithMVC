using Core.Entities;
using Entities.Concrete;

namespace Entities.Dtos.ProductDto;

public record class ProductDto : IEntity
{
    public int ProductId { get; init; }

    public string ProductName { get; init; }

    public string? Description { get; init; }

    public decimal? Price { get; init; }

    public string? Summary { get; init; }

    public string ImageUrl { get; set; }

    public int? CategoryId { get; init; }

    public List<int> SelectedColors { get; set; } = new List<int>();

    public List<ProductColor> ProductColors { get; set; } = new List<ProductColor>();
}