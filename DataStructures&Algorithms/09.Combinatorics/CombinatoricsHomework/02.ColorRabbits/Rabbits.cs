using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02.ColorRabbits
{
    class Rabbits
    {
        static void Main(string[] args)
        {
            int[] rabbitResponces = new int[1000002];

            Console.Write("Number of asked rabbits: ");
            int numOfAskedRabbits = int.Parse(Console.ReadLine());
            for (int i = 1; i <= numOfAskedRabbits; i++)
            {
                Console.Write("Enter response from rabbit No {0}: ", i);
                int currentRabbitAnswer = int.Parse(Console.ReadLine());
                rabbitResponces[currentRabbitAnswer + 1]++;
            }

            ulong rabbitsCount = 0;
            for (int i = 1; i < rabbitResponces.Length; i++)
            {
                if (rabbitResponces[i] > 0)
                {
                    if (rabbitResponces[i] > i)
                    {
                        // short, fast and totally unreadable - I love it :)
                        rabbitsCount += (ulong)((rabbitResponces[i] / i) * i + (rabbitResponces[i] % i == 0 ? 0 : i));
                    }
                    else
                    {
                        rabbitsCount += (ulong)i;
                    }
                }
            }
            Console.WriteLine("\nAt Rabbit City lives at least {0} rabbits", rabbitsCount);
        }
    }
}
// BgCoder:  100 / 100	Памет: 12.61 MB Време: 0.014 s