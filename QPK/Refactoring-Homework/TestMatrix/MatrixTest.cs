using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MatrixWalk;

namespace TestMatrix
{
    [TestClass]
    public class MatrixCreationTest
    {
        [TestMethod]
        public void SquareMatrixCreation()
        {
            int[,] testMatrix1 = Matrix.Solve(1, 1);
            int[,] testMatrix2 = Matrix.Solve(100, 100);
        }

        [TestMethod]
        public void NonSquareMatrixCreation()
        {
            int[,] testMatrix1 = Matrix.Solve(1, 10);
            int[,] testMatrix2 = Matrix.Solve(2, 100);
        }
        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void ZeroSizeMatrixCreation()
        {
            int[,] testMatrix1 = Matrix.Solve(0, 5);
        }
    }

    [TestClass]
    public class MatrixSolveTest
    {
        [TestMethod]
        public void SquareMatrixWithEvenElementsSolve()
        {

            int[,] testMatrix1 = new int[2, 2] { { 1, 4 }, { 3, 2 } };
            int[,] testMatrix2 = Matrix.Solve(2, 2);
            for (int i = 0; i < 2; i++)
            {
                for (int j = 0; j < 2; j++)
                {
                    Assert.AreEqual(testMatrix1[i, j], testMatrix2[i, j], "Matrix solve error at 2x2");
                }
            }
        }

        [TestMethod]
        public void SquareMatrixWithOddElementsSolve()
        {

            int[,] testMatrix1 = new int[5, 5] { 
                {1, 13, 14, 15, 16},
                {12,  2, 21, 22, 17},
                {11, 23,  3, 20, 18},
                {10, 25, 24,  4, 19},
                { 9,  8,  7,  6,  5}
            };
            int[,] testMatrix2 = Matrix.Solve(5, 5);
            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    Assert.AreEqual(testMatrix1[i, j], testMatrix2[i, j], "Matrix solve error at 5x5");
                }
            }
        }

        [TestMethod]
        public void NonSquareMatrixSolve()
        {

            int[,] testMatrix1 = new int[2, 10] { 
                {1,  4,  5,  6,  7,  8,  9, 10, 11, 12},
                {3,  2, 20, 19, 18, 17, 16, 15, 14, 13}
            };
            int[,] testMatrix2 = Matrix.Solve(2, 10);
            for (int i = 0; i < 2; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    Assert.AreEqual(testMatrix1[i, j], testMatrix2[i, j], "Matrix solve error at 2x10");
                }
            }
        }

    }

}
