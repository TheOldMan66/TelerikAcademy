using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CohesionAndCoupling
{
    class Stereometry
    {
        public static double CalcDistance2D(double x1, double y1, double x2 = 0, double y2 = 0)
        {
            double distance = Math.Sqrt((x2 - x1) * (x2 - x1) + (y2 - y1) * (y2 - y1));
            return distance;
        }

        public static double CalcDistance3D(double x1, double y1, double z1, double x2 = 0, double y2 = 0, double z2 = 0)
        {
            double distanceXY = CalcDistance2D(x1, y1, x2, y2);
            double distance = Math.Sqrt(distanceXY * distanceXY + (z2 - z1) * (z2 - z1));
            return distance;
        }

        public static double CalcVolume(double width, double height, double depth)
        {
            double volume = width * height * depth;
            return volume;
        }
    }
}
