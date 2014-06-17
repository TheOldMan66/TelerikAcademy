using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GSM
{
    class GSMCallHistoryTest
    {
        static void Main() // task 12
        {
            GSM phone = new GSM("TestModel", "TestManufacturer");
            phone.AddCallInHistory(new Call(DateTime.Now, "+359876543210", 300));
            phone.AddCallInHistory(new Call(DateTime.Parse("20.09.2013 18:30:00"), "+359888777666", 100));
            phone.AddCallInHistory(new Call(DateTime.Parse("10.05.2010 12:34:56"), "+359888000000", 1000));
            List<Call> calls = phone.CallHistory;
            Console.WriteLine("Call history:");
            phone.PrintCallHistory();
            decimal pricePerMinute = 0.37M;
            Console.WriteLine("For price per minute {0:C} total call costs is {1:C}",pricePerMinute,phone.CalculateCallTotalPrice(pricePerMinute));
            int index = calls.FindIndex(x => x.Duration == calls.Max(y => y.Duration));
            phone.RemoveCallListItem(index);
            Console.WriteLine();
            Console.WriteLine("Call history after removing longest call:");
            phone.PrintCallHistory();
            Console.WriteLine("For price per minute {0:C} total call costs is {1:C}", pricePerMinute, phone.CalculateCallTotalPrice(pricePerMinute));
            phone.ClearCallHistory();
            Console.WriteLine();
            Console.WriteLine("Cleared call history:");
            phone.PrintCallHistory();
            Console.WriteLine("For price per minute {0:C} total call costs is {1:C}", pricePerMinute, phone.CalculateCallTotalPrice(pricePerMinute));
        }
    }
}
