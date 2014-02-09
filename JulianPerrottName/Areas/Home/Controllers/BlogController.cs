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
            PageViewModel model = new PageViewModel()
            {
                Post = this.blogRepository.GetPost(postId),
                Comments = new List<be_PostComment>(),
                Tags = new List<be_PostTag>()
            };

            return this.View(model);
        }
    }
}