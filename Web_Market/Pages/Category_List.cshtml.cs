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
        public double? minPrice { get; set; }
        public double? maxPrice { get; set; }
		public List<int> quanCategory { get; set; }


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
			ViewData["allP"] = listProduct.Count;
			quanCategory = new List<int>();
            foreach (var o in listCategories)
            {
                int count = listProduct.Where(x => x.ProductCategory
				.Contains(o.CategoryId + "")).ToList().Count;
                quanCategory.Add(count);
            }
            if (!string.IsNullOrWhiteSpace(product_name_key) && !string.IsNullOrEmpty(product_name_key))
			{
				listProduct = listProduct.Where(x => x.ProductName
				.ToLower().Contains(product_name_key.ToLower().Trim())
				).ToList();
			}
			if (!string.IsNullOrWhiteSpace(category_id_key) && !string.IsNullOrEmpty(category_id_key))
			{
				listProduct = listProduct.Where(x => x.ProductCategory
				.ToLower().Contains(category_id_key.ToLower().Trim())
				).ToList();
			}
			if (listProduct.Count > 0)
			{
				minPrice = listProduct.MinBy(x => x.Price).Price;
				maxPrice = listProduct.MaxBy(x => x.Price).Price;
			}
			else
			{
				minPrice = 0;
				maxPrice = 0;
			}
            ViewData["search"] = product_name_key;

		}
	}
}
