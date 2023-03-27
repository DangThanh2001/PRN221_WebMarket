using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ObjectModel;
using Service;

namespace Web_Market.Pages
{
    public class OrderDetailModel : PageModel
    {
        private readonly CartService _cartService;
        private readonly AccountService _accountService;
        private readonly CategoryService _categoryService;
        private readonly ProductService _productService;
        private readonly OrderService _orderService;

        public List<Order> listOrders { get; set; }

        public OrderDetailModel(CartService cartService, AccountService accountService, CategoryService categoryService, ProductService productService, OrderService orderService)
        {
            _cartService = cartService;
            _accountService = accountService;
            _categoryService = categoryService;
            _productService = productService;
            _orderService = orderService;
        }

        public void OnGet()
        {
            var UserId = int.Parse(_accountService.GetAccountId());
            listOrders = _orderService.GetAllOrder().Where(x => x.AccountId == UserId).ToList();
        }
    }
}
