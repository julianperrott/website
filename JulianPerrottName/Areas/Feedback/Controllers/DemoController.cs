using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using JulianPerrottName.Areas.Feedback.Models;

namespace JulianPerrottName.Areas.Feedback.Controllers
{
    public class DemoController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
    }
}