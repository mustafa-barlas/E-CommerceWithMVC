using Core.DataAccess;
using Entities.Concrete;
using Entities.Dtos.ReportDto;

namespace DataAccess.Abstract;

public interface IProductOrderDal : IEntityRepository<ProductOrder>
{
    IQueryable<ReportDto> GetProductOrderForReport();


}