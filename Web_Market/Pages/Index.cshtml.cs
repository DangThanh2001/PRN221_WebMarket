using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.IdentityModel.Tokens;
using ObjectModel;
using Service;

namespace Web_Market.Pages
{

    public class IndexModel : PageModel
    {
        private readonly ProductService _product;
        private readonly CategoryService _category;
        private readonly CompanyService _company;
        private readonly AccountService _accountService;

        private readonly ILogger<IndexModel> _logger;

        public List<Product> listProduct { get; set; }
        public List<Category> listCategories { get; set; }
        public List<Company> listCompanies { get; set; }
        private int itemsInPage { get; set; } = 6;
        public int maxPage { get; set; }
        public int curPage { get; set; }

        public IndexModel(ILogger<IndexModel> logger, ProductService product, CategoryService category, CompanyService company)
        {
            _logger = logger;
            _product = product;
            _category = category;
            _company = company;
        }


        public void OnGet(string? keyword, int? category, int? company, int currentPage)
        {
            listProduct = _product.listAllProduct().OrderByDescending(x => x.ImportDay).Take(itemsInPage).ToList();
            listCategories = _category.GetAllCategory();
            listCompanies = _company.GetAllCompany();
            if (!string.IsNullOrWhiteSpace(keyword) && !string.IsNullOrEmpty(keyword))
            {
                listProduct = listProduct.Where(x => x.ProductName
                .ToLower().Contains(keyword.ToLower().Trim())
                ).ToList();
            }
            if (category != null)
            {
                listProduct = listProduct.Where(x => x.ProductCategory
                .ToLower().Contains(category + "")
                ).ToList();
            }
            if (company != null)
            {
                listProduct = listProduct.Where(x => x.CompanyId == company).ToList();
            }

            maxPage = listProduct.Count % itemsInPage == 0 ?
                listProduct.Count / itemsInPage :
                listProduct.Count / itemsInPage + 1;
            curPage = currentPage;
            listProduct = listProduct
                .Skip(currentPage * itemsInPage)
                .Take(itemsInPage).ToList();
            ViewData["keyword"] = keyword;
            ViewData["category"] = category;
            ViewData["company"] = company;
        }
    }
}