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
        public void OnGet()
        {
            try
            {
                var id = _accountService.GetAccountId();
                account = _accountService.GetAccountById(int.Parse(id));
            }
            catch (Exception ex)
            {

            }
        }
        public IActionResult OnPostUpdateProfile(Account accountAdd)
        {
            var id = _accountService.GetAccountId();
            account = _accountService.GetAccountById(int.Parse(id));
            accountAdd.Balance = account.Balance;
            accountAdd.Password = account.Password;
            var update = _accountService.UpdateAccount(accountAdd);
            if (update > 0)
                return Redirect("profile_settings");
            return Page();
        }
    }
}
