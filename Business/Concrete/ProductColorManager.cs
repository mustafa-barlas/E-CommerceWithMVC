using System.Security.Cryptography.X509Certificates;
using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;

namespace Business.Concrete;

public class ProductColorManager : IProductColorService
{
    private readonly IProductColorDal _productColorDal;

    public ProductColorManager(IProductColorDal productColorDal)
    {
        _productColorDal = productColorDal;
    }


    public void CreateProductColor(int productId, List<int> selectedColors)
    {
        foreach (var colorId in selectedColors)
        {
            var productColor = new ProductColor
            {
                ProductId = productId,
                ColorId = colorId
            };
            
            _productColorDal.Add(productColor);
        }
    }

    public IList<ProductColor> GetProductColors()
    {
        return _productColorDal.GetAll();
    }
}