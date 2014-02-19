namespace JulianPerrottName.Repository
{
    using System.Collections.Generic;
    using System.ServiceModel.Syndication;

    public interface IFeedReader
    {
        List<SyndicationItem> LoadFeed(string url);

        List<SyndicationItem> LoadRss(string url);
    }
}