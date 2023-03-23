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
		private int itemsInPage { get; set; } = 6;
		public int maxPage { get; set; }
		public int curPage { get; set; }

		public IndexModel(ILogger<IndexModel> logger, ProductService product)
		{
			_logger = logger;
			_product = product;
		}
		public void OnGet(string? keyword, int currentPage)
		{
			listProduct = _product.listAllProduct();
			maxPage = listProduct.Count % itemsInPage == 0 ?
				listProduct.Count / itemsInPage :
				listProduct.Count / itemsInPage + 1;
			if (!string.IsNullOrWhiteSpace(keyword) && !string.IsNullOrEmpty(keyword))
			{
				listProduct = listProduct.Where(x => x.ProductName
				.ToLower().Contains(keyword.ToLower().Trim())
				).ToList();
			}
			if (currentPage > 1)
			{
				currentPage = currentPage - 1;
			}
			curPage = currentPage;
			listProduct = listProduct
				.Skip(currentPage * itemsInPage)
				.Take(itemsInPage).ToList();
			ViewData["keyword"] = keyword;
		}
	}
}