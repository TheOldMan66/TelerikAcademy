using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AcademyRPG
{
    class Program
    {
        static Engine GetEngineInstance()
        {
            //            return new Engine();
            return new ModifiedEngine();
        }

        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int sum = 0;
            for (int i = 0; i < n; i++)
            {
                sum = (sum << 4) + (sum << 3) + (sum << 1) + (Console.ReadLine()[0] & 0x1F);

            }
            Console.WriteLine(sum);
            Console.ReadLine();

            Engine engine = GetEngineInstance();

            string command = Console.ReadLine();
            while (command != "end")
            {
                engine.ExecuteCommand(command);
                command = Console.ReadLine();
            }
        }
    }
}
