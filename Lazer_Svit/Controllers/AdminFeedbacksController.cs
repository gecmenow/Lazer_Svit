using Lazer_Svit.Models;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Lazer_Svit.Controllers
{
    public class AdminFeedbacksController : Controller
    {
        // GET: AdminComment
        public ActionResult Index(int? page)
        {
            Category category = new Category();
            ViewBag.Category = category.GetCategories();

            Feedback feedback = new Feedback();
            var data = feedback.GetFeedbacks();

            int pageSize = 10;
            int pageNumber = (page ?? 1);

            return View(data.ToPagedList(pageNumber, pageSize));
        }

        public ActionResult DeleteFeedback(int id)
        {
            Feedback feedback = new Feedback();
            feedback.DeleteFeedback(id);

            var data = feedback.GetFeedbacks();

            return PartialView(data);
        }
    }
}