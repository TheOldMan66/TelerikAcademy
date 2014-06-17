using System;


class TwoIsBetter
{
    static string MakePalindrome(int number)
    {
        string s = Convert.ToString(number, 2);
        s = s.Remove(0, 1);
        char[] ch = s.ToCharArray();
        Array.Reverse(ch);
        s = s + new string(ch);
        s = s.Replace('0', '3');
        s = s.Replace('1', '5');
        return s;
    }


    static void Main(string[] args)
    {
        // input task 1
        string input = Console.ReadLine();
        string[] split = input.Split();
        ulong a = ulong.Parse(split[0]);
        ulong b = ulong.Parse(split[1]);

        // input task 2
        input = Console.ReadLine();
        split = input.Split(',');
        int[] array = new int[split.Length];
        for (int i = 0; i < split.Length; i++)
            array[i] = int.Parse(split[i]);
        double percentile = double.Parse(Console.ReadLine());

        // compute task 1
        int palindromeCount = 0;
        int count = 2;
        ulong palindrome;
        string s = "";
        bool finished;
        do
        {
            s = MakePalindrome(count);
            if (ulong.TryParse(s, out palindrome) && palindrome >= a && palindrome <= b)
            {
                palindromeCount++;
            }
            finished = ulong.TryParse(s.Remove(s.Length / 2, 1), out palindrome);
            if (finished && palindrome >= a && palindrome <= b)
            {
                palindromeCount++;
            }
            count++;
        } while (palindrome < b && finished);
        Console.WriteLine(palindromeCount);

        // compute task 2
        Array.Sort(array);
        int element = (int)Math.Ceiling((array.Length * percentile) / 100.0d) - 1;
        if (element < 0) element = 0;
        Console.WriteLine(array[element]);
    }
}