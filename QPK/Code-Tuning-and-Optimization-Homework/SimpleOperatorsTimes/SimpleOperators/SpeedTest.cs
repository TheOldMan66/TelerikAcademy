using System;
using System.Diagnostics;

namespace SimpleOperators
{
    class SpeedTest
    {
        static void Main(string[] args)
        {
            Stopwatch stopwatch = new Stopwatch();
            int numOfIterations = 10000000;

            int intResult = 0;
            int intOperand1 = 2;
            int intOperand2 = 7;
            stopwatch.Start();
            for (int i = 0; i < numOfIterations; i++)
            {
            }
            stopwatch.Stop();
            Console.WriteLine("Empty loop (for reference). {0} iterations. Time {1} ms", numOfIterations, stopwatch.ElapsedMilliseconds);
            stopwatch.Restart();
            Console.WriteLine();
            stopwatch.Restart();
            for (int i = numOfIterations; i > 0; i--)
            {
                intResult = intOperand1 + intOperand2;
            }
            stopwatch.Stop();
            Console.WriteLine("Addition of two integers. {0} iterations. Time {1} ms", numOfIterations, stopwatch.ElapsedMilliseconds);
            stopwatch.Restart();
            for (int i = numOfIterations; i > 0; i--)
            {
                intResult = intOperand1 - intOperand2;
            }
            stopwatch.Stop();
            Console.WriteLine("Subtraction of two integers. {0} iterations. Time {1} ms", numOfIterations, stopwatch.ElapsedMilliseconds);
            intResult = 0;
            stopwatch.Restart();
            for (int i = numOfIterations; i > 0; i--)
            {
                intResult++;
            }
            stopwatch.Stop();
            Console.WriteLine("Increment of integer. {0} iterations. Time {1} ms", numOfIterations, stopwatch.ElapsedMilliseconds);
            stopwatch.Restart();
            for (int i = numOfIterations; i > 0; i--)
            {
                intResult = intOperand1 * intOperand2;
            }
            stopwatch.Stop();
            Console.WriteLine("Multiply of two integers. {0} iterations. Time {1} ms", numOfIterations, stopwatch.ElapsedMilliseconds);
            stopwatch.Restart();
            for (int i = numOfIterations; i > 0; i--)
            {
                intResult = intOperand2 / intOperand1;
            }
            stopwatch.Stop();
            Console.WriteLine("Division of two integers. {0} iterations. Time {1} ms", numOfIterations, stopwatch.ElapsedMilliseconds);

            long longResult = 0;
            long longOperand1 = 100;
            long longOperand2 = 300;
            Console.WriteLine();
            stopwatch.Restart();
            for (int i = numOfIterations; i > 0; i--)
            {
                longResult = longOperand1 + longOperand2;
            }
            stopwatch.Stop();
            Console.WriteLine("Addition of two longs. {0} iterations. Time {1} ms", numOfIterations, stopwatch.ElapsedMilliseconds);
            stopwatch.Restart();
            for (int i = numOfIterations; i > 0; i--)
            {
                longResult = longOperand1 - longOperand2;
            }
            stopwatch.Stop();
            Console.WriteLine("Subtraction of two longs. {0} iterations. Time {1} ms", numOfIterations, stopwatch.ElapsedMilliseconds);
            intResult = 0;
            stopwatch.Restart();
            for (int i = numOfIterations; i > 0; i--)
            {
                longResult++;
            }
            stopwatch.Stop();
            Console.WriteLine("Increment of long. {0} iterations. Time {1} ms", numOfIterations, stopwatch.ElapsedMilliseconds);
            stopwatch.Restart();
            for (int i = numOfIterations; i > 0; i--)
            {
                longResult = longOperand1 * longOperand2;
            }
            stopwatch.Stop();
            Console.WriteLine("Multiply of two longs. {0} iterations. Time {1} ms", numOfIterations, stopwatch.ElapsedMilliseconds);
            stopwatch.Restart();
            for (int i = numOfIterations; i > 0; i--)
            {
                longResult = longOperand1 / longOperand2;
            }
            stopwatch.Stop();
            Console.WriteLine("Division of two longs. {0} iterations. Time {1} ms", numOfIterations, stopwatch.ElapsedMilliseconds);

            float floatResult = 0;
            float floatOperand1 = 123.456789f;
            float floatOperand2 = 9876.54321f;
            Console.WriteLine();
            stopwatch.Restart();
            for (int i = numOfIterations; i > 0; i--)
            {
                floatResult = floatOperand1 + floatOperand2;
            }
            stopwatch.Stop();
            Console.WriteLine("Addition of two floats. {0} iterations. Time {1} ms", numOfIterations, stopwatch.ElapsedMilliseconds);
            stopwatch.Restart();
            for (int i = numOfIterations; i > 0; i--)
            {
                floatResult = floatOperand1 - floatOperand2;
            }
            stopwatch.Stop();
            Console.WriteLine("Subtraction of two floats. {0} iterations. Time {1} ms", numOfIterations, stopwatch.ElapsedMilliseconds);
            intResult = 0;
            stopwatch.Restart();
            for (int i = numOfIterations; i > 0; i--)
            {
                floatResult++;
            }
            stopwatch.Stop();
            Console.WriteLine("Increment of float. {0} iterations. Time {1} ms", numOfIterations, stopwatch.ElapsedMilliseconds);
            stopwatch.Restart();
            for (int i = numOfIterations; i > 0; i--)
            {
                floatResult = floatOperand1 * floatOperand2;
            }
            stopwatch.Stop();
            Console.WriteLine("Multiply of two floats. {0} iterations. Time {1} ms", numOfIterations, stopwatch.ElapsedMilliseconds);
            stopwatch.Restart();
            for (int i = numOfIterations; i > 0; i--)
            {
                floatResult = floatOperand1 / floatOperand2;
            }
            stopwatch.Stop();
            Console.WriteLine("Division of two floats. {0} iterations. Time {1} ms", numOfIterations, stopwatch.ElapsedMilliseconds);

            double doubleResult = 0;
            double doubleOperand1 = 123.456789;
            double doubleOperand2 = 9876.54321;
            Console.WriteLine();
            stopwatch.Restart();
            for (int i = numOfIterations; i > 0; i--)
            {
                doubleResult = doubleOperand1 + doubleOperand2;
            }
            stopwatch.Stop();
            Console.WriteLine("Addition of two doubles. {0} iterations. Time {1} ms", numOfIterations, stopwatch.ElapsedMilliseconds);
            stopwatch.Restart();
            for (int i = numOfIterations; i > 0; i--)
            {
                doubleResult = doubleOperand1 - doubleOperand2;
            }
            stopwatch.Stop();
            Console.WriteLine("Subtraction of two doubles. {0} iterations. Time {1} ms", numOfIterations, stopwatch.ElapsedMilliseconds);
            intResult = 0;
            stopwatch.Restart();
            for (int i = numOfIterations; i > 0; i--)
            {
                doubleResult++;
            }
            stopwatch.Stop();
            Console.WriteLine("Increment of double. {0} iterations. Time {1} ms", numOfIterations, stopwatch.ElapsedMilliseconds);
            stopwatch.Restart();
            for (int i = numOfIterations; i > 0; i--)
            {
                doubleResult = doubleOperand1 * doubleOperand2;
            }
            stopwatch.Stop();
            Console.WriteLine("Multiply of two doubles. {0} iterations. Time {1} ms", numOfIterations, stopwatch.ElapsedMilliseconds);
            stopwatch.Restart();
            for (int i = numOfIterations; i > 0; i--)
            {
                doubleResult = doubleOperand1 / doubleOperand2;
            }
            stopwatch.Stop();
            Console.WriteLine("Division of two doubles. {0} iterations. Time {1} ms", numOfIterations, stopwatch.ElapsedMilliseconds);

            decimal decimalResult = 0;
            decimal decimalOperand1 = 123.456789m;
            decimal decimalOperand2 = 9876.54321m;
            Console.WriteLine();
            stopwatch.Restart();
            for (int i = numOfIterations; i > 0; i--)
            {
                decimalResult = decimalOperand1 + decimalOperand2;
            }
            stopwatch.Stop();
            Console.WriteLine("Addition of two decimals. {0} iterations. Time {1} ms", numOfIterations, stopwatch.ElapsedMilliseconds);
            stopwatch.Restart();
            for (int i = numOfIterations; i > 0; i--)
            {
                decimalResult = decimalOperand1 - decimalOperand2;
            }
            stopwatch.Stop();
            Console.WriteLine("Subtraction of two decimals. {0} iterations. Time {1} ms", numOfIterations, stopwatch.ElapsedMilliseconds);
            intResult = 0;
            stopwatch.Restart();
            for (int i = numOfIterations; i > 0; i--)
            {
                decimalResult++;
            }
            stopwatch.Stop();
            Console.WriteLine("Increment of decimal. {0} iterations. Time {1} ms", numOfIterations, stopwatch.ElapsedMilliseconds);
            stopwatch.Restart();
            for (int i = numOfIterations; i > 0; i--)
            {
                decimalResult = decimalOperand1 * decimalOperand2;
            }
            stopwatch.Stop();
            Console.WriteLine("Multiply of two decimals. {0} iterations. Time {1} ms", numOfIterations, stopwatch.ElapsedMilliseconds);
            stopwatch.Restart();
            for (int i = numOfIterations; i > 0; i--)
            {
                decimalResult = decimalOperand1 / decimalOperand2;
            }
            stopwatch.Stop();
            Console.WriteLine("Division of two decimals. {0} iterations. Time {1} ms", numOfIterations, stopwatch.ElapsedMilliseconds);
            Console.WriteLine("Try this test with 'debug' and 'release' builds and see differences.");
        }
    }
}
