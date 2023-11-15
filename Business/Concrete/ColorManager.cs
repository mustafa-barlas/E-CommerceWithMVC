using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;

namespace Business.Concrete;

public class ColorManager : IColorService
{
	private readonly IColorDal _colorDal;

	public ColorManager(IColorDal colorDal)
	{
		_colorDal = colorDal;
	}

	public void Add(Color color)
	{
		throw new NotImplementedException();
	}

	public void Update(Color color)
	{
		throw new NotImplementedException();
	}

	public void Delete(Color color)
	{
		throw new NotImplementedException();
	}

	public List<Color> FindAllWithAsNoTracking(bool trackChanges)
    {
        return _colorDal.GetAll();

    }

	public Color? FindByConditionWithAsNoTracking(int colorId, bool trackChanges)
	{
		throw new NotImplementedException();
	}

    public IList<Color> GetAll()
    {
        return _colorDal.GetAll();
    }
}