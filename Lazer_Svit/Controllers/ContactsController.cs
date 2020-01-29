using Lazer_Svit.Filters;
using Lazer_Svit.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Lazer_Svit.Controllers
{
    [Culture]
    public class ContactsController : Controller
    {
        // GET: Contacts
        public ActionResult Index()
        {
            Category category = new Category();
            ViewBag.Category = category.GetCategories();

            ViewBag.ActiveContact = "nav__link--current";

            return View();
        }
        
    }
}