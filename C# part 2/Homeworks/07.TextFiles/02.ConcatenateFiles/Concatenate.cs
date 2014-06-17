using System;
using System.IO;
using System.Text;

/* Write a program that concatenates two text files into another text file. */

class Concatenate
{

    static void MakeTestFile(int fileNumber)
    {
        StreamWriter writer = null;
        try
        {
            writer = new StreamWriter(fileNumber + ".txt");
        }
        catch (IOException ex)
        {
            Console.WriteLine("Cannot create test file #{0}", fileNumber);
            throw (ex);
        }
        using (writer)
            for (int i = 0; i < 10; i++)
                writer.WriteLine("File {0} line {1}", fileNumber, i + 1);
    }

    static void Main(string[] args)
    {
        try
        {
            MakeTestFile(1);
            MakeTestFile(2);
        }
        catch (IOException)
        {
            Console.WriteLine("Cannot create test files.");
            return;
        }
        StreamReader reader = null;
        StreamWriter writer = null;
        try
        {
            reader = new StreamReader("1.txt");
        }
        catch (FileNotFoundException)
        {
            Console.WriteLine("Cannot open test file #1");
            return;
        }
        try
        {
            writer = new StreamWriter("result.txt");
        }
        catch (IOException)
        {
            Console.WriteLine("Cannot create result file");
            return;
        }
        string s = null;
        using (writer)
        {
            using (reader)
            {
                s = reader.ReadLine();
                while (s != null)
                {
                    try
                    {
                        writer.WriteLine(s);
                    }
                    catch (IOException)
                    {
                        Console.WriteLine("Cannot write data to output file");
                    }
                    try
                    {
                        s = reader.ReadLine();
                    }
                    catch (IOException)
                    {
                        Console.WriteLine("Cannot read data from input file");
                    }
                }
            }
            try
            {
                reader = new StreamReader("2.txt");
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine("Cannot open test file #2");
            }
            using (reader)
            {
                s = reader.ReadLine();
                while (s != null)
                {
                    try
                    {
                        writer.WriteLine(s);
                    }
                    catch (IOException)
                    {
                        Console.WriteLine("Cannot write data to output file");
                    }
                    try
                    {
                        s = reader.ReadLine();
                    }
                    catch (IOException)
                    {
                        Console.WriteLine("Cannot read data from input file");
                    }
                }
            }
        }
        Console.WriteLine("Task comlete. Created file result.txt.");
    }
}
