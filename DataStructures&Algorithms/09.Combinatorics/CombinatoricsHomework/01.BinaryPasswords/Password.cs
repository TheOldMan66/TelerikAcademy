using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.BinaryPasswords
{
    class Password
    {
        static void Main(string[] args)
        {
            Console.Write("Input partial password (only '0','1' and '*' in sequence please): ");

            // I can't figure out how to make next line shorter... any ideas? :)
            Console.WriteLine("Number of combinations is: {0}", (1UL << Console.ReadLine().Count(ch => ch == '*')));
        }
    }
}
//  BgCoder: 100 / 100	Памет: 9.45 MB Време: 0.015 s
