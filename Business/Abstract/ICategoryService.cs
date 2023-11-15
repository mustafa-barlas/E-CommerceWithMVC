using Core.Utilities.Results;
using Entities.Concrete;
using Entities.Dtos.CategoryDto;

namespace Business.Abstract;

public interface ICategoryService
{
    List<Category> FindAllWithAsNoTracking(bool trackChanges);

    IDataResult<List<Category>> GetAll();

    Category? FindByConditionWithAsNoTracking(int  categoryId, bool trackChanges);

    CategoryDtoForUpdate GetOneCategoryForUpdate(int id, bool trackChanges);

	void CreateCategory(CategoryDtoForInsertion dtoForInsertion);
	void UpdateCategory(CategoryDtoForUpdate dtoForUpdate);
	void DeleteCategory(Category category);
}
