using System;

class Program
{
    public static string[] NineGag = { "-!", "**", "!!!", "&&", "&-", "!-", "*!!!", "&*!", "!!**!-" };

    static void Main(string[] args)
    {
        string input = Console.ReadLine();
        ulong result = 0;
        while (input.Length > 0)
        {
            ulong i = 0;
            while (!input.StartsWith(NineGag[i])) i++;
            result = result * 9 + i;
            input = input.Remove(0, NineGag[i].Length);
        }
        Console.WriteLine(result);
    }
}