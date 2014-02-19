using System.Collections.Generic;
namespace JulianPerrottName.Models
{
    public class BlogPageViewModel
    {
        public Blog.be_Posts Post { get; set; }
        public List<Blog.be_PostTag> Tags { get; set; }
        public List<Blog.be_PostComment> Comments { get; set; }
    }
}