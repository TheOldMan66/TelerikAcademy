using System;
using System.IO;
using System.Text;

/* Write a program that extracts from given HTML file its title (if available), 
 * and its body text without the HTML tags. Example: 
 <html>
  <head><title>News</title></head>
  <body><p><a href="http://academy.telerik.com">Telerik
    Academy</a>aims to provide free real-world practical
    training for young people who want to turn into
    skillful .NET software engineers.</p></body>
</html> */

class HTMLParser
{
    static string RemoveTags(string input)
    {
        StringBuilder sb = new StringBuilder();
        bool freeText = true;
        for (int i = 0; i < input.Length; i++)
        {
            if (freeText && input[i] == '<')
            {
                freeText = false;
                continue;
            }
            if (!freeText && input[i] == '>')
            {
                freeText = true;
                continue;
            }
            if (freeText)
                sb.Append(input[i]);
        }
        return sb.ToString();
    }

    static string GetSection(string input, string section)
    {
        string openSection = "<" + section + ">";
        int openPos = input.IndexOf(openSection);
        string closeSection = "</" + section + ">";
        int closePos = input.IndexOf(closeSection);
        if (openPos == -1 || closePos == -1)
            return null;
        string result = input.Substring(openPos + openSection.Length, closePos - openPos - openSection.Length);
        return result;
    }

    static void Main(string[] args)
    {
        string input = "";
        using (StreamReader reader = new StreamReader("test.html"))
            input = reader.ReadToEnd();
        Console.WriteLine("Input HTML file:");
        Console.WriteLine(input);
        Console.WriteLine();
        Console.WriteLine("Parsing:");
        string head = GetSection(input, "head");
        if (head == null)
            Console.WriteLine("No head section found");
        else
            Console.WriteLine("Head: {0}", RemoveTags(head));
        string body = GetSection(input, "body");
        if (body == null)
            Console.WriteLine("No body section found");
        else
            Console.WriteLine("Body: {0}",RemoveTags(body)); 
    }
}