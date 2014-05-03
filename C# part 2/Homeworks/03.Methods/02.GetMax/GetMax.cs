using System;

class GetMaxMethod
{
    static int GetMax(int a, int b)
    {
        if (b > a)
            return b;
        else
            return a;
    }

    static void Main()

    /* Write a method GetMax() with two parameters that returns the bigger of two integers. 
     * Write a program that reads 3 integers from the console and prints the biggest of them 
     * using the method GetMax(). */
    {
        Console.Write("Entter first int: ");
        int first = int.Parse(Console.ReadLine());
        Console.Write("Entter first int: ");
        int second = int.Parse(Console.ReadLine());
        Console.Write("Entter first int: ");
        int third = int.Parse(Console.ReadLine());
        Console.WriteLine("The max is {0}.",GetMax(first,GetMax(second,third)));
    }
}
