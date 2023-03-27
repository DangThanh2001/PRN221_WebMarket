using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ObjectModel;
using Service;

namespace Web_Market.Pages.Admin
{
    public class profilesettingModel : PageModel
    {
        private readonly AccountService _accountService;
        public profilesettingModel(AccountService accountService)
        {
            _accountService = accountService;
        }
        public Account account { get; set; }
        public void OnGet(int id)
        {
            try
            {
                account = _accountService.GetAccountById(id);
            }
            catch (Exception ex)
            {

            }
        }
        public IActionResult OnPostUpdateProfile(Account accountAdd)
        {
            account = _accountService.GetAccountById(accountAdd.AccountId);
            accountAdd.Balance = account.Balance;
            accountAdd.Password = account.Password;
            var update = _accountService.UpdateAccount(accountAdd);
            if (update > 0)
                return Redirect("MagermentAccount");
            return Page();
        }
    }
}
