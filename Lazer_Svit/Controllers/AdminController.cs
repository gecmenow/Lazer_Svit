using Lazer_Svit.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Lazer_Svit.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin
        public ActionResult Index()
        {
            Category category = new Category();
            ViewBag.Category = category.GetCategories();

            Admin admin = new Admin();

            if (admin.IsAdmin() == true)
                return RedirectToRoute("admin/userWorks");

            else
                return RedirectToAction("LogIn");
        }

        public ActionResult LogIn()
        {
            Category category = new Category();
            ViewBag.Category = category.GetCategories();

            return View("LogIn");
        }

        [HttpPost]
        public ActionResult LogIn(string name, string password)
        {
            Category category = new Category();
            ViewBag.Category = category.GetCategories();

            Admin admin = new Admin();
            bool status = admin.LogIn(name, password);

            if (status == true)
                return RedirectToAction("Index");
            else
                return View("LogIn");
        }

        public ActionResult ChangeData()
        {
            Category category = new Category();
            ViewBag.Category = category.GetCategories();

            return View();
        }

        [HttpPost]
        public ActionResult ChangeLogin(string oldName, string newName)
        {
            Category category = new Category();
            ViewBag.Category = category.GetCategories();

            Admin admin = new Admin();
            bool status = admin.ChangeLogin(oldName, newName);

            if (status == true)
                return View("Index");
            else
                return View("ChangeData");
        }

        [HttpPost]
        public ActionResult ChangePassword(string oldPass, string newPass)
        {
            Category category = new Category();
            ViewBag.Category = category.GetCategories();

            Admin admin = new Admin();
            bool status = admin.ChangePassword(oldPass, newPass);

            if (status == true)
                return View("Index");
            else
                return View("ChangeData");
        }
    }
}