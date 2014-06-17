using System;

class Cuboid
{
    static public int cubeW;
    static public int cubeH;
    static public int cubeD;

    static void MoveBall(string[, ,] cuboid, ref int w1, ref int h1, ref int d1)
    {
        string command = cuboid[w1, h1, d1];
//        Console.WriteLine("{0}, {1}, {2}, {3}", w1, h1, d1, command);
        if (command == "E")
        {
            if (h1 == cubeH - 1)
            {
                Console.WriteLine("Yes");
                Console.WriteLine(w1 + " " + h1 + " " + d1);
                Environment.Exit(0);
            }
            h1++;
        }
        if (command == "B")
        {
            Console.WriteLine("No");
            Console.WriteLine(w1 + " " + h1 + " " + d1);
            Environment.Exit(0);
        }
        if (command[0] == 'T')
        {
            string[] coords = command.Split(' ');
            w1 = int.Parse(coords[1]);
            d1 = int.Parse(coords[2]);
        }

        if (command[0] == 'S')
        {
            if (h1 == cubeH - 1)
            {
                Console.WriteLine("Yes");
                Console.WriteLine(w1 + " " + h1 + " " + d1);
                Environment.Exit(0);
            }
            string subcommand = command.Substring(2);
            if (subcommand == "F")
            {
                if (d1 == 0)
                {
                    Console.WriteLine("No");
                    Console.WriteLine(w1 + " " + h1 + " " + d1);
                    Environment.Exit(0);
                }
                else
                    d1--;
            }
            if (subcommand == "B")
            {
                if (d1 + 1 == cubeD)
                {
                    Console.WriteLine("No");
                    Console.WriteLine(w1 + " " + h1 + " " + d1);
                    Environment.Exit(0);
                }
                else
                    d1++;
            }
            if (subcommand == "L")
            {
                if (w1 == 0)
                {
                    Console.WriteLine("No");
                    Console.WriteLine(w1 + " " + h1 + " " + d1);
                    Environment.Exit(0);
                }
                else
                    w1--;
            }
            if (subcommand == "R")
            {
                if (w1 + 1 == cubeW)
                {
                    Console.WriteLine("No");
                    Console.WriteLine(w1 + " " + h1 + " " + d1);
                    Environment.Exit(0);
                }
                else
                    w1++;
            }
            if (subcommand == "FL")
            {
                if (d1 == 0 || w1 == 0)
                {
                    Console.WriteLine("No");
                    Console.WriteLine(w1 + " " + h1 + " " + d1);
                    Environment.Exit(0);
                }
                else
                {
                    d1--;
                    w1--;
                }
            }
            if (subcommand == "FR")
            {
                if (d1 == 0 || w1 == cubeW - 1)
                {
                    Console.WriteLine("No");
                    Console.WriteLine(w1 + " " + h1 + " " + d1);
                    Environment.Exit(0);
                }
                else
                {
                    d1--;
                    w1++;
                }
            }
            if (subcommand == "BL")
            {
                if (d1 == cubeD - 1 || w1 == 0)
                {
                    Console.WriteLine("No");
                    Console.WriteLine(w1 + " " + h1 + " " + d1);
                    Environment.Exit(0);
                }
                else
                {
                    d1++;
                    w1--;
                }
            }
            if (subcommand == "BR")
            {
                if (d1 == cubeD - 1 || w1 == cubeW - 1)
                {
                    Console.WriteLine("No");
                    Console.WriteLine(w1 + " " + h1 + " " + d1);
                    Environment.Exit(0);
                }
                else
                {
                    d1++;
                    w1++;
                }
            }
            h1++;
        }
    }

    static void Main()
    {
        string input = Console.ReadLine();
        string[] strings = input.Split(' ');
        cubeW = int.Parse(strings[0]);
        cubeH = int.Parse(strings[1]);
        cubeD = int.Parse(strings[2]);
        string[, ,] cuboid = new string[cubeW, cubeH, cubeD];
        for (int i = 0; i < cubeH; i++)
        {
            input = Console.ReadLine();
            strings = input.Split(new string[] { " | " }, StringSplitOptions.RemoveEmptyEntries);
            for (int j = 0; j < cubeD; j++)
            {
                string[] string1 = strings[j].Split(new char[] { '(', ')' }, StringSplitOptions.RemoveEmptyEntries);
                for (int k = 0; k < cubeW; k++)
                {
                    cuboid[k, i, j] = string1[k].Trim();
                }
            }
        }
        input = Console.ReadLine();
        strings = input.Split(' ');
        int ballInitW = int.Parse(strings[0]);
        int ballInitD = int.Parse(strings[1]);
        int ballInitH = 0;
        while (ballInitH < cubeH)
        {
            MoveBall(cuboid, ref ballInitW, ref ballInitH, ref ballInitD);
        }
    }
}