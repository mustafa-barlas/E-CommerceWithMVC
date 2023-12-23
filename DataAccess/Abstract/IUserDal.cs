using Core.DataAccess;
using Entities.Concrete.Identity;

namespace DataAccess.Abstract;

public interface IUserDal : IEntityRepository<User>
{
    IQueryable<User> GetUsers();
    
    
}