using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ObjectModel;
using Service;

namespace Web_Market.Pages
{
    public class Product_DetailModel : PageModel
    {
        private readonly Product_DetailService _product_DetailService;
        [BindProperty]
        public Product product { get; set; }
        public string categoryname = "";
        public string companyname = "";
        public List<string> image_cut;

        public Product_DetailModel(Product_DetailService product_Detail)
        {
            _product_DetailService = product_Detail;
        }
        public void OnGet(string? productId)
        {

            product = _product_DetailService.GetProductById(int.Parse(productId));

            string cate_notcut = product.ProductCategory;
            var cate_cut = cate_notcut.Split(';').ToList();

            categoryname = String.Join("; ", _product_DetailService.GetCategoryName(cate_cut));

            int companyId = product.CompanyId;
            companyname = String.Join("; ", _product_DetailService.GetCompanyName(companyId));

            string image_notcut = product.Image;
            image_cut = image_notcut.Split(';').ToList();
            Console.WriteLine(image_cut[0]);
        }

    }
}
