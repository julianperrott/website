namespace JulianPerrottName.Areas.Home.Controllers
{
    using System.Collections.Generic;
    using System.Web.Mvc;
    using JulianPerrottName.Models;
    using JulianPerrottName.Repository;

    public class HomeController : Controller
    {
        private IBlogRepository blogRepository;

        public HomeController(IBlogRepository blogRepository)
        {
            this.blogRepository = blogRepository;
        }

        public ActionResult Index()
        {
            return this.View();
        }

        public ActionResult BlogSummary()
        {
            List<BlogPostSummary> blogs = blogRepository.GetRecentBlogPosts();
            return this.View(blogs);
        }
    }
}