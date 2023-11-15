using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework.Contexts;
using DataAccess.Extensions;
using Entities.Concrete;
using Entities.RequestParameters;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Concrete.EntityFramework;

public sealed class EfProductDal : EfEntityRepositoryBase<Product, AlalimContext>, IProductDal
{
    public IQueryable<Product> GetProducts()
    {
        IList<Product> products;

        using (var context = new AlalimContext())
        {
            products = context.Products
                .Include(x => x.ProductColors)
                .ThenInclude(x => x.Color)
                .ToList();
        }

        return products.AsQueryable();
    }

    public IQueryable<Product> GetProductsWithDetails(ProductRequestParameters requestParameters)
    {
        IList<Product> products;

        using (var context = new AlalimContext())
        {
            products = context
                .Products
                .FilteredByCategoryId(requestParameters.CategoryId)
                .FilteredBySearchTerm(requestParameters.SearchTerm)
                .FilteredByPrice(requestParameters.MinPrice, requestParameters.MaxPrice, requestParameters.IsValidPrice)
                .ToPaginate(requestParameters.PageNumber, requestParameters.PageSize).ToList();

        }

        return products.AsQueryable();
    }

}