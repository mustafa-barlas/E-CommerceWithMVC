using Entities.Concrete;
using Entities.Concrete.Identity;

namespace DataAccess.Extensions;

public static class OrderExtensions
{


    public static IQueryable<City> FilteredByCityId(this IQueryable<City> cities, int? cityId)
    {
        if (cityId != null)
        {
            return cities.Where(x => x.CityId.Equals(cityId));
        }
        return cities;
    }

    public static IQueryable<Category> FilteredByCategoryId(this IQueryable<Category> categories, int? categoryId)
    {
        if (categoryId != null)
        {
            return categories.Where(x => x.Id.Equals(categoryId));
        }
        return categories;
    }

    public static IQueryable<User> FilteredByUserId(this IQueryable<User> users, int? userId)
    {
        if (userId != null)
        {
            return users.Where(x => x.Id.Equals(userId));
        }
        return users;
    }

    

}
