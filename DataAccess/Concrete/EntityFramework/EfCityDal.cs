using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework.Contexts;
using Entities.Concrete;

namespace DataAccess.Concrete.EntityFramework;

public class EfCityDal : EfEntityRepositoryBase<City,AlalimContext> , ICityDal
{
    public void Delete(int id)
    {
        using (var context = new AlalimContext())
        {
            var entity = context.Cities.SingleOrDefault(x => x.CityId.Equals(id));
            if (entity.Status)
            {
                entity.Status = false;
                context.SaveChanges();
            }
        }
    }
}