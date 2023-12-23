using AutoMapper;
using Business.Abstract;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.Dtos.AddressDto;

namespace Business.Concrete;

public class AddressManager : IAddressService
{
    private readonly IAddressDal _addressDal;
    private readonly IMapper _mapper;

    public AddressManager(IAddressDal addressDal, IMapper mapper)
    {
        _addressDal = addressDal;
        _mapper = mapper;
    }

    public List<Address> FindAllWithAsNoTracking(bool trackChanges)
    {
        return _addressDal.FindAllWithAsNoTracking(trackChanges).ToList();
    }

    public IQueryable<Address> GetAddressWitDetails(int userId)
    {
        return _addressDal.GetAddresses(userId);
    }

    public IDataResult<List<Address>> GetAll()
    {
        return new SuccessDataResult<List<Address>>(_addressDal.GetAll());
    }

    public Address? FindByConditionWithAsNoTracking(int addressId, bool trackChanges)
    {
        return _addressDal.FindByConditionAndAsNoTracking(x => x.AddressId.Equals(addressId), trackChanges);
    }

   
    public void CreateAddress(AddressDtoForInsertion forInsertion)
    {
        Address address = _mapper.Map<Address>(forInsertion);
        _addressDal.Add(address);
    }

    public void UpdateAddress(AddressDtoForUpdate forUpdate)
    {
        Address address = _mapper.Map<Address>(forUpdate);
        _addressDal.Update(address);
    }

    public AddressDtoForUpdate GetOneAddressForUpdate(int id, bool trackChanges)
    {
        var result =  FindByConditionWithAsNoTracking(id, true);

        AddressDtoForUpdate addressDto = _mapper.Map<AddressDtoForUpdate>(result);
        return addressDto;
    }


    public void DeleteAddress(Address address)
    {
        _addressDal.Delete(address);
    }
}