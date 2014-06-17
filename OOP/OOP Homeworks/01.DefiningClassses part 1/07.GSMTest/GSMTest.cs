using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GSM
{
    class GSMTest // task 7
    {
        static void Main()
        {
            GSMBattery battery = new GSMBattery(100, 10, GSMBattery.batteryType.NiMH);
            GSMDisplay display = new GSMDisplay(600, 800, 65536);
            GSM[] phones = new GSM[3]; 
            phones[0] = new GSM("Asha", "Nokia", null, "pesho", battery, display);
            phones[1] = new GSM("Galaxy", "Samsung", 600);
            phones[2] = new GSM("LG", "Optimus", 800, null, null, new GSMDisplay(480, 640, 65535));
            foreach (GSM phone in phones)
            {
                Console.WriteLine(phone);
                Console.WriteLine();
            }
            Console.WriteLine();
            Console.WriteLine(GSM.IPhone4S);
        }
    }
}