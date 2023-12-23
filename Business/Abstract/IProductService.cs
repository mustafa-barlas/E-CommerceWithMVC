using Core.Utilities.Results;
using Entities.Concrete;
using Entities.Dtos.ProductDto;
using Entities.RequestParameters;

namespace Business.Abstract;

public interface IProductService
{
    List<Product> FindAllWithAsNoTracking(bool trackChanges);

    IQueryable<Product> GetProducts();

    IQueryable<Product> GetActiveProducts();

    IQueryable<Product> GetLatestProducts(int n);

    IQueryable<Product> GetProductsWithDetails(ProductRequestParameters requestParameters);


    Product? FindByConditionWithAsNoTracking(int productId, bool trackChanges);

    ProductDtoForUpdate GetOneProductForUpdate(int id, bool trackChanges);

    IDataResult<ProductDtoForInsertion> CreateProduct(ProductDtoForInsertion forInsertion);
    void UpdateProduct(ProductDtoForUpdate forUpdate);
    void DeleteProduct(Product product);
    void ChangeStatus(Product product);

}
