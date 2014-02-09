namespace JulianPerrottName.Repository
{
    using System.Collections.Generic;
    using System.Reflection;
    using System.ServiceModel.Syndication;
    using JulianPerrottName.Cache;
    using JulianPerrottName.Models;

    public class Repository : Cache, IBlogRepository, IFeedReader, IPageRepository
    {
        private const string SITE = "http://www.codesin.net";

        public List<BlogSummary> GetRecentBlogPosts()
        {
            return this.GetUsingCacheKey<List<BlogSummary>>(
               MethodBase.GetCurrentMethod().Name,
                () => new BlogReader().GetRecentBlogPosts(),
                CacheForOneHour);
        }

        public List<SyndicationItem> LoadFeed(string url)
        {
            return this.GetUsingCacheKey<List<SyndicationItem>>(
               MethodBase.GetCurrentMethod().Name + "_" + url,
                () => new FeedReader().LoadFeed(url),
                CacheForOneHour);
        }

        public List<PageSummary> GetRecentPagePosts()
        {
            return this.GetUsingCacheKey<List<PageSummary>>(
               MethodBase.GetCurrentMethod().Name,
                () => new BlogReader().GetRecentPagePosts(),
                CacheForOneHour);
        }

        public Blog.be_Posts GetPost(System.Guid postId)
        {
            return new BlogReader().GetPost(postId);
        }
    }
}