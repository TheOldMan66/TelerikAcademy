/* Write a program that prints to the console which 
 * day of the week is today. Use System.DateTime. */

using System;

    class Today
    {
        static void Main()
        {
            DateTime dt = DateTime.Today;
            Console.WriteLine("Today is {0}.",dt.DayOfWeek);
        }
    }
