using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ObjectModel;
using Service;
using System.Text.Json;

namespace Web_Market.Pages
{
    public class PaymentsModel : PageModel
    {
		private readonly CartService _cartService;
		private readonly AccountService _accountService;
		private readonly ProductService _productService;
		private readonly OrderService _orderService;
		public PaymentsModel(CartService cartService, AccountService accountService, ProductService productService, OrderService orderService)
		{
			_cartService = cartService;
			_accountService = accountService;
			_productService = productService;
			_orderService = orderService;
		}
		public Card card { get; set; }
		[BindProperty]
		public List<Product> product { get; set; }
		private int UserId;
        public Account account { get; set; }
		public void OnGet()
        {
			UserId = int.Parse(_accountService.GetAccountId());
			account = _accountService.GetAccountWithId(UserId);
			card = _cartService.GetCard(UserId);
			if (card == null)
			{
				card = new Card();
				card.UserID = UserId;
				_cartService.AddToCart(card);
			}
			if (card.ProductIdAndQuantity != null)
			{
				var idandQuantity = card.ProductIdAndQuantity.Split(';').ToList();
				product = new List<Product>();
				idandQuantity.ForEach(x =>
				{
					var productId = x.Split("@").ToList();
					var pro = _productService.GetProductWithId(int.Parse(productId[0]));
					pro.Quantity = int.Parse(productId[1]);
					product.Add(pro);

				});
			}
		}

        public IActionResult OnPost(string? fname, string? lname,
            string? address, int[]? arrayId, int[]? quantity)
        {
            if (Common.checkStringEmpty(new string[]
            {
                fname, lname, address,
            }))
            {
                ViewData["error"] = "u must do another";
                return Page();
            }
            if (arrayId.Length == 0 || arrayId == null)
            {
                ViewData["error"] = "u must do another";
                return Page();
            }
            var accId = _accountService.GetAccountId();
            _orderService.AddOrderCheckout(fname, lname, address,
                arrayId, quantity, accId);
            return Page();
        }
    }
}
