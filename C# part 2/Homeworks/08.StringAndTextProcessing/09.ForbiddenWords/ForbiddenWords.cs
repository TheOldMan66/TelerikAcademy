using System;

/* We are given a string containing a list of forbidden words and a text containing 
 * some of these words. Write a program that replaces the forbidden words with asterisks. 
 * Example: 
 * Microsoft announced its next generation PHP compiler today. It is based 
 * on .NET Framework 4.0 and is implemented as a dynamic language in CLR.
 * Words: "PHP, CLR, Microsoft". The expected result:
 * ********* announced its next generation *** compiler today. It is based 
 * on .NET Framework 4.0 and is implemented as a dynamic language in ***. */

class ForbiddenWords
{

    static void Main()
    {
        string sentence = StringConstants.microsoft;
        string[] forbiddenWords = { "PHP", "CLR", "Microsoft" };

        Console.WriteLine("Uncensored sentence:");
        Console.WriteLine(sentence);
        Console.WriteLine();
        for (int i = 0; i < forbiddenWords.Length; i++)
        {
            while (sentence.IndexOf(forbiddenWords[i]) > -1)
                sentence = sentence.Replace(forbiddenWords[i], new string('*', forbiddenWords[i].Length));
        }
        Console.WriteLine("Censored sentence:");
        Console.WriteLine(sentence);
    }
}
