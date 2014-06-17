using System;
using System.IO;
using System.Text;

/* Write a program that reads a text file and inserts line numbers in front of each 
 * of its lines. The result should be written to another text file. */

class NumberLines
{
    static void Main(string[] args)
    {
        StreamReader reader = null;
        StreamWriter writer = null;
        try
        {
            reader = new StreamReader(@"..\..\LineNumbers.cs", Encoding.GetEncoding("windows-1251"));
        }
        catch (FileNotFoundException)
        {
            Console.WriteLine("Несъществуващ файл");
        }
        try
        {
            writer = new StreamWriter(@"..\..\LineNumbers.txt");
        }
        catch (IOException)
        {
            Console.WriteLine("Проблем при създаване на изходния файл.");
        }
        string s;
        int lineNumber = 1;
        using (reader)
        using (writer)
        {
            do
            {
                s = reader.ReadLine();
                writer.WriteLine("Line {0}: {1}", lineNumber, s);
                lineNumber++;
                s = reader.ReadLine();
                lineNumber++;
            } while (s != null);
        }
        Console.WriteLine("Task complete.");
    }
}
