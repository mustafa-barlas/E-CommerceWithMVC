using Entities.Concrete;

namespace Business.Abstract;

public interface IProductSizeService
{
	void Add(ProductSize productSize);

	void Update(ProductSize productSize);

	void Delete(ProductSize productSize);

	List<ProductSize> FindAllWithAsNoTracking(bool trackChanges);

	ProductSize? FindByConditionWithAsNoTracking(int productSizeId, bool trackChanges);

	//ProductSizeDtoForUpdate GetOneColorForUpdate(int id, bool trackChanges);
}