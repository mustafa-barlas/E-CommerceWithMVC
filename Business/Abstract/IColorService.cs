using Entities.Concrete;
using Entities.Dtos.ColorDto;

namespace Business.Abstract;

public interface IColorService
{
    void Add(ColorDto color);
    void Update(ColorDto color);
    void Delete(Color color);

    List<Color> FindAllWithAsNoTracking(bool trackChanges);

    List<Color> GetActiveColors();

    Color? FindByConditionWithAsNoTracking(int colorId, bool trackChanges);

    ColorDto GetOneColorForUpdate(int id, bool trackChanges);

}