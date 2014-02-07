namespace JulianPerrottName.Repository
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Net;
    using System.ServiceModel.Syndication;
    using System.Xml;

    public class ProxyFeedReader : IFeedReader
    {
        public List<SyndicationItem> LoadFeed(string url)
        {
            try
            {
                return LoadFeedWithProxy(url);
            }
            catch (Exception)
            {
                return new List<SyndicationItem>();
            }
        }

        public List<SyndicationItem> LoadFeedWithProxy(string url)
        {
            HttpWebRequest httpWebRequest = (HttpWebRequest)HttpWebRequest.Create(url);
            httpWebRequest.UserAgent = "Googlebot/1.0 (googlebot@googlebot.com http://googlebot.com/)";

            WebProxy myproxy = new WebProxy("10.128.0.39", 8080);
            myproxy.BypassProxyOnLocal = false;

            // WWB: Use The Default Proxy
            httpWebRequest.Proxy = myproxy;

            // WWB: Use The Thread's Credentials (Logged In User's Credentials)
            if (httpWebRequest.Proxy != null)
            {
                httpWebRequest.Proxy.Credentials = CredentialCache.DefaultCredentials;
            }

            using (HttpWebResponse httpWebResponse = (HttpWebResponse)httpWebRequest.GetResponse())
            {
                using (Stream responseStream = httpWebResponse.GetResponseStream())
                {
                    using (XmlReader xmlReader = XmlReader.Create(responseStream))
                    {
                        SyndicationFeed feed = SyndicationFeed.Load(xmlReader);
                        xmlReader.Close();
                        return feed.Items.ToList();
                    }
                }
            }
        }
    }
}