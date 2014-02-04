namespace JulianPerrottName.Areas.Home.Controllers
{
    using System.Web.Mvc;

    public class BlogController : Controller
    {
        public ActionResult Index()
        {
            return this.View();
        }

        public ActionResult Timeline()
        {
            return this.View();
        }

        public ActionResult Post()
        {
            return this.View();
        }
    }
}