using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;

namespace XMLParsers
{
    class ArtistsCounter
    {
        static void Main(string[] args)
        {
            Dictionary<string, int> counter = new Dictionary<string, int>();

            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(@"..\..\..\..\Catalogue.xml");
            XmlElement root = xmlDoc.DocumentElement;
            var artists = root.SelectNodes("//artist");
            foreach (XmlElement artist in artists)
            {
                string artistName = artist.InnerText;
                Console.WriteLine("Found artist {0}", artistName);
                if (!counter.ContainsKey(artistName))
                {
                    counter.Add(artistName, 1);
                }
                else
                {
                    counter[artistName]++;
                }
            }
            Console.WriteLine();
            foreach (var item in counter.Keys)
            {
                Console.WriteLine("Artist: {0}, Number of albums: {1}", item, counter[item]);
            }
        }
    }
}
