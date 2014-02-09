namespace JulianPerrottName.Repository
{
    using System.Collections.Generic;
    using JulianPerrottName.Models;

    public interface IBlogRepository
    {
        List<BlogSummary> GetRecentBlogPosts();

        Blog.be_Posts GetPost(System.Guid postId);
    }
}