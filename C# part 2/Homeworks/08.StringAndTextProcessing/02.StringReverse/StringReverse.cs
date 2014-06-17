using System;

/* Write a program that reads a string, reverses it and prints the result at the console.
Example: "sample"  "elpmas". */

class StringReverse
{
    static void Main()
    {
        Console.WriteLine("Enter some string: ");
        char[] ch = Console.ReadLine().ToCharArray();
        Array.Reverse(ch);
        Console.WriteLine(new string(ch));
    }
}

// Е, тази реализация не е точно по темата на лекцията, aма е по-бързо отколкото да въртя цикли :)