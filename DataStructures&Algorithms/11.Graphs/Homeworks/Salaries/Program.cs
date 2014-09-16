using System;
using System.Linq;
using System.IO;

class Program
{
    static void Main()
    {
        var count = int.Parse(Console.ReadLine());
        var salary = new long[count];
        var managedCount = new long[count];
        var edge = new bool[count, count];
        for (var i = 0; i < count; ++i)
        {
            var j = 0;

            foreach (var ch in Console.ReadLine().Trim())
            {
                edge[i, j] = (ch == 'Y');
                managedCount[i] += edge[i, j] ? 1 : 0;
                j += 1;
            }

            if (managedCount[i] == 0)
            {
                salary[i] = 1;
            }
        }

        Func<int, long> getSalary = null;

        getSalary = person =>
        {
            if (salary[person] == 0)
            {
                for (var j = 0; j < count; ++j)
                {
                    if (edge[person, j])
                    {
                        salary[person] += getSalary(j);
                    }
                }
            }
            return salary[person];
        };

        long total = Enumerable.Range(0, count)
                               .OrderBy(who => managedCount[who])
                               .Select(getSalary)
                               .Sum();

        Console.WriteLine(total);
    }
}