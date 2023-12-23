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
        List<Product> products;

        using (var context = new AlalimContext())
        {
            products = context.Products
                .Include(x => x.Category)
                .Include(x => x.Color).ToList();
        }

        return products?.AsQueryable() ?? Enumerable.Empty<Product>().AsQueryable();
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
                .ToPaginate(requestParameters.PageNumber, requestParameters.PageSize).Where(x => x.Status == true).ToList();

        }

        return products.Where(x => x.Status == true).AsQueryable();
    }

    
    public void ChangeStatus(int id)
    {
        using (var context = new AlalimContext())
        {
            var entity = GetProducts().SingleOrDefault(x => x.ProductId.Equals(id));
            if (entity.Status == true)
            {
                entity.Status = false;
            }

            context.SaveChanges();
        }
    }
}