using Business.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace WebUI.Components;

public class CategoryMenuViewComponent : ViewComponent
{
	private readonly ICategoryService _categoryService;

	public CategoryMenuViewComponent(ICategoryService categoryService)
	{
		_categoryService = categoryService;
	}

	public IViewComponentResult Invoke()
	{
		var result = _categoryService.GetAll().Data;
		return View(result);
	}
}