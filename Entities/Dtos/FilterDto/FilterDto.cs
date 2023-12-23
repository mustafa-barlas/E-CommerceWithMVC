using Core.Entities;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Entities.Dtos.FilterDto;

public class FilterDto : IDto
{
    public string? SearchItem { get; set; }

    public DateTime? BeginDate { get; set; } 

    public DateTime? EndDate { get; set; }

    public int? UserId { get; set; }

    public int? RoleId { get; set; }


}