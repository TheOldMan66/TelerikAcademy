/* Write a program that reads a year from the console and checks whether 
 * it is a leap. Use DateTime. */

using System;

class LeapYear
{
    static void Main()
    {
        Console.Write("Enter a year: ");
        int year = int.Parse(Console.ReadLine());
        Console.WriteLine("Is year {0} a leap? {1}",year,DateTime.IsLeapYear(year));
    }
}
