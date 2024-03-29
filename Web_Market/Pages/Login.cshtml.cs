using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ObjectModel;
using Service;

namespace Web_Market.Pages.Login
{
    public class LoginModel : PageModel
    {
		private readonly AccountService _accountService;
        [BindProperty]
        public Account account { get; set; }
        public LoginModel(AccountService loginService)
        {
            _accountService = loginService;
		}
		public void OnGet()
        {
        }
        public IActionResult OnPostLogin(Account account)
        {
            try
            {
                var acc = _accountService.Login(account.Email, account.Password);
                if (acc)
                {
                   return Redirect("Index");
                }
                else
                {
                    ViewData["error"] = "Login false";
                    return Page();
                }
            }catch(Exception ex)
            {
                ViewData["error"] = "Login false";
                return Page();
            }
        }
        public IActionResult OnGetSignOut()
        {
            _accountService.SignOut();
            return Redirect("Index");
        }
    }
}
