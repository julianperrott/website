namespace JulianPerrottName.Repository
{
    using Blog;
    using JulianPerrottName.Cache;
    using JulianPerrottName.Models;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;

    public class BlogReader:IBlogRepository
    {
        private const string SITE = "http://www.codesin.net";

        public List<PageSummary> GetRecentBlogPosts()
        {
            var context = new BlogEngineEntities();
            be_Blogs blog = GetBlog(context);

            var posts = context.be_Posts
                .Where(p => p.BlogID == blog.BlogId)
                .Where(p => !p.IsDeleted)
                .Where(p => p.IsPublished.Value)
                .OrderByDescending(p => p.DateCreated)
                .Take(3)
                .ToList();

            return ReadRecentBlogPosts(posts);
        }

        private static be_Blogs GetBlog(BlogEngineEntities context)
        {
            be_Blogs blog = context.be_Blogs.Where(b => b.BlogName == "Primary").FirstOrDefault();
            if (blog == null) { throw new Exception("Failed to find 'Primary' Blog."); }
            return blog;
        }

        public List<PageSummary> ReadRecentBlogPosts(IEnumerable<be_Posts> posts)
        {
            return posts.Select(p => new PageSummary()
            {
                Description = p.Description,
                PostID = p.PostID,
                PostRowID = p.PostRowID,
                Image = GetImageFromPost(p.PostContent),
                Title = p.Title
            })
            .ToList();
        }

        public string GetImageFromPost(string postContent)
        {
            string image = HtmlParser.GetFirstTagAttribute(postContent, "img", "src");

            if (string.IsNullOrEmpty(image)) { return string.Empty; }
            if (image.Contains("www")) { return image; }

            image = image.Replace(".axdx", string.Empty);
            image = image.Replace("FILES", "image.axd?picture=");

            return SITE + image;
        }

        public List<PageSummary> GetRecentPagePosts()
        {
            var context = new BlogEngineEntities();
            be_Blogs blog = GetBlog(context);

            var posts = context.be_Pages
                .Where(p => p.BlogID == blog.BlogId)
                .Where(p => !p.IsDeleted)
                .Where(p => p.IsPublished.Value)
                .OrderByDescending(p => p.DateCreated)
                .Take(4)
                .ToList();

            return ReadRecentPagePosts(posts);
        }

        public List<PageSummary> ReadRecentPagePosts(IEnumerable<be_Pages> posts)
        {
            return posts.Select(p => new PageSummary()
            {
                Description = p.Description,
                PostID = p.PageID,
                PostRowID = p.PageRowID,
                Image = GetImageFromPost(p.PageContent),
                Title = p.Title
            })
            .ToList();
        }
    }
}