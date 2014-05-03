using System;

class BigSum
{
    static int[] MakeArrayFromString(string input)
    {
        int[] output = new int[input.Length];
        for (int i = 0; i < input.Length; i++)
        {
            output[i] = input[input.Length - i - 1] - 48;
            if (output[i] > 9 || output[i] < 0)
                return new int[0];
        }
        return output;
    }

    static int[] MakeSum(int[] firstArray, int[] secondArray)
    {
        int arrLen = firstArray.Length;
        if (secondArray.Length > arrLen)
            arrLen = secondArray.Length;
        int[] result = new int[arrLen];
        int extra = 0;
        for (int i = 0; i < arrLen; i++)
        {
            result[i] = extra;
            if (firstArray.Length > i)
                result[i] = result[i] + firstArray[i];
            if (secondArray.Length > i)
                result[i] = result[i] + secondArray[i];
            extra = result[i] / 10;
            result[i] = result[i] % 10;
        }
        if (extra > 0)
        {
            int[] newResult = new int[arrLen + 1];
            Array.Copy(result, newResult, arrLen);
            newResult[arrLen] = extra;
            return newResult;
        }
        else
            return result;
    }

    static void PrintBigInt(int[] arr)
    {
        if (arr.Length == 0)
            Console.Write(0);
        for (int i = arr.Length - 1; i >= 0; i--)
            Console.Write(arr[i]);
        Console.WriteLine();
    }

    static void Main()
    {

        /* Write a method that adds two positive integer numbers represented as arrays of 
         * digits (each array element arr[i] contains a digit; the last digit is kept in 
         * arr[0]). Each of the numbers that will be added could have up to 10 000 digits. */

        Console.Write("Enter first positive number: ");
        string firstStringInput = Console.ReadLine();
        int[] firstNum = MakeArrayFromString(firstStringInput);
        if (firstNum.Length == 0)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Incorrect input!!! Assumed value 0!!!");
            Console.ForegroundColor = ConsoleColor.Gray;
        }
        Console.Write("Enter second positive number: ");
        string secondStringInput = Console.ReadLine();
        int[] secondNum = MakeArrayFromString(secondStringInput);
        if (secondNum.Length == 0)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Incorrect input!!! Assumed value 0!!!");
            Console.ForegroundColor = ConsoleColor.Gray;
        }
        int[] result = MakeSum(firstNum, secondNum);
        Console.Write("Sum is: ");
        PrintBigInt(result);
    }
}

