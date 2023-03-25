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
            product = new List<Product>();
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
        public IActionResult OnPostAddToCart(int id, int quan)
        {
            UserId = int.Parse(_accountService.GetAccountId());
            var stringId = id + "@" + 1;
            card = _cartService.GetCard(UserId);
            if (card == null)
            {
                card = new Card();
                card.UserID = UserId;
                _cartService.AddToCart(card);
            }
            if (card.ProductIdAndQuantity != null)
            {
                List<string> listproduct = new List<string>();
                var checkCotain = card.ProductIdAndQuantity.Split(";").ToList();
                checkCotain.ForEach(x =>
                {
                    if (x.Split("@")[0].Equals(id.ToString()))
                    {
                        int quatiy = int.Parse(x.Split("@")[1]) + 1;
                        card.ProductIdAndQuantity.Split(";").ToList().Remove(x);
                        stringId = id + "@" + quatiy;
                        listproduct.Add(stringId);
                    }
                    else
                    {
                        listproduct.Add(x);
                        listproduct.Add(stringId);
                    }
                });
                card.ProductIdAndQuantity = String.Join(";", listproduct);
            }
            else
            {
                card.ProductIdAndQuantity += stringId;
            }
            var message = _cartService.Update(card);
            return new JsonResult(message);
        }
    }
}
