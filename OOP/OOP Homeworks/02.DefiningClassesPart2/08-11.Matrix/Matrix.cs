using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _08_11.Matrix
{
     public class MyVersion : Attribute
    {
        private int major;
        private int minor;
        public MyVersion(int major, int minor)
        {
            this.major = major;
            this.minor = minor;
        }
        public override string ToString()
        {
            return major + "." + minor;
        }

    }

    [MyVersion(1,0)]
    class Matrix<T> where T : struct
    {
        T[,] elements;

        public Matrix(T[,] inpMatrix)
        {
            elements = new T[inpMatrix.GetLength(0), inpMatrix.GetLength(1)];
            Array.Copy(inpMatrix, this.elements, inpMatrix.Length);
        }

        public Matrix(int rows, int cols)
        {
            if (rows < 0 || cols < 0)
                throw new IndexOutOfRangeException("Invalid matrix size");
            else
                elements = new T[rows, cols];
        }

        public T this[int rowIndex, int colIndex]
        {
            get
            {
                if (rowIndex < 0 || rowIndex > RowCount || colIndex < 0 || colIndex > ColCount)
                    throw new IndexOutOfRangeException("Invalid index");
                else
                    return elements[rowIndex, colIndex];
            }
            set
            {
                if (rowIndex < 0 || rowIndex > RowCount || colIndex < 0 || colIndex > ColCount)
                    throw new IndexOutOfRangeException("Invalid index");
                else
                    elements[rowIndex, colIndex] = value;
            }
        }

        public T[,] GetMatrix
        {
            get { return elements; }
        }

        public int RowCount
        {
            get { return elements.GetLength(0); }
        }

        public int ColCount
        {
            get { return elements.GetLength(1); }
        }


        public static Matrix<T> operator +(Matrix<T> m1, Matrix<T> m2)
        {
            if (m1.RowCount != m2.RowCount || m1.ColCount != m2.ColCount)
            {
                throw new InvalidOperationException("Matrix sizes mismatch");
            }
            Matrix<T> result = new Matrix<T>(m1.GetMatrix);
            for (int i = 0; i < m1.RowCount; i++)
                for (int j = 0; j < m1.ColCount; j++)
                    result[i, j] = (T)((dynamic)m1[i, j] + (dynamic)m2[i, j]);
            return result;
        }

        public static Matrix<T> operator -(Matrix<T> m1, Matrix<T> m2)
        {
            if (m1.RowCount != m2.RowCount || m1.ColCount != m2.ColCount)
            {
                throw new InvalidOperationException("Matrix sizes mismatch");
            }
            Matrix<T> result = new Matrix<T>(m1.GetMatrix);
            for (int i = 0; i < m1.RowCount; i++)
                for (int j = 0; j < m1.ColCount; j++)
                    result[i, j] = (T)((dynamic)m1[i, j] - (dynamic)m2[i, j]);
            return result;
        }

        public static Matrix<T> operator *(Matrix<T> m1, Matrix<T> m2)
        {
            if (m1.ColCount != m2.RowCount)
            {
                throw new InvalidOperationException("Matrix sizes mismatch");
            }
            T[,] res = new T[m1.RowCount, m2.ColCount];
            for (int i = 0; i < m1.RowCount; i++)
                for (int j = 0; j < m2.ColCount; j++)
                    for (int k = 0; k < m1.ColCount; k++)
                    {
                        res[i, j] = (T)((dynamic)res[i, j] + (dynamic)m1[i, k] * (dynamic)m2[k, j]);
                    }
            Matrix<T> result = new Matrix<T>(res);
            return result;
        }

        public override string ToString()
        {
            string s = "";
            for (int i = 0; i < this.RowCount; i++)
            {
                for (int j = 0; j < this.ColCount; j++)
                    s = s + this[i, j].ToString().PadLeft(10);
                s = s + System.Environment.NewLine;
            }
            return s;
        }
    }

    [MyVersion(1, 2)]
    class MatrixTest
    {
        [MyVersion(1, 1)]
        static void Main(string[] args)
        {
            Matrix<int> intMatrix1 = new Matrix<int>(new int[,] 
        {   { 12, 11, 10 }, 
            {  9,  8,  7 }, 
            {  6,  5,  4 }, 
            {  3,  2,  1 } });
            Matrix<int> intMatrix2 = new Matrix<int>(new int[,] 
        {   {  1,  2,  3 }, 
            {  4,  5,  6 }, 
            {  7,  8,  9 }, 
            { 10, 11, 12 } });

            Matrix<double> dblMatrix1 = new Matrix<double>(new double[,] 
        {   { 12.1, 11.2, 10.3 }, 
            {  9.4,  8.5,  7.6 }, 
            {  6.7,  5.8,  4.9 }, 
            {  3.0,  2.1,  1.2 } });
            Matrix<double> dblMatrix2 = new Matrix<double>(new double[,] 
        {   {  1.1,  2.2,  3.3, 4.4 }, 
            {  5.5,  6.6,7.7,  8.8 }, 
            { 9.9, 10.0, 11.1, 12.2 } });
            Console.WriteLine("Integer matrix 1:");
            Console.WriteLine(intMatrix1);
            Console.WriteLine("Integer matrix 2:");
            Console.WriteLine(intMatrix2);
            Console.WriteLine();
            Console.WriteLine("Matrix1 + Matrix2:");
            Console.WriteLine(intMatrix1 + intMatrix2);
            Console.WriteLine();

            Console.WriteLine("Double matrix 1:");
            Console.WriteLine(dblMatrix1);
            Console.WriteLine("Double matrix 2:");
            Console.WriteLine(dblMatrix2);
            Console.WriteLine();
            Console.WriteLine("Double Matrix1 + Double Matrix2:");
            Console.WriteLine(dblMatrix1 * dblMatrix2);
            Console.WriteLine();

            Console.WriteLine("Version of \"Matrix test\" class is {0}",typeof(MatrixTest).GetCustomAttributes(true)[0].ToString());
            Console.WriteLine("Version of \"Matrix \" class is {0}", typeof(Matrix<>).GetCustomAttributes(true)[1].ToString());

        }
    }
}