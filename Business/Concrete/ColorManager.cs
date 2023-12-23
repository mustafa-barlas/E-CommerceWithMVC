using AutoMapper;
using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.Dtos.ColorDto;

namespace Business.Concrete;

public class ColorManager : IColorService
{
    private readonly IColorDal _colorDal;
    private readonly IMapper _mapper;

    public ColorManager(IColorDal colorDal, IMapper mapper)
    {
        _colorDal = colorDal;
        _mapper = mapper;
    }

    public void Add(ColorDto colorDto)
    {
        var color = _mapper.Map<Color>(colorDto);
        _colorDal.Add(color);
    }

    public void Update(ColorDto colorDto)
    {
        var color = _mapper.Map<Color>(colorDto);
        _colorDal.Update(color);
    }

    public void Delete(Color color)
    {
        _colorDal.Delete(color);
    }

    public List<Color> FindAllWithAsNoTracking(bool trackChanges)
    {
        return _colorDal.FindAllWithAsNoTracking(trackChanges).ToList();

    }

    public List<Color> GetActiveColors()
    {
        return FindAllWithAsNoTracking(true).Where(x => x.Status == true).ToList();
    }

    public Color? FindByConditionWithAsNoTracking(int colorId, bool trackChanges)
    {
        return _colorDal.FindByConditionAndAsNoTracking(x => x.Id.Equals(colorId), trackChanges);
    }

    public ColorDto GetOneColorForUpdate(int id, bool trackChanges)
    {
        var result = FindByConditionWithAsNoTracking(id, trackChanges);

        var colorDto = _mapper.Map<ColorDto>(result);

        return colorDto;
    }
}