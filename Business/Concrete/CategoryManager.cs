using AutoMapper;
using Business.Abstract;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.Dtos.CategoryDto;

namespace Business.Concrete;

public class CategoryManager : ICategoryService
{
    private readonly ICategoryDal _categoryDal;
    private readonly IMapper _mapper;

    public CategoryManager(ICategoryDal categoryDal, IMapper mapper)
    {
        _categoryDal = categoryDal;
        _mapper = mapper;
    }

    public void CreateCategory(CategoryDtoForInsertion dtoForInsertion)
    {
        Category category = _mapper.Map<Category>(dtoForInsertion);
        _categoryDal.Add(category);
    }

    public void DeleteCategory(Category category)
    {
        var entity = _categoryDal.Get(x => x.Id == category.Id, true);
        _categoryDal.Delete(entity);
    }

    public List<Category> FindAllWithAsNoTracking(bool trackChanges)
    {
        return _categoryDal.FindAllWithAsNoTracking(trackChanges).ToList();

    }

    public Category? FindByConditionWithAsNoTracking(int categoryId, bool trackChanges)
    {
        return _categoryDal.FindByConditionAndAsNoTracking(x => x.Id.Equals(categoryId), trackChanges);
    }

    public IDataResult<List<Category>> GetAll()
    {
        return new SuccessDataResult<List<Category>>(_categoryDal.GetAll());
    }


    public CategoryDtoForUpdate GetOneCategoryForUpdate(int id, bool trackChanges)
    {
        var result = FindByConditionWithAsNoTracking(id, trackChanges);

        CategoryDtoForUpdate categoryDto = _mapper.Map<CategoryDtoForUpdate>(result);
        return categoryDto;
    }

    public void UpdateCategory(CategoryDtoForUpdate dtoForUpdate)
    {
        var result = _mapper.Map<Category>(dtoForUpdate);
        _categoryDal.Update(result);
    }
}