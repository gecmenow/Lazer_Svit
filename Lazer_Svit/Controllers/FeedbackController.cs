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
    public class FeedbackController : Controller
    {
        // GET: Feedback
        public ActionResult Index()
        {
            Feedback feedback = new Feedback();

            var data = feedback.GetFeedbacks();

            Category category = new Category();
            ViewBag.Category = category.GetCategories();

            ViewBag.ActiveFeedback = "nav__link--current";

            return View(data);
        }

        [HttpPost]
        public ActionResult Index(string name, string email, int rate, string message)
        {
            Feedback feedback = new Feedback();

            feedback.AddFeedback(name, email, rate, message);

            Category category = new Category();
            ViewBag.Category = category.GetCategories();

            ViewBag.ActiveFeedback = "nav__link--current";

            var data = feedback.GetFeedbacks();

            return View(data);
        }
    }
}