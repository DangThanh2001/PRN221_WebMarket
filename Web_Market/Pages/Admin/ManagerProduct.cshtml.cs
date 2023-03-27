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

        public IActionResult OnGet(int? account)
        {
            try
            {
                var userID = _accountService.GetAccountId();

                listAccount = _accountService.listAllAccount().Where(x => x.Type == 1)
                    .ToList();

                listProduct = _productService.listAllProduct();

                if (account != null)
                {
                    listProduct = listProduct.Where(x => x.AccountId == account).ToList();
                    ViewData["account"] = account;
                }
                return Page();
            }
            catch(Exception ex)
            {
                return Redirect("/Error403");
            }
        }
        public IActionResult OnPostBand(int id)
        {
            try
            {
                _productService.Band(id);
                return new JsonResult(true);
            }catch(Exception ex)
            {
                return new JsonResult(false);
            }
        }
        public IActionResult OnPostActive(int id)
        {
            try
            {
                _productService.Active(id);
                return new JsonResult(true);
            }
            catch (Exception ex)
            {
                return new JsonResult(false);
            }
        }
    }
}
