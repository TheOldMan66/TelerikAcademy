/* Sort 3 real values in descending order using nested if statements. */

using System;


namespace _04.SortThreeReals
{
    class SortThreeReals
    {
        static void Main()
        {
            Console.Write("Enter first number: ");
            double first = double.Parse(Console.ReadLine());
            Console.Write("Enter second number: ");
            double second = double.Parse(Console.ReadLine());
            Console.Write("Enter second number: ");
            double third = double.Parse(Console.ReadLine());
            double swap = 0.0d;

            // Variations: 1 - smallest value, 2 - medium, 3 - biggest

            if (first < second) // 123,132,231 variations
            {
                if (second < third) // 123 
                {
                    swap = first;
                    first = third;
                    third = swap;
                }
                else // 132,231 variations
                {
                    if (first < third) // 132
                    {
                        swap = first;
                        first = second;
                        second = third;
                        third = swap;
                    }
                    else // 231
                    {
                        swap = first;
                        first = second;
                        second = swap;
                    }
                }
            }
            else // 213,312,321 variations. 321 is already sorted, so in this case no swap is needed.
            {
                if (second < third) // 213, 312 variations
                {
                    if (first < third) // 213
                    {
                        swap = first;
                        first = third;
                        third = second;
                        second = swap;
                    }
                    else // 312
                    {
                        swap = second;
                        second = third;
                        third = swap;
                    }
                }
            }
            Console.WriteLine("Sorted sequence is {0}, {1}, {2}.", first, second, third);
        }
    }
}
