using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ObjectModel;
using Service;

namespace Web_Market.Pages
{
    public class My_AdsModel : PageModel
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
        public int maxPage { get; set; }
        public int curPage { get; set; }
        private int itemsInPage { get; set; } = 15;

        [BindProperty]
        public List<Category>? listCategories { get; set; }
        public My_AdsModel(CategoryService category, ProductService productService)
        {
            _categoryService = category;
            _productService = productService;
        }

        public void OnGet(string? product_name_key, string? category_id_key, int currentpage)
        {
            listCategories = _categoryService.GetAllCategory();
            listProduct = _productService.GetAllProduct();
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
                maxPage = listProduct.Count % itemsInPage == 0 ?
                    listProduct.Count / itemsInPage : listProduct.Count / itemsInPage + 1;
            }
            else
            {
                maxPage = 0;
                minPrice = 0;
                maxPrice = 0;
            }
            curPage = currentpage;
        }
    }
}
