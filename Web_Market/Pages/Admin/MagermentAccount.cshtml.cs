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
            account = _accountService.listAllAccount().Where(x => x.Type == 1 || x.Type == 2).ToList();
        }
        public IActionResult OnPostBand(int id)
        {
           var check =  _accountService.DeleteAccount(id);
            if(check > 0)
            {
                return new JsonResult(true);
            }
            return new JsonResult(false);
        }
        public IActionResult OnPostActive(int id)
        {
            var check = _accountService.Active(id);
            if (check > 0)
            {
                return new JsonResult(true);
            }
            return new JsonResult(false);
        }
    }
}
