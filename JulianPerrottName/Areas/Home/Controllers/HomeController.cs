namespace JulianPerrottName.Areas.Home.Controllers
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Web.Mvc;
    using JulianPerrottName.Areas.Home.Models;
    using JulianPerrottName.Models;
    using JulianPerrottName.Repository;

    public class HomeController : Controller
    {
        private readonly IBlogRepository blogRepository;
        private readonly IFeedReader feedReader;
        private readonly IPageRepository pageRepository;

        public HomeController(IBlogRepository blogRepository, IFeedReader feedReader, IPageRepository pageRepository)
        {
            this.blogRepository = blogRepository;
            this.feedReader = feedReader;
            this.pageRepository = pageRepository;
        }

        public ActionResult Index()
        {
            return this.View();
        }

        public ActionResult BlogSummary()
        {
            var items = this.blogRepository.GetRecentBlogPosts();
            return this.View("_BlogSummary", items);
        }

        public ActionResult ProjectSummary()
        {
            var items = this.pageRepository.GetRecentPagePosts()
                .Select(p => p as SummaryBase)
                .ToList();

            if (items.Count < 4)
            {
                items.AddRange(this.blogRepository.GetRecentBlogPosts());
                items = items.Take(4).ToList();
            };
            return this.View("_ProjectSummary", items);
        }

        public ActionResult Events()
        {
            var model = new FeedTabViewModel()
            {
                LinkText = "See more events at Lanyrd...",
                LinkUrl = "http://lanyrd.com/topics/software-development",
                Items = this.feedReader.LoadFeed(@"http://lanyrd.com/topics/software-development/feed/").Take(50).ToList()
            };

            return this.View("_FeedTab", model);
        }

        public ActionResult News()
        {
            var model = new FeedTabViewModel()
            {
                LinkText = "Read more stories at Y Combinator..",
                LinkUrl = "https://news.ycombinator.com",
                Items = this.feedReader.LoadRss(@"https://news.ycombinator.com/rss").Take(50).ToList()
            };

            return this.View("_FeedTab", model);
        }
    }
}