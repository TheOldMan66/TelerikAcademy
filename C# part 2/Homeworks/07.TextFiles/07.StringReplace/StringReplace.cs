using System;
using System.IO;

/* Write a program that replaces all occurrences of the substring "start" with the 
 * substring "finish" in a text file. Ensure it will work with large files (e.g. 100 MB). */

class StringReplace
{

    static void Main()
    {
        const string SEARCHWORD = "start";
        const string REPLACEWORD = "finish";
        StreamReader reader = null;
        try
        {
            reader = new StreamReader(@"..\..\..\dickens.txt");
        }
        catch (FileNotFoundException)
        {
            Console.WriteLine("Input file not found.");
            return;
        }
        StreamWriter writer = null;
        try
        {
            writer = new StreamWriter(@"..\..\..\dickens_replaced.txt");
        }
        catch (IOException)
        {
            Console.WriteLine("Cannot create output file.");
            return;
        }
        string s;
        int changedWords = 0;
        int totalRows = 0;
        Console.WriteLine("Please be patient. Test file contains more than 1/2 million rows... :) ");
        using (reader)
        using (writer)
        {
            s = reader.ReadLine();
            do
            {
                // You can disable writing on console (comment next 2 rows) to speed up program execution.  If I
                // print every row number program will work very slow. I use 37 to make illusion that every single
                //  number is writen on console but this is a very, very slow operation, so I cheating a little :)
                if (totalRows % 37 == 0) 
                    Console.Write("Please wait. Processing line {0} \r", totalRows);
                totalRows++;
                while (s.IndexOf(SEARCHWORD) > -1)
                {
                    s = s.Replace(SEARCHWORD, REPLACEWORD);
                    changedWords++;
                }
                writer.WriteLine(s);
                s = reader.ReadLine();
            } while (s != null);
        }
        Console.WriteLine("Task complete. Processed rows: {0}. {1} words changed.", totalRows, changedWords);
    }
}
