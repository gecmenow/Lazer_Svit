using Lazer_Svit.Models;
using Lazer_Svit.Models.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Lazer_Svit.Controllers
{
    public class AdminDataController : Controller
    {
        DatabaseContext _db = new DatabaseContext();

        // GET: AdminData
        public ActionResult Index()
        {
            Category category = new Category();
            ViewBag.Category = category.GetCategories();

            return View();
        }

        [HttpPost]
        public ActionResult Login(string oldLogin, string newLogin)
        {
            Category category = new Category();
            ViewBag.Category = category.GetCategories();

            var data = (from entry in _db.AdminDB
                       where entry.Name == oldLogin
                       select entry).First();

            if (data != null)
                data.Name = newLogin;

            return View("Index");
        }

        [HttpPost]
        public ActionResult Password(string oldPass, string newPass)
        {
            Category category = new Category();
            ViewBag.Category = category.GetCategories();

            var data = (from entry in _db.AdminDB
                        where entry.Password == oldPass
                        select entry).First();

            if (data != null)
                data.Name = newPass;

            return View("Index");
        }
    }
}