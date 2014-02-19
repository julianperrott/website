namespace JulianPerrottName.Repository
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Blog;
    using JulianPerrottName.Models;

    public class BlogReader : IBlogRepository
    {
        private const string SITE = "http://www.codesin.net";

        public List<BlogSummary> GetRecentBlogPosts()
        {
            var context = new BlogEngineEntities();
            be_Blogs blog = GetBlog(context);

            var posts = context.be_Posts
                .Where(p => p.BlogID == blog.BlogId)
                .Where(p => !p.IsDeleted)
                .Where(p => p.IsPublished.Value)
                .OrderByDescending(p => p.DateCreated)
                .Take(20)
                .ToList();

            return this.ReadRecentBlogPosts(posts);
        }

        public List<BlogSummary> ReadRecentBlogPosts(IEnumerable<be_Posts> posts)
        {
            return posts.Select(p => new BlogSummary()
            {
                Description = p.Description,
                PostId = p.PostID,
                Image = this.GetImageFromPost(p.PostContent),
                Title = p.Title,
                DateCreated=p.DateCreated,
                Slug=p.Slug
            })
            .ToList();
        }

        public string GetImageFromPost(string postContent)
        {
            string image = HtmlParser.GetFirstTagAttribute(postContent, "img", "src");

            if (string.IsNullOrEmpty(image)) 
            {
                return string.Empty; 
            }

            if (image.Contains("www")) 
            {
                return image; 
            }

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

            return this.ReadRecentPagePosts(posts);
        }

        public List<PageSummary> ReadRecentPagePosts(IEnumerable<be_Pages> posts)
        {
            return posts.Select(p => new PageSummary()
            {
                Description = p.Description,
                PageId = p.PageID,
                Image = this.GetImageFromPost(p.PageContent),
                Title = p.Title
            })
            .ToList();
        }

        public BlogPageViewModel GetPost(Guid postId)
        {
            var context = new BlogEngineEntities();

            BlogPageViewModel model = new BlogPageViewModel()
            {
                Post = context.be_Posts
                .Where(p => p.PostID == postId)
                .FirstOrDefault()
            };

            model.Tags = context.be_PostTag.Where(p => p.PostID == postId).ToList();
            model.Comments = context.be_PostComment.Where(p => p.PostID == postId).ToList();

            return model;
        }

        private static be_Blogs GetBlog(BlogEngineEntities context)
        {
            be_Blogs blog = context.be_Blogs.Where(b => b.BlogName == "Primary").FirstOrDefault();
            if (blog == null) 
            { 
                throw new Exception("Failed to find 'Primary' Blog.");
            }

            return blog;
        }
    }
}