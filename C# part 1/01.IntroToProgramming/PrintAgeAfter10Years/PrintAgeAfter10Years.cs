using System;

class PrintAgeAfter10Years
{
    static void Main()
    {
        Console.Write("Today is {0}. Enter Your current age: ", DateTime.Now.ToString("dd.M.yyyy"));
        int currentAge = int.Parse(Console.ReadLine());
        Console.WriteLine("After 10 years (on {0}) You will be {1} years old", DateTime.Now.AddYears(10).ToString("dd.M.yyyy"), currentAge + 10);
    }
}
