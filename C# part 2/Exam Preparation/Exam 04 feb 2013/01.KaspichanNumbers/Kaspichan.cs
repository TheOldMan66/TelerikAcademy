using System;

class Kaspichan
{
    static string ToKaspichan(ulong input)
    {
        string s = "" + (char)(input % 26 + 65);
        input = input / 26;
        if (input > 0)
        {
            s = (char)(input + 96) + s;
        }
        return s;
    }

    static void Main()
    {
        ulong input = ulong.Parse(Console.ReadLine());
        string output = "";
        do
        {
            output = ToKaspichan(input % 256) + output;
            input = input / 256;
        } while (input > 0);
        Console.WriteLine(output);
    }
}