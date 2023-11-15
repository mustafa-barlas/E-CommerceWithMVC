using AutoMapper;
using Business.Abstract;
using Core.Utilities.Results;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework.Contexts;
using Entities.Concrete;
using Entities.Dtos.ProductDto;
using Entities.RequestParameters;

namespace Business.Concrete;

public class ProductManager : IProductService
{

    private readonly IProductDal _productDal;
    private readonly IProductColorService _productColorService;
    private readonly IMapper _mapper;

    public ProductManager(IProductDal productDal, IMapper mapper, IProductColorService productColorService)
    {
        _productDal = productDal;
        _mapper = mapper;
        _productColorService = productColorService;
    }



    public void CreateProduct(ProductDtoForInsertion productDtoForInsertion, List<int> selectedColors)
    {
        //Product product = new Product()
        //{
        //    ProductName = productDto.ProductName,
        //    Price = productDto.Price,
        //    CategoryId = productDto.CategoryId,
        //    Description = productDto.Description,
        //};

        Product product = _mapper.Map<Product>(productDtoForInsertion);
        _productDal.Add(product);
         // var result = _productDal.GetAll().Last();
        _productColorService.CreateProductColor(product.ProductId,selectedColors);

    }


    public void UpdateProduct(ProductDtoForUpdate forUpdate)
    {
        //var entity = _manager.GetProductOneProduct(productDtoForUpdate.ProductId,true);

        //result.ProductName = productDtoForUpdate.ProductName;
        //result.Description = productDtoForUpdate.Description;
        //result.Price = productDtoForUpdate.Price;
        //result.CategoryId = productDtoForUpdate.CategoryId;

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
        var entity = _productDal.Get(x => x.ProductId == product.ProductId, true);
        _productDal.Delete(entity);
    }

    public IQueryable<Product> GetProducts()
    {
        return _productDal.GetProducts();
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

    public IDataResult<List<Product>> GetAll()
    {
        return new SuccessDataResult<List<Product>>(_productDal.GetAll());
    }

    public List<Product> FindAllWithAsNoTracking(bool trackChanges)
    {
        return _productDal.FindAllWithAsNoTracking(trackChanges).ToList();
    }

    public Product? FindByConditionWithAsNoTracking(int productId, bool trackChanges)
    {
        return _productDal.FindByConditionAndAsNoTracking(x => x.ProductId == productId, trackChanges);
    }

    //public Product? GetOneProduct(int productId, bool trackChanges)
    //{
    //    return _productDal.FindByConditionAndAsNoTracking(x => x.ProductId.Equals(productId), trackChanges);
    //}

}