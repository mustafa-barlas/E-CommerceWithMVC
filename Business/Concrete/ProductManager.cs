using AutoMapper;
using Business.Abstract;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.Dtos.ProductDto;
using Entities.RequestParameters;

namespace Business.Concrete;

public class ProductManager : IProductService
{

    private readonly IProductDal _productDal;
    private readonly IMapper _mapper;

    public ProductManager(IProductDal productDal, IMapper mapper)
    {
        _productDal = productDal;
        _mapper = mapper;
    }



    public IDataResult<ProductDtoForInsertion> CreateProduct(ProductDtoForInsertion forInsertion)
    {
        var newProduct = _mapper.Map<Product>(forInsertion);
        _productDal.Add(newProduct);
        return new SuccessDataResult<ProductDtoForInsertion>();
    }


    public void UpdateProduct(ProductDtoForUpdate forUpdate)
    {

        var entity = _mapper.Map<Product>(forUpdate);
        _productDal.Update(entity);
    }


    public ProductDtoForUpdate GetOneProductForUpdate(int id, bool trackChanges)
    {
        var result = FindByConditionWithAsNoTracking(id, trackChanges);
        ProductDtoForUpdate? productDto = _mapper.Map<ProductDtoForUpdate>(result);
        return productDto;
    }

    public void DeleteProduct(Product product)
    {
        _productDal.Delete(product);
    }

    public void ChangeStatus(Product product)
    {
        var entity = _productDal.GetProducts().SingleOrDefault(x => x.ProductId.Equals(product.ProductId));
        _productDal.ChangeStatus(entity.ProductId);
    }


    public IQueryable<Product> GetProducts()
    {
        return _productDal.GetProducts();
    }

    public IQueryable<Product> GetActiveProducts()
    {
        return _productDal.GetProducts().Where(x => x.Status == true);
    }

    public IQueryable<Product> GetLatestProducts(int n)
    {
        return _productDal.GetAll()
            .OrderByDescending(x => x.ProductId)
            .Take(n).AsQueryable();
    }

    public IQueryable<Product> GetProductsWithDetails(ProductRequestParameters requestParameters)
    {
        return _productDal.GetProductsWithDetails(requestParameters);
    }


    public List<Product> FindAllWithAsNoTracking(bool trackChanges)
    {
        return _productDal.FindAllWithAsNoTracking(trackChanges).ToList();
    }

    public Product? FindByConditionWithAsNoTracking(int productId, bool trackChanges)
    {
        return _productDal.FindByConditionAndAsNoTracking(x => x.ProductId == productId, trackChanges);
    }


}