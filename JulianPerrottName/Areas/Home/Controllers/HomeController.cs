namespace JulianPerrottName.Areas.Home.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Net;
    using System.ServiceModel.Syndication;
    using System.Web.Mvc;
    using System.Xml;
    using JulianPerrottName.Areas.Home.Models;
    using JulianPerrottName.Models;
    using JulianPerrottName.Repository;

    public class HomeController : Controller
    {
        private readonly IBlogRepository blogRepository;
        private readonly IFeedReader feedReader;

        public HomeController(IBlogRepository blogRepository,IFeedReader feedReader)
        {
            this.blogRepository = blogRepository;
            this.feedReader = feedReader;
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

        public ActionResult Events()
        {
            var model = new FeedTabViewModel()
            {
                LinkText = "See more events at Lanyrd...",
                LinkUrl = "http://lanyrd.com/topics/software-development",
                Items = feedReader.LoadFeed(@"http://lanyrd.com/topics/software-development/feed/").Take(3).ToList()
            };

            return this.View("_FeedTab", model);
        }

        public ActionResult News()
        {
            var model = new FeedTabViewModel()
            {
                LinkText = "Read more stories at Y Combinator..",
                LinkUrl = "https://news.ycombinator.com",
                Items = feedReader.LoadFeed(@"https://news.ycombinator.com/rss").Take(3).ToList()
            };

            return this.View("_FeedTab", model);
        }
    }
}