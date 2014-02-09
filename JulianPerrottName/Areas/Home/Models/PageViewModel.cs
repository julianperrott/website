namespace JulianPerrottName.Areas.Home.Models
{
    using System.Collections.Generic;
    using Blog;

    public class PageViewModel
    {
        public be_Posts Post { get; set; }

        public List<be_PostComment> Comments { get; set; }

        public List<be_PostTag> Tags { get; set; }
    }
}