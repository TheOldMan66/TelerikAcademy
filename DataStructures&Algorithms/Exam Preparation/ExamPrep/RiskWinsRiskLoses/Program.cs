using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RiskWinsRiskLoses
{
    class Program
    {
        static int[] powerOf10 = new int[] { 10000, 1000, 100, 10, 1 };
        static int startCombination;
        static HashSet<int> forboddenCombinations = new HashSet<int>();

        public static void RotateDiskUp(int diskNo)
        {
            if ((startCombination / powerOf10[diskNo]) %10 == 9)
            {
                startCombination -= powerOf10[diskNo] * 9;
            }
            else
            {
                startCombination += powerOf10[diskNo];
            }
        }
        public static void RotateDiskDown(int diskNo)
        {
            if ((startCombination / powerOf10[diskNo]) % 10 == 0)
            {
                startCombination += powerOf10[diskNo] * 9;
            }
            else
            {
                startCombination -= powerOf10[diskNo];
            }
        }

        static void Recursion(int diskNo, int totalRotations)
        {
            for (int i = 0; i < 10; i++)
            {
                RotateDiskUp(diskNo);
                Recursion(diskNo + 1, totalRotations + i);
            }
            for (int i = 0; i < 10; i++)
            {
                RotateDiskUp(diskNo);
                Recursion(diskNo + 1, totalRotations + i);
            }

        }
        static void Main(string[] args)
        {
            startCombination = int.Parse(Console.ReadLine());
            RotateDiskUp(0);
            Console.WriteLine(startCombination);
            char[] endCombination = Console.ReadLine().ToCharArray();
            Recursion(0, 0);
            int N = int.Parse(Console.ReadLine());
            for (int i = 0; i < N; i++)
            {

            }
        }
    }
}
