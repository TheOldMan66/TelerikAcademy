using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace _06.SongsTitlesXPath
{
    class SongTitles
    {
        static void Main(string[] args)
        {
            XDocument xDoc = XDocument.Load(@"..\..\..\..\Catalogue.xml");
            var songsTitles = xDoc.Descendants("title").Select(t => t.Value);
            Console.WriteLine(string.Join("\n",songsTitles));
            Console.WriteLine();
        }
    }
}
