using Lazer_Svit.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Lazer_Svit.Controllers
{
    public class ClearCookieController : Controller
    {
        // GET: ClearCookie
        public ActionResult Index()
        {
            Category category = new Category();
            ViewBag.Category = category.GetCategories();

            var data = category.GetCategories();

            ViewBag.ActiveHome = "nav__link--current";

            Cookie.ClearCart();

            return Redirect(Url.Content("~/"));
        }
    }
}