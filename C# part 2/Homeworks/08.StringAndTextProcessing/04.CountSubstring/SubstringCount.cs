using System;

/*  Write a program that finds how many times a substring is contained in a given 
 * text (perform case insensitive search). Example: The target substring is "in". 
 * The text is as follows: 
 * We are living in an yellow submarine. We don't have anything else. Inside the submarine 
 * is very tight. So we are drinking all the day. We will move out of it in 5 days.
 * The result is: 9. */

class SubstringCount
{
    static void Main()
    {
        Console.WriteLine("Sentence:");
        Console.WriteLine(StringConstants.submarine);
        string substr = "in";
        int index = 0;
        int count = 0;
        index = StringConstants.submarine.IndexOf(substr, index, StringComparison.OrdinalIgnoreCase);
        while (index > -1)
        {
            count++;
            index = StringConstants.submarine.IndexOf(substr, index+1, StringComparison.OrdinalIgnoreCase);
        }
        Console.WriteLine();
        Console.WriteLine("Substring '{0}' has ben found {1} times in sentence",substr,count);
    }
}