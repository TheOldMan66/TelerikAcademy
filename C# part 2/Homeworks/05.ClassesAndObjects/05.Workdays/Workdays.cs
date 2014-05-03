/* Write a method that calculates the number of workdays between today and given date, 
 * passed as parameter. Consider that workdays are all days from Monday to Friday except 
 * a fixed list of public holidays specified preliminary as array. */

using System;
using System.Threading;
using System.Globalization;

class Workdays
{
    static readonly DateTime[] holidays =
    {
            new DateTime (2013,01,01), // new year
            new DateTime (2013,03,03), // 3-rd march
            new DateTime (2013,05,01), // 1-st may
            new DateTime (2013,05,03), // 3-th may (Easter)
            new DateTime (2013,05,06), // 6-th may (st George)
            new DateTime (2013,05,24), // 24-th may
            new DateTime (2013,09,06), // 6-th september
            new DateTime (2013,09,22), // 22-th september
            new DateTime (2013,12,24), // Christmass
            new DateTime (2013,12,25), // Christmass
        };


    static int GetWorkDays(DateTime startDate, DateTime endDate)
    {
        int workdays = 0;
        int weekends = 0;
        int officialHolidays = 0;
        do
        {
            startDate = startDate.AddDays(1);
            if (startDate.DayOfWeek == DayOfWeek.Saturday || startDate.DayOfWeek == DayOfWeek.Sunday)
            {
                weekends++;     // it's a weekend (sathurday or sunday)
                workdays--;
            }
            else
            {
                for (int i = 0; i < holidays.Length; i++) // let's check if day is official holiday
                {
                    if (holidays[i].Day == startDate.Day && holidays[i].Month == startDate.Month)
                    {
                        officialHolidays++;
                        workdays--;
                        break;
                    }
                }
            }
            workdays++;
        } while (startDate < endDate);
        return workdays;
    }

    static void Main()
    {
        Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;
        DateTime endDate;
        bool isCorrect;
        do
        {
            Console.WriteLine("Program will calculate days from tomorrow to desired date (BOTH DAYS INCLUSIVE)");
            Console.Write("Enter desirable date in future (using MM/DD/YYYY format): ");
            isCorrect = DateTime.TryParse(Console.ReadLine(), out endDate);
            isCorrect = isCorrect && (endDate > DateTime.Now.Date);
            if (!isCorrect)
                Console.WriteLine("Invalid date. Try again.");
        } while (!isCorrect);

        // date is in correct format and is in the future.

        int workDays = GetWorkDays(DateTime.Now.Date, endDate);
        Console.WriteLine("From {0:MM/dd/yyyy} to {1:MM/dd/yyyy} has {2} workdays.", DateTime.Now.Date, endDate.Date, workDays);
    }
}