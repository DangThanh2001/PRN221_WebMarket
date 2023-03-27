using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ObjectModel;
using Service;

namespace Web_Market.Pages.Admin
{
    public class MagermentAccountModel : PageModel
    {
        private readonly AccountService _accountService;
        public MagermentAccountModel(AccountService accountService)
        {
            _accountService = accountService;
        }
        public List<Account> account { get; set; }
        public void OnGet()
        {
            account = _accountService.listAllAccount();
        }
    }
}
