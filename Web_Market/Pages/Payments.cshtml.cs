using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ObjectModel;
using Service;
using System.Net.Mail;
using System.Net;
using System.Text.Json;
using DocumentFormat.OpenXml.Wordprocessing;

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
			account = _accountService.GetAccountById(UserId);
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
			string? address, int[]? arrayId, int[]? quantity,bool? sendOTP, string? otpUserInput)
		{
           // if (Common.checkStringEmpty(new string[]
           //{
           //     fname, lname, address,
           //}))
           // {
           //     ViewData["error"] = "u must do another";
           //     return Page();
           // }
           // if (arrayId.Length == 0 || arrayId == null)
           // {
           //     ViewData["error"] = "u must do another";
           //     return Page();
           // }

            if (sendOTP is not null && sendOTP == true)
            {
                var accId = _accountService.GetAccountId();
                Account acc = _accountService.GetAccountById(int.Parse(accId));

                Random random = new Random();
                string result = "";
                for (int i = 0; i < 6; i++)
                {
                    int randomNumber = random.Next(97, 123); // Sinh số ngẫu nhiên từ 97 đến 122, tương ứng với các kí tự từ 'a' tới 'z' trong bảng mã ASCII
                    result += Convert.ToChar(randomNumber);
                }
                string contentmail = "Mã xác thực OTP của bạn là: " + result;
                Response.Cookies.Append("otp", result);
                CookieOptions cookieOptions = new CookieOptions();
                cookieOptions.Expires = DateTimeOffset.Now.AddSeconds(120);// 30s
                Response.Cookies.Append("otp", result, cookieOptions);


                var t = SendEmailAsync(acc.Email, "Mã xác thực đơn đặt hàng của bạn", contentmail);
                return RedirectToPage("/Payments");
            }
            else
            {
                var accId = _accountService.GetAccountId();
                string otpUserCookies = Request.Cookies["otp"];
                string das = otpUserInput;
                if (otpUserCookies.Equals(otpUserInput, StringComparison.OrdinalIgnoreCase))
                {
                    _orderService.AddOrderCheckout(fname, lname, address,
                        arrayId, quantity, accId);
                    return RedirectToPage("/OrderDetail");
                }
                else
                {
                    ViewData["notifycationFailOtp"] = "OTP incorrect, please input again!";
                    return RedirectToPage("/Payments");
                }
            }
            
		}

        public async Task<bool> SendEmailAsync(string recipient, string subject, string body)
        {
            using (var client = new SmtpClient("smtp.gmail.com", 587))
            {
                client.EnableSsl = true;
                client.Credentials = new NetworkCredential("traicvhe153014@fpt.edu.vn", "0362351671");

                var message = new MailMessage
                {
                    From = new MailAddress("traicvhe153014@fpt.edu.vn"),
                    To = { recipient },
                    Subject = subject,
                    Body = body
                };  
                message.BodyEncoding = System.Text.Encoding.UTF8;
                message.SubjectEncoding = System.Text.Encoding.UTF8;
                message.IsBodyHtml = true;
                message.ReplyToList.Add(new MailAddress("traicvhe153014@fpt.edu.vn"));
                message.Sender = new MailAddress("traicvhe153014@fpt.edu.vn");

                try
                {
                    await client.SendMailAsync(message);
                    return true;
                }
                catch (SmtpException ex)
                {
                    // Lỗi xảy ra khi gửi email
                    Console.WriteLine("Error: " + ex.Message);
                    return false;
                }
            }
        }

    }
}
