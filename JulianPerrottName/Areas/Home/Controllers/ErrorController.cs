﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace JulianPerrottName.Areas.Home.Controllers
{
    public class ErrorController : Controller
    {
        //
        // GET: /Home/Error/

        public ActionResult Error404()
        {
            return View();
        }

    }
}
