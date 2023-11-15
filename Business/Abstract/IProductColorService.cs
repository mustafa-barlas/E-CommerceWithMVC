using Entities.Concrete;

namespace Business.Abstract;

public interface IProductColorService
{
    void CreateProductColor(int productId, List<int> selectedColors);

    IList<ProductColor> GetProductColors();
}