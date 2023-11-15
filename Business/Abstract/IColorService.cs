using Entities.Concrete;

namespace Business.Abstract;

public interface IColorService
{
	void Add(Color color);
	void Update(Color color);
	void Delete(Color color);

	List<Color> FindAllWithAsNoTracking(bool trackChanges);

	Color? FindByConditionWithAsNoTracking(int colorId, bool trackChanges);

	//ColorDtoForUpdate GetOneColorForUpdate(int id, bool trackChanges);
    IList<Color> GetAll();
}