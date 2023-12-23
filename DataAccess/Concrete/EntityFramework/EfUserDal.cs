using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework.Contexts;
using Entities.Concrete;
using Entities.Concrete.Identity;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Concrete.EntityFramework;

public class EfUserDal : EfEntityRepositoryBase<User, AlalimContext>, IUserDal
{
    public IQueryable<User> GetUsers()
    {
        List<User> users;

        using (var context = new AlalimContext())
        {
            users = context.Users
                .Include(x => x.Role)
                .ToList();
        }

        return users?.AsQueryable() ?? Enumerable.Empty<User>().AsQueryable();
    }

}