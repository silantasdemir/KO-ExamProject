using KO.Web.UI.MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace KO.UI.MVC.Helper
{
    public class RSSHelper
    {
        public static XmlDocument GetXML(string url)
        {
            WebClient client = new WebClient();
            XmlDocument doc = new XmlDocument();
            client.Encoding = Encoding.UTF8;
            string rssData = client.DownloadString(url);
            doc.LoadXml(rssData);
            return doc;
        }

        public static List<Post> GetAllPost(string url)
        {
            List<Post> posts = new List<Post>();

            XmlDocument doc = GetXML(url);
            XmlNodeList nodeList = doc.SelectNodes("rss/channel/item");

            foreach (XmlNode item in nodeList)
            {
                Post post = new Post()
                {
                    Header = item.SelectSingleNode("title").InnerText,
                    Description = item.SelectSingleNode("description").InnerText
                };
                posts.Add(post);
            }
            return posts;
        }
    }
}
