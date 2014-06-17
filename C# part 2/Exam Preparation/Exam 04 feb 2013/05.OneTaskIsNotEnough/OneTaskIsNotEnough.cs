using System;
using System.Collections.Generic;

class OneTaskIsNotEnough
{
    static void CreateCollection(List<int> lamps, int step)
    {
        if (lamps.Count == 1)
        {
            Console.WriteLine(lamps[0]+1);
            Console.WriteLine(DateTime.Now.TimeOfDay);
            return;
        }
        step++;
        List<int> newLamps = new List<int>(lamps.Count / 2);
        for (int i = 0; i < lamps.Count; i++)
            if (i % step != 0)
                newLamps.Add(lamps[i]);
        CreateCollection(newLamps, step);
    }

    static void Main()
    {
        int numLamps = int.Parse(Console.ReadLine());
        Console.WriteLine(DateTime.Now.TimeOfDay);
        List<int> darkLights = new List<int>(numLamps);
        for (int i = 1; i < numLamps; i = i + 2)
        {
            darkLights.Add(i);
        }
        int step = 2;

        CreateCollection(darkLights, step);
        Console.WriteLine(darkLights[0] + 1);
        Console.WriteLine(DateTime.Now.TimeOfDay);
    }
}