using System;
using System.IO;

/* Modify the solution of the previous problem to replace only whole words (not substrings). */

class WholeStringReplace
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
            Console.WriteLine("Cannot create outpit file.");
            return;
        }
        string s;
        string[] words;
        int changedWords = 0;
        int totalRows = 0;
        int totalWords = 0;
        Console.WriteLine("Please be patient. Test file contains more than 1/2 million rows... :) ");
        using (reader)
        using (writer)
        {
            s = reader.ReadLine();
            do
            {
                if (totalRows % 100 == 0) // if I print every row program working very slow.
                    Console.Write("Please wait. Processing line {0} \r", totalRows);
                totalRows++;
                words = s.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries);
                for (int i = 0; i < words.Length; i++)
                {
                    if (words[i] == SEARCHWORD)
                    {
                        writer.Write(REPLACEWORD);
                        changedWords++;
                    }
                    else
                        writer.Write(words[i]);
                    totalWords++;
                    if (i < words.Length - 1)
                        writer.Write(" ");
                    else
                        writer.WriteLine();
                }
                s = reader.ReadLine();
            } while (s != null);
        }
        Console.WriteLine("Task complete. Output file created. {0} words changed.", changedWords);
        Console.WriteLine("Processed rows: {0}. Processed words: {1}", totalRows, totalWords);
    }
}