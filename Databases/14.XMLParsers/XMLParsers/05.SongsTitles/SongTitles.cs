using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace _05.SongsTitles
{
    class SongTitles
    {
        static void Main(string[] args)
        {
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(@"..\..\..\..\Catalogue.xml");
            var songsTitles = xmlDoc.SelectNodes("/catalogue/album/song/title");
            foreach (XmlNode title in songsTitles)
            {
                Console.WriteLine(title.InnerText);
            }
            Console.WriteLine();
        }
    }
}
