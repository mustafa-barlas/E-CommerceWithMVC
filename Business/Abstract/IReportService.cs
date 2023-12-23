using Entities.Dtos.FilterDto;
using Entities.Dtos.ReportDto;

namespace Business.Abstract;

public interface IReportService
{
    List<ReportDto> GetReportList(FilterDto? filter = null);

}