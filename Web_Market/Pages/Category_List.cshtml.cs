using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ObjectModel;
using Service;
using static Microsoft.Extensions.Logging.EventSource.LoggingEventSource;

namespace Web_Market.Pages
{
	public class Category_ListModel : PageModel
	{
		private readonly CategoryService _categoryService;
		[BindProperty]
		public Category _category { get; set; }

		[BindProperty]
		public List<Category>? listCategories { get; set; }
		public Category_ListModel(CategoryService category, ProductService productService)
		{
			_categoryService = category;
		}

		public void OnGet(string? category_name_key)
		{
			listCategories = _categoryService.GetAllCategory();
			if (!string.IsNullOrWhiteSpace(category_name_key) && !string.IsNullOrEmpty(category_name_key))
			{
				listCategories = listCategories.Where(x => x.CategoryName
				.ToLower().Contains(category_name_key.ToLower().Trim())
				).ToList();
			}
			

			ViewData["search"] = category_name_key;

		}
	}
}
