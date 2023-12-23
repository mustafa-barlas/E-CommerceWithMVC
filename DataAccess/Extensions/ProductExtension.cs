using Entities.Concrete;

namespace DataAccess.Extensions;

public static class ProductExtension 
{
    public static IQueryable<Product> FilteredByCategoryId(this IQueryable<Product> products, int? categoryId)
    {
        if (categoryId != null)
        {
            return products.Where(x => x.CategoryId.Equals(categoryId));
        }
        return products;
    }

    public static IQueryable<Product> FilteredBySearchTerm(this IQueryable<Product> products, string? searchTerm)
    {
        if (string.IsNullOrWhiteSpace(searchTerm))
        {
            return products;
        }
        else
        {
            return products.Where(x => x.ProductName.ToLower().Contains(searchTerm.ToLower()));
        }
    }

    public static IQueryable<Product> FilteredByPrice(this IQueryable<Product> products, decimal? minPrice, decimal? maxPrice, bool isValidPrice)
    {
        if (isValidPrice)
        {
            return products.Where(x => x.Price >= minPrice && x.Price <= maxPrice);
        }
        else
        {
            return products;
        }
    }

    public static IQueryable<Product> ToPaginate(this IQueryable<Product> products,
        int pageNumber, int pageSize)
    {
        return products
            .Skip(((pageNumber - 1) * pageSize))
            .Take(pageSize);
    }
}