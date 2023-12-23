using Business.Abstract;
using DataAccess.Abstract;
using Entities.Dtos.FilterDto;
using Entities.Dtos.ReportDto;

namespace Business.Concrete;

public class ReportManager : IReportService
{

    private readonly IProductOrderDal _productOrderDal;

    public ReportManager(IProductOrderDal productOrderDal)
    {
        _productOrderDal = productOrderDal;
    }

    public List<ReportDto> GetReportList(FilterDto? filter = null)
    {
        var result = _productOrderDal.GetProductOrderForReport().ToList();

        if (filter != null && !string.IsNullOrWhiteSpace(filter.SearchItem))
        {
            return result
                .Where(x => x.ProductName != null && x.ProductName.ToLower().Contains(filter.SearchItem.ToLower().Trim())).ToList();
        }

        if (filter != null && (filter.BeginDate != null || filter.EndDate != null))
        {
            if (filter.BeginDate != null && filter.EndDate != null)
            {
                return result
                    .Where(x => x.OrderedAtDate >= filter.BeginDate && x.OrderedAtDate <= filter.EndDate)
                    .ToList();
            }
            else if (filter.BeginDate != null)
            {
                return result
                    .Where(x => x.OrderedAtDate >= filter.BeginDate)
                    .ToList();
            }
            else if (filter.EndDate != null)
            {
                return result
                    .Where(x => x.OrderedAtDate <= filter.EndDate)
                    .ToList();
            }

            if (filter != null && filter.UserId != null)
            {
                return result.Where(x => x.UserId.Equals(filter.UserId)).ToList();
            }

            if (filter != null && filter.RoleId != null)
            {
                return result.Where(x => x.RoleId.Equals(filter.RoleId)).ToList();
            }

        }
        return result;
    }


}