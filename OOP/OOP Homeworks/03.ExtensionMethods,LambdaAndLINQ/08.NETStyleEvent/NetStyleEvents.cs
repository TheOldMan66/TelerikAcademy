using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Timers;

namespace _08.NETStyleEvent
{
    public class ClockEventArgs : EventArgs
    {
        private TimeSpan span;
        public ClockEventArgs(TimeSpan ts)
        {
            span = ts;
        }
        public TimeSpan GetTime
        {
            get { return span; }
            set { span = value; }
        }
    }

    class Clock
    {
        public event EventHandler<ClockEventArgs> RaiseClockEvent;

        private Timer timer = new Timer();

        public void Run()
        {
            timer.Interval = 1000;
            timer.Elapsed += new ElapsedEventHandler(TimerEventIsRaised);
            timer.Start();

        }

        private void TimerEventIsRaised(object source, ElapsedEventArgs e)
        {
            EventHandler<ClockEventArgs> handler = RaiseClockEvent;
            if (handler != null)
                handler(this, new ClockEventArgs(e.SignalTime.TimeOfDay));
        }
    }

    class TimerDisplay
    {
        private int number;
        private int time;
        private int count;
        public TimerDisplay(int display, Clock clock, int interval)
        {
            number = display;
            clock.RaiseClockEvent += HandleClockEvent;
            time = interval;
        }

        void HandleClockEvent(object sender, ClockEventArgs e)
        {
            count++;
            if (count == time)
            {
                count = 0;
                Console.WriteLine("Timer {0} say: Time is {1}", number, e.GetTime);
            }
        }
    }

    class NetStyleEventsDemo
    {
        static void Main(string[] args)
        {
            Console.Write("Enter the interval (in seconds) for timer 1: ");
            int interval1 = int.Parse(Console.ReadLine());
            Console.Write("Enter the interval (in seconds) for timer 2: ");
            int interval2 = int.Parse(Console.ReadLine());
            Clock clock = new Clock();
            clock.Run();
            TimerDisplay display1 = new TimerDisplay(1, clock,interval1);
            TimerDisplay display2 = new TimerDisplay(2, clock,interval2);
            Console.ReadLine();
        }
    }
}
