using DocumentFormat.OpenXml.InkML;
using DocumentFormat.OpenXml.VariantTypes;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.Caching.Memory;
using ObjectModel;
using Service;

namespace Web_Market.Pages
{
    public class MyCartModel : PageModel
    {
        private readonly CartService _cartService;
        private readonly AccountService _accountService;
        private readonly ProductService _productService;
        public MyCartModel(CartService cartService, AccountService accountService, ProductService productService)
        {
            _cartService = cartService;
            _accountService = accountService;
            _productService = productService;
        }
        public Card card { get; set; }
        [BindProperty]
        public List<Product> product { get; set; }
        private int UserId;

        public void OnGet()
        {
            UserId = int.Parse(_accountService.GetAccountId());
            card = _cartService.GetCard(UserId);
            if(card == null)
            {
                card = new Card();
                card.UserID = UserId;
                _cartService.AddToCart(card);
            }
            if (card.ProductIdAndQuantity !=null)
            {
                var idandQuantity = card.ProductIdAndQuantity.Split(';').ToList();

                idandQuantity.ForEach(x =>
                {
                    var productId = x.Split("@").ToList();
                    var pro = _productService.GetProductWithId(int.Parse(productId[0]));
                    pro.Quantity = int.Parse(productId[1]);
                    product.Add(pro);
                });
            }
        }
        public IActionResult OnPostAddToCart(int id)
        {
            var stringId = ";" + id + "@" + 1;

            if (card.ProductIdAndQuantity != null)
            {
                card.ProductIdAndQuantity += stringId;
            }
            else
            {
                card.ProductIdAndQuantity += stringId.Trim(';');
            }
            
            return new JsonResult(card);
        }
    }
}
