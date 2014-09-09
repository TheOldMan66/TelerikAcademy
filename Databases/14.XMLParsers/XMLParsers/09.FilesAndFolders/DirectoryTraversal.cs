using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Xml;


namespace DirectoryTraversal
{

    class FilesAndFolders
    {
        static void WalkDirectoryTree(string rootStr, XmlWriter writer)
        {
            FileInfo[] fiFiles = null;
            DirectoryInfo root = new DirectoryInfo(rootStr);
            DirectoryInfo[] subDirs = null;

            try
            {
                fiFiles = root.GetFiles("*.*");
            }
            catch (UnauthorizedAccessException e)
            {
            }

            if (fiFiles != null)
            {
                for (int i = 0; i < fiFiles.Length; i++)
                {
                    writer.WriteStartElement("file");
                    writer.WriteAttributeString("name", fiFiles[i].Name);
                    writer.WriteEndElement();
                }
            }

            try
            {
                subDirs = root.GetDirectories();
            }
            catch (UnauthorizedAccessException e)
            {
            }

            if (subDirs != null)
            {
                for (int i = 0; i < subDirs.Length; i++)
                {
                    writer.WriteStartElement("dir");
                    writer.WriteAttributeString("name", subDirs[i].Name);
                    writer.WriteEndElement();
                }
            }
        }

        static void Main(string[] args)
        {
            XmlWriterSettings settings = new XmlWriterSettings();
            settings.Indent = true;
            settings.IndentChars = "  ";
            settings.Encoding = Encoding.UTF8;
            string path = Path.GetFullPath(@"..\..\..");

            XmlWriter writer = XmlWriter.Create("..\\..\\directories.xml", settings);
            writer.WriteStartDocument();
            writer.WriteStartElement("path");
            writer.WriteAttributeString("name", path);

            WalkDirectoryTree(@"..\..\..", writer);

            writer.WriteEndElement();
            writer.WriteEndDocument();
            writer.Flush();
        }
    }
}
