using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Caching.Memory;
using ObjectModel;

namespace Web_Market.MiddleWare
{
    public class AuthenticationMiddleware
    {
        private readonly RequestDelegate next;
        private readonly ITokenService _tokenService;

        public AuthenticationMiddleware(RequestDelegate next, ITokenService tokenService)
        {
            this.next = next;
            _tokenService = tokenService;
        }

        public async Task Invoke(HttpContext context)
        {
            var cache = context.RequestServices.GetService<IMemoryCache>();
            var token = cache.Get<string>("Token");
            int type = -1;
            // 0 = admin, 1 = mod, 2 = normal
            if (token != null)
            {
                context.Request.Headers.Add("Authorization", "Bearer " + token);
                type = _tokenService.DeserializeToken(token);
            }
            string path = context.Request.Path.ToString().ToLower();
            if (string.IsNullOrEmpty(token) &&
                StaticURL.checkUrlNotLogin(path)
                )
            {
                //await next(context);
                context.Response.Redirect(StaticURL.LOGIN);
            }
            else if (type == 1 &&
                StaticURL.checkUrlNotAdminRole(path)
                )
            {
                context.Response.Redirect(StaticURL.ERROR_403);
            }
            else if (type == 2 &&
                StaticURL.checkUrlNotModRole(path)
                )
            {
                context.Response.Redirect(StaticURL.ERROR_403);
            }
            else
            {
                await next(context);
            }
        }
    }

    public static class StaticURL
    {
        public static readonly string INDEX = "/";
        public static readonly string LOGIN = "/login";
        public static readonly string ADMIN_BASE = "/admin";
        public static readonly string ADMIN_DASHBOARD = "/admin/dashboard";
        public static readonly string ADMIN_POSTADS = "/admin/dashboard";
        public static readonly string FAVORITE = "/favorites";
        public static readonly string MY_ADS = "/my_ads";
        public static readonly string OFFER = "/offer";
        public static readonly string PAYMENTS = "/payments";
        public static readonly string POST_ADS = "/post_ads";
        public static readonly string PRODUCT_DETAIL = "/product_detail";
        public static readonly string PROFILE_SETTING = "/Profile_Settings";
        public static readonly string ERROR_403 = "/Error403";

        private static string[] notLoginUrl =
        {
            ADMIN_BASE,
            ADMIN_DASHBOARD,
            ADMIN_POSTADS,
            PROFILE_SETTING,
            FAVORITE,
            MY_ADS,
            OFFER,
            PAYMENTS,
            POST_ADS,
        };

        private static string[] notAdminRole =
        {
            ADMIN_BASE,
            ADMIN_DASHBOARD,
            ADMIN_POSTADS,
            OFFER,
            PRODUCT_DETAIL,
        };

        private static string[] notModRole =
        {
            ADMIN_BASE,
            ADMIN_DASHBOARD,
            ADMIN_POSTADS,
            OFFER,
            PRODUCT_DETAIL,
        };

        public static bool checkUrlNotLogin(string path)
        {
            foreach (var url in notLoginUrl)
            {
                if (path.Contains(url.ToLower()))
                {
                    return true;
                }
            }
            return false;
        }

        public static bool checkUrlNotAdminRole(string path)
        {
            foreach (var url in notAdminRole)
            {
                if (path.Contains(url.ToLower()))
                {
                    return true;
                }
            }
            return false;
        }

        public static bool checkUrlNotModRole(string path)
        {
            foreach (var url in notModRole)
            {
                if (path.Contains(url.ToLower()))
                {
                    return true;
                }
            }
            return false;
        }
    }
}
