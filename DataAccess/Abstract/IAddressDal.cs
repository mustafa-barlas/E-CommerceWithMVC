using Core.DataAccess;
using Entities.Concrete;

namespace DataAccess.Abstract;

public interface IAddressDal : IEntityRepository<Address>
{
    IQueryable<Address> GetAddresses(int userId);

}