using System;
using System.Diagnostics;

namespace ComplexOperationTimes
{
    class ComplexOperations
    {
        static void Main(string[] args)
        {
            Stopwatch stopwatch = new Stopwatch();
            int numOfIterations = 10000000;

            stopwatch.Start();
            for (int i = 0; i < numOfIterations; i++)
            {
            }
            stopwatch.Stop();
            Console.WriteLine("Empty loop (for reference). {0} iterations. Time {1} ms", numOfIterations, stopwatch.ElapsedMilliseconds);


            float floatResult = 0;
            float floatOperand1 = 1.23456789f;
            Console.WriteLine();
            stopwatch.Restart();
            for (int i = numOfIterations; i > 0; i--)
            {
                floatResult = (float)Math.Sqrt(floatOperand1);
            }
            stopwatch.Stop();
            Console.WriteLine("Square root of float. {0} iterations. Time {1} ms", numOfIterations, stopwatch.ElapsedMilliseconds);
            stopwatch.Restart();
            for (int i = numOfIterations; i > 0; i--)
            {
                floatResult = (float)Math.Log(floatOperand1);
            }
            stopwatch.Stop();
            Console.WriteLine("Natural logarithm of float. {0} iterations. Time {1} ms", numOfIterations, stopwatch.ElapsedMilliseconds);
            stopwatch.Restart();
            for (int i = numOfIterations; i > 0; i--)
            {
                floatResult = (float)Math.Sin(floatOperand1);
            }
            stopwatch.Stop();
            Console.WriteLine("Sine of float. {0} iterations. Time {1} ms", numOfIterations, stopwatch.ElapsedMilliseconds);

            double doubleResult = 0;
            double doubleOperand1 = 1.23456789;
            Console.WriteLine();
            stopwatch.Restart();
            for (int i = numOfIterations; i > 0; i--)
            {
                doubleResult = (double)Math.Sqrt(doubleOperand1);
            }
            stopwatch.Stop();
            Console.WriteLine("Square root of double. {0} iterations. Time {1} ms", numOfIterations, stopwatch.ElapsedMilliseconds);
            stopwatch.Restart();
            for (int i = numOfIterations; i > 0; i--)
            {
                doubleResult = (double)Math.Log(doubleOperand1);
            }
            stopwatch.Stop();
            Console.WriteLine("Natural logarithm of double. {0} iterations. Time {1} ms", numOfIterations, stopwatch.ElapsedMilliseconds);
            stopwatch.Restart();
            for (int i = numOfIterations; i > 0; i--)
            {
                doubleResult = (double)Math.Sin(doubleOperand1);
            }
            stopwatch.Stop();
            Console.WriteLine("Sine of double. {0} iterations. Time {1} ms", numOfIterations, stopwatch.ElapsedMilliseconds);

            decimal decimalResult = 0;
            decimal decimalOperand1 = 1.23456789m;
            Console.WriteLine();
            stopwatch.Restart();
            for (int i = numOfIterations; i > 0; i--)
            {
                decimalResult = (decimal)Math.Sqrt((double)decimalOperand1);
            }
            stopwatch.Stop();
            Console.WriteLine("Square root of decimal. {0} iterations. Time {1} ms", numOfIterations, stopwatch.ElapsedMilliseconds);
            stopwatch.Restart();
            for (int i = numOfIterations; i > 0; i--)
            {
                decimalResult = (decimal)Math.Log((double)decimalOperand1);
            }
            stopwatch.Stop();
            Console.WriteLine("Natural logarithm of decimal. {0} iterations. Time {1} ms", numOfIterations, stopwatch.ElapsedMilliseconds);
            stopwatch.Restart();
            for (int i = numOfIterations; i > 0; i--)
            {
                decimalResult = (decimal)Math.Sin((double)decimalOperand1);
            }
            stopwatch.Stop();
            Console.WriteLine("Sine of decimal. {0} iterations. Time {1} ms", numOfIterations, stopwatch.ElapsedMilliseconds);
        }
    }
}
