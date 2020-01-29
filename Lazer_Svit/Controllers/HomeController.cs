using Lazer_Svit.Filters;
using Lazer_Svit.Models;
using Lazer_Svit.Models.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;

namespace Lazer_Svit.Controllers
{
    [Culture]
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            string str = "safsaf#dididi qwe#andlsfl#hahaha#";
            string happy = Regex.Match(str, @"\#(.*?)\#").Groups[1].Value.ToString();

            Category category = new Category();
            ViewBag.Category = category.GetCategories();

            var data = category.GetCategories();

            ViewBag.ActiveHome = "nav__link--current";
            
            return View();
        }

        public ActionResult Contacts()
        {
            Category category = new Category();
            ViewBag.Category = category.GetCategories();

            ViewBag.Message = "Your contact page.";
            ViewBag.ActiveContact = "nav__link--current";

            return View();
        }

        //model UserWork
        [HttpPost]
        public ActionResult Contacts(string name, string email, string tel, string message, IEnumerable<HttpPostedFileBase> uploads)
        {
            Category category = new Category();
            ViewBag.Category = category.GetCategories();

            ViewBag.Message = "Your contact page.";
            ViewBag.ActiveContact = "nav__link--current";

            UserWork userWork = new UserWork();
            userWork.AddWork(name, email, tel, message, uploads);

            return View();
        }
    }
}