using Core.Utilities.Results;
using Entities.Concrete;
using Entities.Dtos.ProductDto;
using Entities.RequestParameters;

namespace Business.Abstract;

public interface IProductService
{
    List<Product> FindAllWithAsNoTracking(bool trackChanges);
    
    IQueryable<Product> GetProducts();

    IQueryable<Product> GetLatestProducts(int n);

    IQueryable<Product> GetProductsWithDetails(ProductRequestParameters requestParameters);

    IDataResult<List<Product>> GetAll();

    Product? FindByConditionWithAsNoTracking(int productId, bool trackChanges);

    ProductDtoForUpdate GetOneProductForUpdate(int id, bool trackChanges);

    void CreateProduct(ProductDtoForInsertion forInsertion, List<int> selectedColors);
    void UpdateProduct(ProductDtoForUpdate forUpdate);
    void DeleteProduct(Product product);
}
