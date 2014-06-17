using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03.RangeException
{
    class ExceptionTest
    {
        static int minIntValue = 0;
        static int maxIntValue = 100;
        static DateTime minDateValue = DateTime.Parse("1.1.1980");
        static DateTime maxDateValue = DateTime.Parse("12.30.2013");
        static void Main(string[] args)
        {
            DateTime enteredDate = DateTime.Today;
            int enteredInt = 0;
            while (true)
            {
                Console.Write("Enter int in range (0-100) or date in range (1.1.1980 - 30.12.2013): ");
                string s = Console.ReadLine();
                try
                {
                    enteredDate = DateTime.ParseExact(s,"d.M.yyyy",CultureInfo.InvariantCulture);
                }
                catch (FormatException)
                {
                    try
                    {
                        enteredInt = int.Parse(s);
                    }
                    catch (FormatException)
                    {
                        Console.WriteLine("Entered data is not int or datetime");
                    }
                    Console.WriteLine("Valid integer");
                    if (enteredInt < minIntValue || enteredInt > maxIntValue)
                    {
                        throw new InvalidRangeException<int>("integer", minIntValue, maxIntValue);
                    }
                    continue;
                }
                Console.WriteLine("Valid datetime");
                if (enteredDate < minDateValue || enteredDate > maxDateValue)
                {
                        throw new InvalidRangeException<DateTime>("date", minDateValue, maxDateValue);                    
                }
            }
        }
    }
}
