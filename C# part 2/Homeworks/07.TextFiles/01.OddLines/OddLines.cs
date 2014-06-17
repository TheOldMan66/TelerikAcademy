using System;
using System.IO;
using System.Text;

/* Write a program that reads a text file and prints on the console its odd lines. */

class OddLines
{
    static void Main(string[] args)
    {
        try
        {
            StreamReader reader = new StreamReader(@"..\..\OddLines.cs",Encoding.GetEncoding("windows-1251"));
            string s;
            int lineNumber = 1;
            using (reader)
            {
                do
                {
                    
                s = reader.ReadLine();
                Console.WriteLine("Line {0}: {1}", lineNumber, s);
                lineNumber++;
                s = reader.ReadLine();
                lineNumber++;
                } while (s != null);
            }
        }
        catch (FileNotFoundException)
        {
            Console.WriteLine("Несъществуващ файл");
        }
    }
}