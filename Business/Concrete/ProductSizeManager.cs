using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;

namespace Business.Concrete;

public class ProductSizeManager : IProductSizeService
{
	private readonly IProductSizeDal _productSizeDal;

	public ProductSizeManager(IProductSizeDal productSizeDal)
	{
		_productSizeDal = productSizeDal;
	}

	public void Add(ProductSize productSize)
	{
		throw new NotImplementedException();
	}

	public void Update(ProductSize productSize)
	{
		throw new NotImplementedException();
	}

	public void Delete(ProductSize productSize)
	{
		throw new NotImplementedException();
	}

	public List<ProductSize> FindAllWithAsNoTracking(bool trackChanges)
	{
		throw new NotImplementedException();
	}

	public ProductSize? FindByConditionWithAsNoTracking(int productSizeId, bool trackChanges)
	{
		throw new NotImplementedException();
	}
}