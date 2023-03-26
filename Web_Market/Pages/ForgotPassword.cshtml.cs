using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ObjectModel;
using Service;

namespace Web_Market.Pages
{
    public class ForgotPasswordModel : PageModel
    {
        private readonly AccountService _accountService;
        private string emailTochange;
        public ForgotPasswordModel(AccountService loginService)
        {
            _accountService = loginService;
        }
        public void OnGet()
        {
        }
        public IActionResult OnPostForgot(string email)
        {
            try
            {
                var acc = _accountService.GetAccountByEmail(email);
                if (acc != null)
                {
                    ViewData["change"] = "Ok";
                    ViewData["email"] = email;
                    return Page();
                }
                else
                {
                    ViewData["error"] = "Not Found!";
                    return Page();
                }
            }
            catch (Exception ex)
            {
                ViewData["error"] = "Login false";
                return Page();
            }
        }
        public IActionResult OnPostChangePassword(string email, string password)
        {
            var change = _accountService.ChangePass(email, password);
            ViewData["success"] = "Change Pass Done!";
            return Page();
        }
    }
}
