namespace JulianPerrottName.Areas.Home.Controllers
{
    using System.Web.Mvc;

    public class ErrorController : Controller
    {
        public ActionResult Error404()
        {
            return this.View();
        }
    }
}