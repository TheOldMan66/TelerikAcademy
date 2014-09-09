using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace TelerikRSS
{
    public class Item
    {
        public string Title { get; set; }
        public string Link { get; set; }
        public string Description { get; set; }
        public string Category { get; set; }
        public string Date { get; set; }
    }

    public class Channel
    {
        public string Title { get; set; }
        public string Link { get; set; }
        public string Description { get; set; }
        public List<Item> Item { get; set; }
    }

    public class Rss
    {
        public Channel Channel { get; set; }
    }

    class RSSEntity
    {
        public Rss Rss { get; set; }
    }

    class TelerikRSS
    {
        static void ReadRss()
        {
            WebClient wc = new WebClient();
            wc.DownloadFile(@"http://forums.academy.telerik.com/feed/qa.rss", @"..\..\..\tmp.xml");
        }

        static string ParseToJson()
        {
            XDocument xmlDoc = XDocument.Load(@"..\..\..\tmp.xml");
            var channel = xmlDoc.Root;
            return JsonConvert.SerializeXNode(channel, Newtonsoft.Json.Formatting.Indented);
        }

        static string[] GetTitles(JObject jobject)
        {
            return jobject["rss"]["channel"]["item"].Select(t => (string)t["title"]).ToArray();
        }

        static void CreateHTMLFile(RSSEntity pocoObject)
        {
            StringBuilder htmlContext = new StringBuilder("<!DOCTYPE html>\n<meta charset='UTF-8'>\n<body>\n\t<ul>\n");
            foreach (var item in pocoObject.Rss.Channel.Item)
            {
                htmlContext.AppendLine("\t\t<li><div>Title : " + item.Title + "</div><div> Category : " + item.Category + " </div><div>Link: <a href='" + item.Link + "'>Click here</a></div></li>");
            }

            htmlContext.AppendLine("\t</ul>\n</body>");
            using (StreamWriter htmlFile = new StreamWriter(@"..\..\..\AllQuestions.html"))
            {
                htmlFile.WriteLine(htmlContext.ToString());
            }

        }

        static void Main(string[] args)
        {
            // Task 2
            ReadRss();

            // Task 3:
            string jsonRSS = ParseToJson();
            JObject joRSS = JObject.Parse(jsonRSS);

            // Task 4:
            string[] titles = GetTitles(joRSS);
            Console.WriteLine(string.Join("\n", titles));

            // Task 5:
            var pocoObj = JsonConvert.DeserializeObject<RSSEntity>(jsonRSS);

            // Task 6:
            CreateHTMLFile(pocoObj);
        }
    }
}
