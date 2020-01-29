using Lazer_Svit.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Lazer_Svit.Controllers
{
    [Culture]
    public class CategoryController : Controller
    {
        // GET: Categories
        public ActionResult Index(string urlName)
        {
            ViewBag.ActiveCategory = "nav__link--current";

            return RedirectToAction("Index", "Products", new { urlName } );
        }
    }
}