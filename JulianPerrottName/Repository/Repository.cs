﻿namespace JulianPerrottName.Repository
{
    using System.Collections.Generic;
    using System.Reflection;
    using System.ServiceModel.Syndication;
    using JulianPerrottName.Cache;
    using JulianPerrottName.Models;

    public class Repository : Cache, IBlogRepository, IFeedReader
    {
        private const string SITE = "http://www.codesin.net";

        public List<BlogPostSummary> GetRecentBlogPosts()
        {
            return this.GetUsingCacheKey<List<BlogPostSummary>>(
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
    }
}