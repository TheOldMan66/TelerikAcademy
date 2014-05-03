/* Create a program that assigns null values to an integer and to double variables. 
 * Try to print them on the console, try to add some values or the null literal to 
 * them and see the result. */

using System;

class Nullables
{
    static void Main()
    {
        int? anyInt = 0;
        double? anyDouble = 0d;
        Console.WriteLine("Operation wiht int and decimal with value of 0:");
        Console.WriteLine("Zero Integer = {0}\nZero Double = {1}", anyInt, anyDouble);
        Console.WriteLine("Zero Integer + 255 = {0}\nZero Double + 354,785 = {1}\n", anyInt + 255, anyDouble + 354.785);

        anyInt = null;
        anyDouble = null;
        Console.WriteLine("Operation wiht int and decimal with null value:");
        Console.WriteLine("Null Integer = {0}\nNull Double = {1}", anyInt, anyDouble);
        Console.WriteLine("Null Integer + 255 = {0}\nNull Double + 354,785 = {1}\n", anyInt + 255, anyDouble + 354.785);
    }
}