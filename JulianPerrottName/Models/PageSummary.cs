namespace JulianPerrottName.Models
{
    using System;
    using System.Web.Mvc;
    using System.Web.Routing;

    public abstract class SummaryBase
    {
        public string Image { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string PostContent { get; set; }
        public Nullable<System.DateTime> DateCreated { get; set; }
        public Nullable<System.DateTime> DateModified { get; set; }
        public Nullable<float> Rating { get; set; }
        public string Slug { get; set; }
        public abstract string Url(RequestContext requestContext);
    }

    public class BlogSummary : SummaryBase
    {
        public System.Guid PostId { get; set; }

        public override string Url(RequestContext requestContext)
        {
            return new UrlHelper(requestContext).Action("Post", "Blog", new { area = "Home", PostId });
        }
    }

    public class PageSummary : SummaryBase
    {
        public System.Guid PageId { get; set; }

        public override string Url(RequestContext requestContext)
        {
            return new UrlHelper(requestContext).Action("Post", "Page", new { area = "Home", PageId });
        }
    }


}