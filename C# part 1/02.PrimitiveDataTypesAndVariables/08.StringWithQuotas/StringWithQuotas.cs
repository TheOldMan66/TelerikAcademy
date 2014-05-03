/* Declare two string variables and assign them with following value:
 * The "use" of quotations causes difficulties.
 * Do the above in two different ways: with and without using quoted strings */

using System;

namespace StringWithQuotes
{
    class StringWithQuotes
    {
        static void Main()
        {
            string string1;
            string string2;
            string1 = "The \"use\" of quotations causes difficulties.";
            string2 = @"The ""use"" of quotations causes difficulties.";
            Console.WriteLine(string1);
            Console.WriteLine(string2);
        }
    }
}
