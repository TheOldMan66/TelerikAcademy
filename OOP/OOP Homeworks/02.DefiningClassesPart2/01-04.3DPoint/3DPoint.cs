using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace _01._3DPoint
{
    class ThreeDimensionalPoint
    {
        static class Distance3D // task 3
        {
            public static double Distance(Point3D point1, Point3D point2)
            {
                double dx = point1.x - point2.x;
                double dy = point1.y - point2.y;
                double dz = point1.z - point2.z;

                return Math.Sqrt(dx * dx + dy * dy * dz * dz);
            }
        }

        class Path // task 4
        {
            private List<Point3D> points;

            public Path()
            {
                points = new List<Point3D>();
            }

            public void AddPoint(Point3D point)
            {
                points.Add(point);
            }

            public void ClearPath()
            {
                points.Clear();
            }

            public List<Point3D> GetPath()
            {
                return this.points;
            }

        }

        static class PathStorage // task 4
        {
            public static Path LoadPath()
            {
                Path newPath = new Path();
                string s;
                using (StreamReader reader = new StreamReader("path.txt"))
                {
                    string[] fields;
                    s = reader.ReadLine();
                    while (s != null)
                    {
                        fields = s.Split(' ');
                        newPath.AddPoint(new Point3D(int.Parse(fields[0]), int.Parse(fields[1]), int.Parse(fields[2])));
                        s = reader.ReadLine();
                    }
                }
                return newPath;
            }

            public static void SavePath(Path path)
            {
                using (StreamWriter writer = new StreamWriter("path.txt"))
                    foreach (Point3D point in path.GetPath())
                        writer.WriteLine("{0} {1} {2}", point.x, point.y, point.z);
            }
        }

        public struct Point3D // task 1
        {
            public int x;
            public int y;
            public int z;
            private static readonly Point3D pointZero = new Point3D(0, 0, 0); // task 2

            public Point3D(int x, int y, int z)
            {
                this.x = x;
                this.y = y;
                this.z = z;
            }

            public static Point3D GetZeroPoint()
            {
                return pointZero;
            }

            public override string ToString()
            {
                return string.Format("[X={0,3}, Y={1,3}, Z={2,3}]", this.x, this.y, this.z);
            }
        }

        static void Main(string[] args)
        {
            Random rnd = new Random();
            Path path = new Path();
            Console.WriteLine("Generating new path:");
            for (int i = 0; i < 10; i++)
            {
                Point3D point = new Point3D(rnd.Next(1000), rnd.Next(1000), rnd.Next(1000));
                path.AddPoint(point);
                Console.WriteLine(point);
            }
            Console.WriteLine("Saving path to file");
            PathStorage.SavePath(path);
            Console.WriteLine("Saving done");
            Console.WriteLine("Clearing path");
            path.ClearPath();
            Console.WriteLine("Loading path from file");
            path = PathStorage.LoadPath();
            Console.WriteLine("loading successful. Points are:");
            List<Point3D> tmpPath = path.GetPath();
            for (int i = 0; i < tmpPath.Count; i++)
            {
                Console.Write("Point {0}: {1}", i, tmpPath[i]);
                if (i > 0)
                    Console.Write(" Distance from prev.point: {0}", Distance3D.Distance(tmpPath[i - 1], tmpPath[i]));
                Console.WriteLine();
            }
        }
    }
}
