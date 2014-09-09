using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace _08.XMLReader_XMLWriter
{
    class ReadAndWrite
    {
        static void Main(string[] args)
        {
            XmlReader reader = XmlReader.Create("..\\..\\..\\..\\Catalogue.xml");
            XmlWriterSettings settings = new XmlWriterSettings();
            settings.Indent = true;
            settings.IndentChars = "  ";
            settings.Encoding = Encoding.UTF8;

            XmlWriter writer = XmlWriter.Create("..\\..\\songs.xml",settings);
            writer.WriteStartDocument();
            writer.WriteStartElement("albums");
            while (true)
            {
                if (!reader.ReadToFollowing("name"))
                {
                    break;
                }

                reader.Read();
                writer.WriteStartElement("album");
                writer.WriteStartElement("name");
                writer.WriteString(reader.Value);
                writer.WriteEndElement();

                reader.ReadToFollowing("artist");
                reader.Read();
                writer.WriteStartElement("artist");
                writer.WriteString(reader.Value);
                writer.WriteEndElement();
                writer.WriteEndElement();
            }
            writer.WriteEndElement();
            writer.WriteEndDocument();
            writer.Flush();
        }
    }
}
