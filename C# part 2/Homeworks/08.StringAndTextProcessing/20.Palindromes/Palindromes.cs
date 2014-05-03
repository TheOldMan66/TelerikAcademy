using System;

/* Write a program that extracts from a given text all palindromes, 
 * e.g. "ABBA", "lamal", "exe". */

class Palindromes
{
    //static bool IsPalindrome(string s)
    //{
    //    for (int i = 0; i < s.Length / 2; i++)
    //        if (s[i] != s[s.Length - i - 1])
    //            return false;
    //    return true;
    //}

    static bool IsPalindrome(string s)
    {
        int strLen = s.Length;
        int loopEnd = strLen / 2;
        strLen--;
        for (int i = 0; i < loopEnd; i++)
            if (s[i] != s[strLen - i])
                return false;
        return true;
    }

    static void Main()
    {
        DateTime start = DateTime.Now;
        string input = "alula, sector, cammac, available, civic, financial, deified, process, deleveled, individual, detartrated, specific, devoved principle, dewed, estimate, evitative, variables, Hannah, method, kayak, data, kinnikinnik, research, lemel, contract, level, environment, madam, export, Malayalam, source, minim, assessment, murdrum, policy, peeweep, identified, racecar, create, radar, derived, redder, factors, refer, procedure, reifier, definition, repaper, assume, reviver, theory, rotator, benefit, rotavator, evidence, rotor, established, sagas, authority, solos, major, sexes, issues, stats, labour, tenet, occur, terret, economic, testset, involved";
        string[] words = input.Split(new char[] { ',', '.', '!', '?', ' ' }, StringSplitOptions.RemoveEmptyEntries);
        for (int i = 0; i < 1000000; i++)
        {
            foreach (string s in words)
                if (IsPalindrome(s))
                {
                }
            //                    Console.WriteLine(s);
        }
        Console.WriteLine(DateTime.Now - start);
    }
}