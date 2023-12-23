using Core.DataAccess;
using Entities.Concrete;
using Entities.RequestParameters;

namespace DataAccess.Abstract;

public interface IProductDal : IEntityRepository<Product>
{
    IQueryable<Product> GetProducts();

    IQueryable<Product> GetProductsWithDetails(ProductRequestParameters requestParameters);

    void ChangeStatus(int id);
}