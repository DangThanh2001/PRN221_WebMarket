using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ObjectModel;
using Service;

namespace Web_Market.Pages
{
    
    public class IndexModel : PageModel
    {
        private readonly ProductService _product;
        private readonly ILogger<IndexModel> _logger;

        public List<Product> listProduct { get; set; }

        public IndexModel(ILogger<IndexModel> logger, ProductService product)
        {
            _logger = logger;
            _product = product;
        }
        public void OnGet()
        {
            listProduct = _product.listAllProduct();
        }
    }
}