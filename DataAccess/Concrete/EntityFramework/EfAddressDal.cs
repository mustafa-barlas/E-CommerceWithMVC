using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework.Contexts;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Concrete.EntityFramework;

public class EfAddressDal : EfEntityRepositoryBase<Address, AlalimContext>, IAddressDal
{
    public IQueryable<Address> GetAddresses(int userId)
    {
        List<Address> addresses = new List<Address>();

        using (var context = new AlalimContext())
        {
            addresses = context.Addresses
                .Include(x => x.City)
                .Include(x => x.User)
                .Where(x => x.User.Id.Equals(userId))
                .ToList();
        }

        return addresses.AsQueryable();
    }
}