/* Write methods that calculate the surface of a triangle by given: 
 * - Side and an altitude to it; 
 * - Three sides; 
 * - Two sides and an angle between them. 
 * Use System.Math. */

using System;

class Triangle
{
    private double area;

    public double Area
    { get { return area; } }

    public Triangle(float side, float altitude)
    {
        area = 0.5d * side * altitude;
    }

    public Triangle(float sideA, float sideB, float sideC)
    {
        double s = (sideA + sideB + sideC) / 2.0d;
        area = Math.Sqrt(s * (s - sideA) * (s - sideB) * (s - sideC));
    }
    public Triangle(float sideA, float sideB, double angle)
    {
        area = 0.5d * sideA * sideB * Math.Sin(angle * Math.PI / 180);
    }

}

class TriangleSample
{
    static void Main()
    {
        do
        {

            Console.Clear();
            Console.WriteLine("Calculate surface of a trinagle by:");
            Console.WriteLine("A. Side and altitude to it");
            Console.WriteLine("B. Three sides");
            Console.WriteLine("C. Two sides and an angle (in degrees) between them");
            Console.WriteLine("D. Exit");
            string choice;
            do
            {
                Console.Write("Enter A, B, C or D and press <Enter>: ");
                choice = Console.ReadLine().ToUpper();
            } while (choice != "A" && choice != "B" && choice != "C" && choice != "D");
            Triangle tri = null;
            float sideA;
            float sideB;
            float sideC;
            float altitude;
            double angle;
            switch (choice)
            {
                case "A":
                    Console.Write("Enter lenght of side: ");
                    sideA = float.Parse(Console.ReadLine());
                    Console.Write("Enter lenght of altitude: ");
                    altitude = float.Parse(Console.ReadLine());
                    tri = new Triangle(sideA, altitude);
                    break;
                case "B":
                    Console.Write("Enter lenght of side A: ");
                    sideA = float.Parse(Console.ReadLine());
                    Console.Write("Enter lenght of side B: ");
                    sideB = float.Parse(Console.ReadLine());
                    Console.Write("Enter lenght of side C: ");
                    sideC = float.Parse(Console.ReadLine());
                    tri = new Triangle(sideA, sideB, sideC);
                    break;
                case "C":
                    Console.Write("Enter lenght of side A: ");
                    sideA = float.Parse(Console.ReadLine());
                    Console.Write("Enter lenght of side B: ");
                    sideB = float.Parse(Console.ReadLine());
                    Console.Write("Enter angle (in degrees): ");
                    angle = double.Parse(Console.ReadLine());
                    tri = new Triangle(sideA, sideB, angle);
                    break;
                case "D":
                    return;
                    break;
            }
            Console.WriteLine("The area of triangle is {0}.", tri.Area);
            Console.ReadLine();
        } while (true);
    }
}
