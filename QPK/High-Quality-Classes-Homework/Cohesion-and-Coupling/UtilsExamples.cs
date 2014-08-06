using System;

namespace CohesionAndCoupling
{
    class UtilsExamples
    {
        static void Main()
        {
            Console.WriteLine(FileNames.GetFileExtension("example.pdf"));
            Console.WriteLine(FileNames.GetFileExtension("example.new.pdf"));
            Console.WriteLine(FileNames.GetFileExtension("example"));
            Console.WriteLine(FileNames.GetFileNameWithoutExtension("example"));
            Console.WriteLine(FileNames.GetFileNameWithoutExtension("example.pdf"));
            Console.WriteLine(FileNames.GetFileNameWithoutExtension("example.new.pdf"));

            Console.WriteLine("Distance in the 2D space = {0:f2}",
                Stereometry.CalcDistance2D(1, -2, 3, 4));
            Console.WriteLine("Distance in the 3D space = {0:f2}",
                Stereometry.CalcDistance3D(5, 2, -1, 3, -6, 4));

            double figureWidth = 3;
            double figureHeight = 4;
            double figureDepth = 5;
            Console.WriteLine("Volume = {0:f2}", Stereometry.CalcVolume(figureWidth, figureHeight, figureDepth));
            Console.WriteLine("Diagonal XYZ = {0:f2}", Stereometry.CalcDistance3D(figureWidth, figureHeight, figureDepth));
            Console.WriteLine("Diagonal XY = {0:f2}", Stereometry.CalcDistance2D(figureWidth, figureHeight));
            Console.WriteLine("Diagonal XZ = {0:f2}", Stereometry.CalcDistance2D(figureWidth, figureDepth));
            Console.WriteLine("Diagonal YZ = {0:f2}", Stereometry.CalcDistance2D(figureHeight, figureDepth));
        }
    }
}
