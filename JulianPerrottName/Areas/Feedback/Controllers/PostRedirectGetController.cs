using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using JulianPerrottName.Areas.Feedback.Models;


namespace JulianPerrottName.Areas.Feedback.Controllers
{
    public class PostRedirectGetController : Controller
    {
        TaskService taskService = new TaskService();
        DateTime startTime = DateTime.Now;

        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public RedirectToRouteResult RunSynchronousTask()
        {
            TaskResult result= taskService.StartSynchronousTask();
            this.Session["TaskResult"] = result;
            return this.RedirectToAction("Completed");
        }

        [HttpGet]
        public ActionResult Completed()
        {
            return View(this.Session["TaskResult"] as TaskResult);
        }
    }
}
