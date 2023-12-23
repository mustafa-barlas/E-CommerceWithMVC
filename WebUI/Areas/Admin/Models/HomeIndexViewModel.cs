using Entities.Dtos.FilterDto;
using Entities.Dtos.ReportDto;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace WebUI.Areas.Admin.Models;

public class HomeIndexViewModel
{
    public List<ReportDto> ReportDtos { get; set; }

    public FilterDto FilterDto { get; set; }

    public SelectList UserSelectList { get; set; }

    public SelectList RoleSelectList { get; set; }

}