using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ObjectModel;
using Service;
using System.Xml;

namespace Web_Market.Pages
{
    public class EditProductModel : PageModel
    {
        private readonly CategoryService _categoryService;
        private readonly ProductService _productService;
        private readonly CompanyService _companyService;

        public EditProductModel(CategoryService category, ProductService productService, CompanyService companyService)
        {
            _categoryService = category;
            _productService = productService;
            _companyService = companyService;
        }

        [BindProperty]
        public Product Product { get; set; } = default!;

        [BindProperty]
        public List<String> SelectedCategories { get; set; }
        public List<Company> companies { get; set; } = default!;
        public List<Category> categories { get; set; } = default!;
        public void OnGet(int id)
        {
            Product = _productService.GetProductWithId(id);
            companies = _companyService.GetAllCompany().ToList();
            categories = _categoryService.GetAllCategory().ToList();
            SelectedCategories = Product.ProductCategory.Split(';').ToList();
        }

        
        public async Task<IActionResult> OnPostAsync(Product pro)
        {
            string cate = "";
            for(int i = 0; i < SelectedCategories.Count; i++)
            {
                cate += SelectedCategories[i] + ";";
            }
            pro.ProductCategory = cate.Substring(0, cate.Length - 1);

            _productService.UpdateCategory(pro);

            return RedirectToPage("./Index");
        }
    }
}
