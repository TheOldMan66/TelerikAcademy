using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace _03.CountArtists_XPath
{
    class ArtistCounter
    {
        static void Main(string[] args)
        {
            Dictionary<string, int> counter = new Dictionary<string, int>();

            XDocument xDoc = XDocument.Load(@"..\..\..\..\Catalogue.xml");

            var artists = xDoc.Descendants("artist").GroupBy(a => a.Value).ToDictionary( group => group.Key, group => group.Count());



            foreach (var artist in artists)
            {
                Console.WriteLine("Atrist: {0}, Number of albums: {1}", artist.Key, artist.Value);
            }
        }
    }
}
