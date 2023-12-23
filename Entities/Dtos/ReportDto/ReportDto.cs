using Core.Entities;

namespace Entities.Dtos.ReportDto;

public record ReportDto : IDto
{

    public string? ProductName { get; set; } = string.Empty;

    public decimal? Price { get; set; }

    public string? ImageUrl { get; set; }

    public string? ShowCase { get; set; }

    public DateTime? OrderedAtDate { get; set; }

    public string? Shipped { get; set; }

    public string? UserName { get; set; }

    public string? ColorName { get; set; }

    public string? CategoryName { get; set; }

    public string? CityName { get; set; }

    public string? RoleName { get; set; }

    public int? UserId { get; set; }

    public int? RoleId { get; set; }


}