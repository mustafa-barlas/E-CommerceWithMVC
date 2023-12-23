using Entities.Dtos.ReportDto;

namespace WebUI.Models;

public class ReportListViewModel
{
    public IEnumerable<ReportDto> Report { get; set; } = Enumerable.Empty<ReportDto>();
}