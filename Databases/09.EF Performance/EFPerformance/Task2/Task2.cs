using System;
using System.Collections.Generic;
using System.Linq;
using EntityFramework.Data;
using System.Data.Entity;
using System.Diagnostics;

namespace _02.ToListPerformance
{
    class Program
    {
        static void Main(string[] args)
        {
            TelerikAcademyEntities context = new TelerikAcademyEntities();

            Stopwatch sw = new Stopwatch();
            sw.Start();
            var allEmployeesToList = context.Employees.ToList()
                                      .Select(e => e.Address).ToList()
                                      .Select(e => e.Town).ToList()
                                      .Where(e => e.Name == "Sofia");
            Console.WriteLine("With .ToList at every step - > employee count : " + sw.ElapsedMilliseconds);
            Console.WriteLine("Employees found: " + allEmployeesToList.Count());
            Console.WriteLine();
            sw.Restart();
            var allEmployeesAtServer = context.Employees
                                               .Select(e => e.Address)
                                               .Select(e => e.Town)
                                               .Where(e => e.Name == "Sofia").ToList();
            Console.WriteLine("With .ToList at last step - > employee count : " + sw.ElapsedMilliseconds);
            Console.WriteLine("Employees found: " + allEmployeesToList.Count());
            sw.Stop();
        }
    }
}