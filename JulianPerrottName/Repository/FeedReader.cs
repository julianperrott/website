namespace JulianPerrottName.Repository
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Net;
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


        public List<SyndicationItem> LoadRss(string url)
        {
            try
            {
                List<SyndicationItem> items = new List<SyndicationItem>();

               using (var reader = XmlReader.Create(url))
                {
                   var doc = new XmlDocument();
                   doc.Load(reader);

                   XmlNodeList list = doc.SelectNodes("//item");

                   foreach(XmlNode node in list)
                   {
                       SyndicationItem item = new SyndicationItem();
                       items.Add(item);
                       string link=InnerText(node,"link");
                       string title= InnerText(node,"title");
                       string value = string.Format("<a target=\"_blank\" href=\"{0}\">{1}</a>", link, title);
                       item.Title = new TextSyndicationContent(value);
                   };

                   return items;
                }

                
            }
            catch (Exception)
            {
                return new List<SyndicationItem>();
            }
        }

        private string InnerText(XmlNode node, string name)
        {
            foreach (XmlNode childNode in node.ChildNodes)
            {
                if (childNode.Name == name)
                {
                    return childNode.InnerText;
                }
            }
            return string.Empty;
        }
    }
}