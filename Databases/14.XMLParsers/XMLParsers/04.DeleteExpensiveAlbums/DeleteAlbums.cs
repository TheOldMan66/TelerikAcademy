using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;

namespace _04.DeleteExpensiveAlbums
{
    class DeleteAlbums
    {
        static void Main(string[] args)
        {
            XDocument xmlDoc =  XDocument.Load(@"..\..\..\..\Catalogue.xml");
            Console.WriteLine("Albums before operation: {0}",xmlDoc.Descendants("album").Count());
            //Warning - parse is culture speific ( . or ,) !!!
            xmlDoc.Descendants("album").Where(p => decimal.Parse(p.Element("price").Value) > 10.0M).Remove();
            Console.WriteLine("Albums after operation: {0}", xmlDoc.Descendants("album").Count());
        }
    }
}