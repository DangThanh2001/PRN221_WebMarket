using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ObjectModel;
using Service;

namespace Web_Market.Pages
{
    public class Sign_UpModel : PageModel
    {
        private readonly AccountService _accountService;
        [BindProperty]
        public Account account { get; set; }
        public Sign_UpModel(AccountService loginService)
        {
            _accountService = loginService;
        }
        public void OnGet()
        {
        }
        public IActionResult OnPostRegister(Account account)
        {
            var acc = _accountService.Register(account);
            if (acc > 0)
                return Redirect("Index");
            return Page();
        }
    }
}
