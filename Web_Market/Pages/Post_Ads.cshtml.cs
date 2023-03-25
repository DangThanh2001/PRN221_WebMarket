using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ObjectModel;
using Service;

namespace Web_Market.Pages
{
    public class Post_AdsModel : PageModel
    {
        private readonly ProductService _productService;
        private readonly CategoryService _categoryService;
        public List<Category>? listCategory { get; set; }
        public Post_AdsModel(ProductService product,CategoryService categoryService)
        {
            _productService = product;
            _categoryService = categoryService;
        }
        public void OnGet()
        {
            listCategory = new List<Category>();

            listCategory = _categoryService.GetAllCategory();
        }
        public void OnPostAddProduct(Product product)
        {
            _productService.AddProduct(product);
        }
    }
}
