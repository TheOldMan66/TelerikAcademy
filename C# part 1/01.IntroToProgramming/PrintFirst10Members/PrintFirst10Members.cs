using System;

class PrintFirst10Members
{
    static void Main()
    {
        for (int i = 2; i <= 10; i++)
        {
            if (i % 2 == 1)
            {
                Console.Write("-");
            }
            Console.Write(i + ", ");

        }
        Console.WriteLine(" ...");
    }
}