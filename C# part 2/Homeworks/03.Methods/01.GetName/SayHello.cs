using System;

class Hello
{
    static string SayHello()
    {
        Console.Write("Please enter Your name: ");
        string s = Console.ReadLine();
        Console.WriteLine("Hello, {0}!",s);
        return s;
    }

    static void Main()
    {

        /* Write a method that asks the user for his name and prints "Hello, <name>"
         * (for example, Hello,Peter!"). Write a program to test this method. */

        string name = SayHello();
    }
}
