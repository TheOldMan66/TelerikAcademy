using System;

class Durankulak
{
    static void Main()
    {
        string input = Console.ReadLine();
        ulong durankulak = 0;
        while (input.Length > 0)
        {
            durankulak = durankulak * 168;
            if ((input.Length > 1) && char.IsLower(input[0]))
            {
                durankulak = durankulak + (ulong)((input[0] - 96) * 26 + (input[1] - 65));
                input = input.Remove(0, 2);
            }
            else
            {
                durankulak = durankulak + (ulong)(input[0] - 65);
                input = input.Remove(0, 1);
            }

        }
        Console.WriteLine(durankulak);
    }
}