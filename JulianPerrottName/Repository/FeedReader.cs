namespace JulianPerrottName.Repository
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.ServiceModel.Syndication;
    using System.Xml;

    public class FeedReader : IFeedReader
    {
        public List<SyndicationItem> LoadFeed(string url)
        {
            try
            {
                using (var reader = XmlReader.Create(url))
                {
                    SyndicationFeed feed = SyndicationFeed.Load(reader);
                    reader.Close();
                    return feed.Items.ToList();
                }
            }
            catch (Exception)
            {
                return new List<SyndicationItem>();
            }
        }
    }
}