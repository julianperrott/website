namespace JulianPerrottName.Repository
{
    using System.Xml;

    public class HtmlParser
    {
        public static string GetFirstTagAttribute(string data, string tag, string attribute)
        {
            string imageTag = GetFirstTag(data, tag);
            if (string.IsNullOrEmpty(imageTag))
            {
                return string.Empty;
            }

            return GetAttributeValue(imageTag, tag, attribute);
        }

        public static string GetAttributeValue(string imageTag, string tag, string attribute)
        {
            XmlDocument xdo = new XmlDocument();
            xdo.LoadXml(imageTag + (imageTag.EndsWith("/>") ? string.Empty : "</" + tag + ">"));

            foreach (XmlAttribute xel in xdo.DocumentElement.Attributes)
            {
                if (xel.Name == attribute)
                {
                    return xel.Value;
                }
            }

            return string.Empty;
        }

        public static string GetFirstTag(string data, string tag)
        {
            int start = data.IndexOf("<" + tag);
            if (start == -1)
            {
                return string.Empty;
            }

            int end = data.IndexOf(">", start);
            if (end == -1)
            {
                return string.Empty;
            }

            return data.Substring(start, end - start + 1);
        }
    }
}