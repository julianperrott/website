namespace JulianPerrottName.Areas.Home.Controllers
{
    using System.Collections.Generic;
    using System.Web.Mvc;
    using Blog;
    using JulianPerrottName.Areas.Home.Models;
    using JulianPerrottName.Repository;

    public class BlogController : Controller
    {
        private readonly IBlogRepository blogRepository;

        public BlogController(IBlogRepository blogRepository)
        {
            this.blogRepository = blogRepository;
        }

        public ActionResult Index()
        {
            return this.View();
        }

        public ActionResult Timeline()
        {
            return this.View();
        }

        public ActionResult Post(System.Guid postId)
        {
            var model = this.blogRepository.GetPost(postId);
            return this.View(model);
        }
    }
}