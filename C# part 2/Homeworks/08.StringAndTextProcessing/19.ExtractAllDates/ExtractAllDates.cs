using System;
using System.Globalization;
using System.Threading;

/* Write a program that extracts from a given text all dates that match the format DD.MM.YYYY. 
 * Display them in the standard date format for Canada. */

class ExtractAllDates
{
    static void Main()
    {
        // I "borrow" ONLY this string, rest ot project is mine :)
        string input = "I was born at 14.06.1980. My sister was born at 3.7.1984. In 5/1999 I graduated my high school. The law says (see section 7.3.12) that we are allowed to do this (section 7.4.2.9).";
        string[] words = input.Split(' ');
        for (int i = 0; i < words.Length; i++)
        {
            try
            {
                DateTime date = DateTime.ParseExact(words[i].TrimEnd(new char[] { ',', '.', '!', '?' }), "d.M.yyyy", CultureInfo.InvariantCulture);
                Thread.CurrentThread.CurrentCulture = CultureInfo.GetCultureInfo("en-CA");
                Console.Write("Canada (english): {0}",date.Date.ToLongDateString());
                Thread.CurrentThread.CurrentCulture = CultureInfo.GetCultureInfo("fr-CA");
                Console.WriteLine(" \t Canada (french): {0}", date.Date.ToLongDateString());
                //                Console.WriteLine("Canada (english): {0}  Canada (french): {1}", date.Date.ToString(CultureInfo.GetCultureInfo("en-CA")), date.Date.ToString(CultureInfo.GetCultureInfo("fr-CA")));
            }
            catch (FormatException)
            {
            }
        }
    }
}