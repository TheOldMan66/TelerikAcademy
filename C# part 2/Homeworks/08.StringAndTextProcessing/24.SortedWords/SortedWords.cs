using System;
using System.Collections.Generic;

/* Write a program that reads a list of words, separated by spaces and prints the list 
 * in an alphabetical order. */

class SortedWords
{
    static void Main(string[] args)
    {
        string input = "alula sector cammac available civic financial deified process deleveled individual detartrated specific devoved principle dewed estimate evitative variables Hannah method kayak data kinnikinnik research lemel contract level environment madam export Malayalam source minim assessment murdrum policy peeweep identified racecar create radar derived redder factors refer procedure reifier definition repaper assume reviver theory rotator benefit rotavator evidence rotor established sagas authority solos major sexes issues stats labour tenet occur terret economic testset involved";
        Console.WriteLine("Input string: ");
        Console.WriteLine(input);
        string[] words = input.Split(' ');
        Array.Sort(words);
        Console.WriteLine();
        Console.WriteLine("Sorted words:");
        foreach (string s in words)
            Console.Write("{0} ", s);
        Console.WriteLine();
        Console.WriteLine();
    }
}