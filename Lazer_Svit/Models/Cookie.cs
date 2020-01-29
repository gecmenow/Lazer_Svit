using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Lazer_Svit.Models
{
    public class Cookie
    {
        public static void ClearCookie()
        {
            HttpCookie cookie = new HttpCookie("CartCookie")
            {
                Expires = DateTime.Now.AddYears(-1)
            };

            HttpContext.Current.Response.Cookies.Add(cookie);

            HttpCookie quantityCookie = new HttpCookie("QuantityCookie")
            {
                Expires = DateTime.Now.AddYears(-1)
            };

            HttpContext.Current.Response.Cookies.Add(quantityCookie);
        }

        public static void ClearCart()
        {
            HttpCookie cookie = new HttpCookie("CartCookie")
            {
                Expires = DateTime.Now.AddYears(-1)
            };

            HttpContext.Current.Response.Cookies.Add(cookie);

            HttpCookie quantityCookie = new HttpCookie("QuantityCookie")
            {
                Expires = DateTime.Now.AddYears(-1)
            };

            HttpContext.Current.Response.Cookies.Add(quantityCookie);
        }
        
        public static string CheckLanguageCookie()
        {
            var language = "";

            HttpCookie cookie = HttpContext.Current.Request.Cookies["lang"];

            if (cookie != null)
                language = cookie.Value;   // если куки уже установлено, то обновляем значение
            else
                language = "ru";

            return language;
        }
    }
}