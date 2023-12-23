using Core.Utilities.Results;
using Entities.Concrete;
using Entities.Dtos.AddressDto;

namespace Business.Abstract;

public interface IAddressService
{
    List<Address> FindAllWithAsNoTracking(bool trackChanges);

    IQueryable<Address> GetAddressWitDetails(int userId);

    IDataResult<List<Address>> GetAll();

    Address? FindByConditionWithAsNoTracking(int addressId, bool trackChanges);

    AddressDtoForUpdate GetOneAddressForUpdate(int id, bool trackChanges);

    void CreateAddress(AddressDtoForInsertion forInsertion);
    void UpdateAddress(AddressDtoForUpdate forUpdate);
    void DeleteAddress(Address address);
}