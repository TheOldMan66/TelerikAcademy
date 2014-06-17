using System;
using System.IO;
using System.Text;

/* Write a program that compares two text files line by line and prints the 
 * number of lines that are the same and the number of lines that are different. 
 * Assume the files have equal number of lines. */

class FileComparer
{
    static void Main()
    {
        StreamReader reader1 = null;
        StreamReader reader2 = null;
        try
        {
            reader1 = new StreamReader("test1.txt");
            reader2 = new StreamReader("test2.txt");
        }
        catch (FileNotFoundException)
        {
            Console.WriteLine("Cannot open test file(s)");
            return;
        }
        int equalLines = 0;
        int differentLines = 0;
        using (reader1)
        using(reader2)
        {
            string s1 = reader1.ReadLine() ;
            string s2 = reader2.ReadLine() ;
            while (s1 != null)
            {
                if (s1 == s2)
                    equalLines++;
                else
                    differentLines++;
                s1 = reader1.ReadLine();
                s2 = reader2.ReadLine();
            }
        }
        Console.WriteLine("Number of identical lines: {0}",equalLines);
        Console.WriteLine("Number of different lines: {0}",differentLines);
    }
}