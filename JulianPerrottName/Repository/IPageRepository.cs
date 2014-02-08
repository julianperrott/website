namespace JulianPerrottName.Repository
{
    using System.Collections.Generic;
    using JulianPerrottName.Models;

    public interface IPageRepository
    {
        List<PageSummary> GetRecentPagePosts();
    }
}