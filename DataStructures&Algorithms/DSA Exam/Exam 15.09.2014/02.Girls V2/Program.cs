using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02.Girls_V2
{
    class Program
    {
        public static bool[] shirtsUsed;
        public static bool[] skirsUsed;
        public static bool[] setsUsed = new bool[100];
        public static int[] shirts;
        public static int[] skirts;
        public static int[] girls;
        public static List<int[]> combinations = new List<int[]>();

        static void DressGirls(int girlNo, int maxGirls)
        {
            if (girlNo == maxGirls)
            {
                Console.WriteLine(string.Join(",",girls));
                combinations.Add(girls);
                return;
            }

            for (int shirt = girlNo; shirt < shirtsUsed.Length; shirt++)
            {
                if (!shirtsUsed[shirt])
                {
                    for (int skirt = girlNo; skirt < skirsUsed.Length; skirt++)
                    {
                        int set = shirt * 10 + skirt;
                        if (!skirsUsed[skirt] && !setsUsed[set])
                        {
                            shirtsUsed[shirt] = true;
                            skirsUsed[skirt] = true;
                            setsUsed[set] = true;
                            girls[girlNo] = shirt * 10 + skirt;
                            DressGirls(girlNo + 1, maxGirls);
                            shirtsUsed[shirt] = false;
                            skirsUsed[skirt] = false;
                            setsUsed[set] = false;
                        }
                    }
                }
            }
        }
        static void Main(string[] args)
        {
            int numOfShirts = int.Parse(Console.ReadLine());
            string skirtsAsString = Console.ReadLine().ToCharArray().Distinct().ToArray().ToString();
            int numOfSkirts = skirtsAsString.Length;
            int numOfGirls = int.Parse(Console.ReadLine());
            shirtsUsed = new bool[numOfShirts];
            skirsUsed = new bool[numOfSkirts];
            shirts = new int[numOfShirts];
            skirts = new int[numOfSkirts];
            girls = new int[numOfGirls];
            DressGirls(0, numOfGirls);
        }
    }
}
