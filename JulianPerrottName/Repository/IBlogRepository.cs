namespace JulianPerrottName.Repository
{
    using System.Collections.Generic;
    using JulianPerrottName.Models;

    public interface IBlogRepository
    {
        List<BlogSummary> GetRecentBlogPosts();

        BlogPageViewModel GetPost(System.Guid postId);
    }
}