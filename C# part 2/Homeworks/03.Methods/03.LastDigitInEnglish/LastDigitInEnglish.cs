using System;

class LastDigitInEnglish
{
    static string LastDigit(int number)
    {
        string[] ones = { "zero", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine", "ten" };
        return ones[number % 10];
    }

    static void Main(string[] args)

    /* Write a method that returns the last digit of given integer as an English word. 
     * Examples: 512  "two", 1024  "four", 12309  "nine". */
    {
        Console.Write("Enter any positive integer value: ");
        int number = int.Parse(Console.ReadLine());
        Console.WriteLine();
        Console.WriteLine("Last digit in {0} is {1}", number, LastDigit(number));
    }
}
