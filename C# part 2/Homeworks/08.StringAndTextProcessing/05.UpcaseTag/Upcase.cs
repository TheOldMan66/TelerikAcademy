using System;
using System.Text;

/* You are given a text. Write a program that changes the text in all regions surrounded 
 * by the tags <upcase> and </upcase> to uppercase. The tags cannot be nested. */

class Upcase
{
    static string ToUpcase(string s)
    {
        int ucaseStart = s.IndexOf("<upcase>");
        int ucaseEnd = s.IndexOf("</upcase>");
        if (ucaseStart > ucaseEnd || ucaseStart == -1 || ucaseEnd == -1)
            throw new FormatException("Invalid format tags");        
        StringBuilder sb = new StringBuilder();
        sb.Append(s.Substring(0,ucaseStart));
        sb.Append(s.Substring(ucaseStart+8,ucaseEnd-ucaseStart-8).ToUpper());
        sb.Append(s.Substring(ucaseEnd+9));
        return sb.ToString();
    }

    static void Main()
    {
        string s = StringConstants.upcaseSubmarine;
        Console.WriteLine("Original string:");
        Console.WriteLine(s);
        Console.WriteLine();
        try
        {
            while (s.Contains("upcase>"))
            {
                s = ToUpcase(s);
            }
        }
        catch (FormatException)
        {
            Console.WriteLine("ERROR!!! Invalid (or missed) format strings");
            return;
        }
        Console.WriteLine("Formatted string:");
        Console.WriteLine(s);
    }
}