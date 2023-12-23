using System.ComponentModel;
using Core.Entities;

namespace Entities.Dtos.FilterDto;

public class FilterDtoForView : IDto
{
    [DisplayName("Search Something")]
    public string? SearchItem { get; set; }

    [DisplayName("Start Date")]
    public DateTime? BeginDate { get; set; } 

    [DisplayName("End Date")]
    public DateTime? EndDate { get; set; }

    [DisplayName("Search Something")]
    public int? UserId { get; set; }
}