namespace JulianPerrottName.Repository
{
    using System.Collections.Generic;
    using JulianPerrottName.Models;

    public interface IBlogRepository
    {
        List<BlogPostSummary> GetRecentBlogPosts();
    }
}