namespace JulianPerrottName.Areas.Home.Models
{
    using System.Collections.Generic;
    using System.ServiceModel.Syndication;

    public class FeedTabViewModel
    {
        public List<SyndicationItem> Items { get; set; }

        public string LinkText { get; set; }

        public string LinkUrl { get; set; }
    }
}