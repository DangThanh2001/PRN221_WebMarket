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
		private readonly ProductService _productService;

		[BindProperty]
		public Category _category { get; set; }
		public Product? product { get; set; }
		public List<Product> listProduct { get; set; }


		[BindProperty]
		public List<Category>? listCategories { get; set; }
		public Category_ListModel(CategoryService category, ProductService productService)
		{
			_categoryService = category;
			_productService = productService;
		}

		public void OnGet(string? product_name_key, string? category_id_key)
		{
			listCategories = _categoryService.GetAllCategory();
			listProduct = _productService.GetAllProduct();
			if (!string.IsNullOrWhiteSpace(product_name_key) && !string.IsNullOrEmpty(product_name_key))
			{
				listProduct = listProduct.Where(x => x.ProductName
				.ToLower().Contains(product_name_key.ToLower().Trim())
				).ToList();
			}
			if (!string.IsNullOrWhiteSpace("3") && !string.IsNullOrEmpty("3"))
			{
				listProduct = listProduct.Where(x => x.ProductCategory
				.ToLower().Contains("3".ToLower().Trim())
				).ToList();
			}

			ViewData["search"] = product_name_key;

		}
	}
}
