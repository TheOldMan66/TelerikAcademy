using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

public delegate void Message(int sec);

class MyTimer
{
    static void PrintOddMessage(int sec)
    {
        Console.WriteLine("Seconds is odd");
    }
    static void PrintEvenMessage(int sec)
    {
        Console.WriteLine("Seconds is even");
    }
    static void TimerElasped(object soruce, ElapsedEventArgs e)
    {
        Console.Write("\u0007Method is raised at {0}. ", e.SignalTime);
        Message msg = new Message(PrintEvenMessage);
        if (e.SignalTime.Second % 2 == 0)
            msg = PrintOddMessage;
        msg(e.SignalTime.Second);
    }

    static Timer timer;
    static void Main(string[] args)
    {

        Console.Write("Enter period of seconds to raise event: ");
        int period = int.Parse(Console.ReadLine());
        timer = new Timer(period * 1000);
        timer.Enabled = true;
        timer.Elapsed += new ElapsedEventHandler(TimerElasped);
        Console.WriteLine("Press ENTER key to exit (not immediately, program is running at background :) )");
        Console.ReadLine();
    }
}