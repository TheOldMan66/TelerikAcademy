using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityFramework.Data;
using System.Data.Entity;
using System.Diagnostics;

namespace Task1
{
    class Task1
    {
        static TelerikAcademyEntities context = new TelerikAcademyEntities();

        static void WithoutInclude()
        {
            foreach (var employee in context.Employees)
            {
                var fName = employee.FirstName;
                var lName = employee.LastName;
                var dept = employee.Department.Name;
                var town = employee.Address.Town.Name;
            }
            Console.WriteLine("Without incule - > employee count : " + context.Employees.Count());
        }

        static void WithInclude()
        {
            foreach (var employee in context.Employees.Include("Address.Town").Include("Department"))
            {
                var fName = employee.FirstName;
                var lName = employee.LastName;
                var dept = employee.Department.Name;
                var town = employee.Address.Town.Name;
            }
            Console.WriteLine("With incule - > employee count : " + context.Employees.Count());
        }

        static void Main(string[] args)
        {
            Stopwatch sw = new Stopwatch();
            sw.Start();
            WithInclude();
            Console.WriteLine("Time: {0} milliseconds",sw.ElapsedMilliseconds);
            Console.WriteLine();
            sw.Restart();
            WithoutInclude();
            Console.WriteLine("Time: {0} milliseconds", sw.ElapsedMilliseconds);
            sw.Stop();
        }
    }
}