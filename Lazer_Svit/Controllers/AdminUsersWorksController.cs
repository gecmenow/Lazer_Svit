using Lazer_Svit.Models;
using Lazer_Svit.Models.Database;
using PagedList;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Lazer_Svit.Controllers
{
    public class AdminUsersWorksController : Controller
    {
        // GET: AdminUsersWorks
        public ActionResult Index(int? page)
        {
            Category category = new Category();
            ViewBag.Category = category.GetCategories();

            UserWork userWorks = new UserWork();
           
            var data = userWorks.GetUsersWorks();

            int pageSize = 10;
            int pageNumber = (page ?? 1);

            return View(data.ToPagedList(pageNumber, pageSize));
        }

        public ActionResult DeleteWork(int id)
        {
            UserWork userWorks = new UserWork();
            userWorks.DeleteWork(id);

            var data = userWorks.GetUsersWorks();

            return PartialView(data);
        }

        public ActionResult Download(int id)
        {
            DatabaseContext _db = new DatabaseContext();

            var name = (from entry in _db.UserWorkDB
                       where entry.Id == id
                       select entry.File).First();

            string extension = Path.GetExtension(name);

            extension = extension.Replace(".", "");

            // Путь к файлу
            string file_path = Server.MapPath("~/Content/UsersWorks/" + name);
            // Тип файла - content-type
            string file_type = "application/" + extension;
            // Имя файла - передать в возврат
            return File(file_path, file_type, name);
        }
    }
}