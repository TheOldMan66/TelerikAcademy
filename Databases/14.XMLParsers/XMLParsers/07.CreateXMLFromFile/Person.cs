using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace _07.CreateXMLFromFile
{
    class Person
    {
        static void Main(string[] args)
        {
            // let's imagine that I know how to open a text file and read 3 strings from it, OK?
            // It's not a homework from C# part 1 course...and I HAVE NO TIME AT ALL :)

            string name = "Ivan Petrov"; // readed from imaginary file :)
            string address = "35 Alexander Malinov str";
            string phone = "+359 (2) 987-65-43";
            new XDocument(
                new XElement("person",
                    new XElement("name", name),
                    new XElement("address", address),
                    new XElement("phone", phone)
                )
            ).Save("..\\..\\person.xml");
        }
    }
}
