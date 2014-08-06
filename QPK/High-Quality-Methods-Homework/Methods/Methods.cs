using System;

namespace Methods
{
    class Methods
    {
        static double CalcTriangleArea(double a, double b, double c)
        {
            if (a <= 0 || b <= 0 || c <= 0)
            {
                throw new ArgumentException("Sides should be positive.");
            }
            if (a >= b + c || b >= a + c || c >= a + b)
            {
                throw new ArgumentException("Sides cannot form triangle.");
            }
            double s = (a + b + c) / 2;
            double area = Math.Sqrt(s * (s - a) * (s - b) * (s - c));
            return area;
        }

        static string NumberToDigit(int number)
        {
            switch (number)
            {
                case 0: return "zero";
                case 1: return "one";
                case 2: return "two";
                case 3: return "three";
                case 4: return "four";
                case 5: return "five";
                case 6: return "six";
                case 7: return "seven";
                case 8: return "eight";
                case 9: return "nine";
                default: throw new ArgumentOutOfRangeException("Number outside range [0..9].");
            }
        }

        static int FindMax(params int[] elements)
        {
            if (elements == null || elements.Length == 0)
            {
                throw new ArgumentNullException("Cannot find max form empty array");
            }

            int max = elements[0];
            for (int i = 1; i < elements.Length; i++)
            {
                if (elements[i] > elements[0])
                {
                    max = elements[i];
                }
            }
            return max;
        }

        static void PrintAsNumber(object number, string format)
        {
            switch (format)
            {
                case "f": Console.WriteLine("{0:f2}", number); break;
                case "%": Console.WriteLine("{0:p0}", number); break;
                case "r": Console.WriteLine("{0,8}", number); break;
                default: throw new ArgumentOutOfRangeException("Unrecognized format string");
            }
        }


        static double CalcDistance(double x1, double y1, double x2, double y2)
        {
            double deltaX = x2 - x1;
            double deltaY = y2 - y1;
            double distance = Math.Sqrt(deltaX * deltaX + deltaY * deltaY);
            return distance;
        }
        static bool isHorizontal (double x1, double y1, double x2, double y2)
        {
            return Math.Round(x1,15) == Math.Round(x2,15); 
        }
        static bool isVertical(double x1, double y1, double x2, double y2)
        {
            return Math.Round(y1, 15) == Math.Round(y2, 15);
        }

        static void Main()
        {
            Console.WriteLine(CalcTriangleArea(3, 4, 5));
            
            Console.WriteLine(NumberToDigit(5));
            
            Console.WriteLine(FindMax(5, -1, 3, 2, 14, 2, 3));
            
            PrintAsNumber(1.3, "f");
            PrintAsNumber(0.75, "%");
            PrintAsNumber(2.30, "r");

            var x1 = 3;
            var y1 = -1;
            var x2 = 3;
            var y2 = 2.5;
            Console.WriteLine(CalcDistance(x1,y1,x2,y2));
            Console.WriteLine("Horizontal? " + isHorizontal(x1,y1,x2,y2));
            Console.WriteLine("Vertical? " + isVertical(x1, y1, x2, y2));

            Student peter = new Student() { FirstName = "Peter", LastName = "Ivanov", DateOfBirth = "17.03.1992", CityOfBirth = "Sofia" };

            Student stella = new Student() { FirstName = "Stella", LastName = "Markova", DateOfBirth = "03.11.1993", CityOfBirth = "Vidin"};
            stella.OtherInfo = "Gamer, high results";

            Console.WriteLine("{0} older than {1} -> {2}",
                peter.FirstName, stella.FirstName, peter.IsOlderThan(stella));
        }
    }
}
