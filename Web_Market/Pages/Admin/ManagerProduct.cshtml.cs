using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ObjectModel;
using Service;

namespace Web_Market.Pages.Admin
{
    public class ManagerProductModel : PageModel
    {
        private readonly CategoryService _categoryService;
        private readonly ProductService _productService;
        private readonly AccountService _accountService;

        public ManagerProductModel(CategoryService categoryService, ProductService productService, AccountService accountService)
        {
            _categoryService = categoryService;
            _productService = productService;
            _accountService = accountService;
        }

        public List<Product> listProduct;
        public List<Product> listProductTop;
        public List<Account> listAccount;

        public void OnGet(int? account)
        {
            var userID = _accountService.GetAccountId();
            listProductTop = _productService.GetAllProducByUserId()
                .Where(x => x.AccountId == int.Parse(userID) && x.IsActive == true && x.IsDelete == false)
                .OrderByDescending(x => x.BuyTimes)
                .Take(5)
                .ToList();

            listAccount = _accountService.listAllAccount()
                .ToList();

            listProduct = _productService.GetAllProduct();
            
            if(account != null)
            {
                listProduct = listProduct.Where(x => x.AccountId == account).ToList();
                ViewData["account"] = account;
            }
        }
    }
}
