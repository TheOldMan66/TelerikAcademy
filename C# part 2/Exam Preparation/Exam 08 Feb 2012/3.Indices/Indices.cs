using System;
using System.Collections.Generic;

class Indices
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        string s = Console.ReadLine();
        string[] inputs = s.Split(' ');
        //        int[] elements = new int[n];
        bool[] visited = new bool[n];
        List<int> sequence = new List<int>(n);
        int currElement = 0;
        while (!visited[currElement])
        {
//            Console.WriteLine(currElement);
            visited[currElement] = true;
            sequence.Add(currElement);
            currElement = int.Parse(inputs[currElement]);
            if (currElement >= inputs.Length || currElement < 0) break;
        }
        if (currElement < inputs.Length && currElement > -1)
        {
            int startOfSequence = sequence[currElement];
            for (int i = 0; i < sequence.Count; i++)
            {
                if (i > 0)
                {
                    if (i == startOfSequence)
                        Console.Write("(");
                    else
                        Console.Write(" ");
                }
                Console.Write(sequence[i]);
            }
            Console.Write(")");
        }
        else
        {
            for (int i = 0; i < sequence.Count; i++)
            {
                if (i > 0)
                    Console.Write(" ");
                Console.Write(sequence[i]);
            }
        }
    }
}