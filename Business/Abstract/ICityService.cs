using Entities.Concrete;
using Entities.Dtos.CityDto;

namespace Business.Abstract;

public interface ICityService
{
    List<City> GetAllCities ();

    List<City> GetActiveCities();

    City? GetCity (int id);

    CityDtoForUpdate GetOneCityForUpdate(int id);

    void Add (CityDtoForInsertion cityDtoForInsertion);

    void Update (CityDtoForUpdate cityDtoForUpdate);

    void Delete (City city);
}