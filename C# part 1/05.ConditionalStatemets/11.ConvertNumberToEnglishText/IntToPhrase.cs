/* Write a program that converts a number in the range [0...999] to a text corresponding to its English pronunciation. Examples:
	0  "Zero"
	273  "Two hundred seventy three"
	400  "Four hundred"
	501  "Five hundred and one"
	711  "Seven hundred and eleven" */

using System;
using System.Text;


namespace _11.ConvertNumberToEnglishText
{
    class IntToPhrase
    {
        static string[] ones = { "", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine", "ten",
                                "eleven", "twelve","thirteen","fourteen","fifteen","sixteen","seventeen","eighteen","nineteen"};
        static string[] decimals = { "", "", "twenty", "thirty", "forty", "fifty", "sixty", "seventy", "eighty", "ninety" };
        static void Main()
        {
            bool correctInput = false;
            StringBuilder result = new StringBuilder();
            int group = 0;
            int value = 0;
            do
            {
                do
                {
                    Console.Write("Enter any integer value: ");
                    correctInput = int.TryParse(Console.ReadLine(), out value);
                    if (!correctInput)
                        Console.WriteLine("Incorrect input. Try again.");
                } while (!correctInput);
                if (value < 0) Console.Write("minus");
                value = Math.Abs(value);
                group = value / 1000000000;
                if (group > 0)
                {
                    result.Append(ones[group]);
                    result.Append(" billion");
                    if (group > 1)
                        result.Append("s");
                }

                value = value % 1000000000;
                group = value / 1000000;
                if (group > 0)
                {
                    result.Append(" ");
                    result.Append(NumToStr(group));
                    result.Append(" million");
                    if (group > 1)
                        result.Append("s");
                }

                value = value % 1000000;
                group = value / 1000;
                if (group > 0)
                {
                    result.Append(" ");
                    result.Append(NumToStr(group));
                    result.Append(" thousand");
                    if (group > 1)
                        result.Append("s");
                }

                value = value % 1000;
                group = value;
                if (group > 0)
                {
                    result.Append(" ");
                    result.Append(NumToStr(group));
                }
                Console.WriteLine(result);
                result.Clear();
            } while (true);
        }

        static StringBuilder NumToStr(int num)
        {
            StringBuilder s = new StringBuilder();
            if (num / 100 > 0)
            {
                s.Append(ones[num / 100]);
                s.Append(" hundred ");
                if (num % 100 > 0)
                {
                    s.Append("and ");
                }
            }
            num = num % 100;
            if (num > 19)
            {
                s.Append(decimals[num / 10]);
                if (num % 10 != 0)
                {
                    s.Append("-");
                    s.Append(ones[num % 10]);
                }
            }
            else
            {
                s.Append(ones[num]);
            }
            return s;
        }
    }
}
