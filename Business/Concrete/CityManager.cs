using AutoMapper;
using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.Dtos.CityDto;

namespace Business.Concrete;

public class CityManager : ICityService
{
    private readonly ICityDal _cityDal;
    private readonly IMapper _mapper;

    public CityManager(ICityDal cityDal, IMapper mapper)
    {
        _cityDal = cityDal;
        _mapper = mapper;
    }

    public List<City> GetAllCities()
    {
        return _cityDal.GetAll().ToList();
    }

    public List<City> GetActiveCities()
    {
        return _cityDal.GetAll().Where(x => x.Status == true).ToList();
    }

    public City? GetCity(int id)
    {
        return _cityDal.FindByConditionAndAsNoTracking(x => x.CityId.Equals(id), true);
    }

    public void Add(CityDtoForInsertion cityDtoForInsertion)
    {
        City? city = _mapper.Map<City>(cityDtoForInsertion);
        _cityDal.Add(city);
    }

    public void Update(CityDtoForUpdate cityDtoForUpdate)
    {
        var city = _mapper.Map<City>(cityDtoForUpdate);
        _cityDal.Update(city);
    }

    public CityDtoForUpdate GetOneCityForUpdate(int id)
    {
        var result = GetCity(id);

        CityDtoForUpdate? forUpdate = _mapper.Map<CityDtoForUpdate>(result);

        return forUpdate;

    }

    public void Delete(City city)
    {
        _cityDal.Delete(city);
    }
}