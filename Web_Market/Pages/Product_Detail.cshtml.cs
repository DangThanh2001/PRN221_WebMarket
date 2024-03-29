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
		public Product? product { get; set; }
		[BindProperty]
		public Company? companyName { get; set; }
		[BindProperty]
		public List<Category>? listCategory { get; set; }
		public List<string> image_cut { get; set; }
		public Product_DetailModel(Product_DetailService product_Detail)
        {
            _product_DetailService = product_Detail;
        }
        public void OnGet(int id)
        {

            product = _product_DetailService.GetProductById(id);

            string cate_notcut = product.ProductCategory;
            var cate_cut = cate_notcut.Split(';').ToList();
            listCategory = new List<Category>();
            foreach(var o in cate_cut)
            {
                Category? c = _product_DetailService.getAllCategory()
                    .FirstOrDefault(x => x.CategoryId == int.Parse(o));
                if(c != null)
                {
                    listCategory.Add(c);
                }
			}
            companyName = _product_DetailService.getCompanyById(product.CompanyId);

            string image_notcut = product.Image;
            image_cut = image_notcut.Split(';').ToList();
            Console.WriteLine(image_cut[0]);
        }

    }
}
