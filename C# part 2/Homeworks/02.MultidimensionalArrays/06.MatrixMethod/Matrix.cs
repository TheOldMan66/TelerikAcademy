using System;

class Matrix
{
    int[,] elements;

    public Matrix(int[,] inpMatrix)
    {
        elements = new int[inpMatrix.GetLength(0), inpMatrix.GetLength(1)];
        Array.Copy(inpMatrix, this.elements, inpMatrix.Length);
    }

    public int this[int i, int j]
    {
        get { return elements[i, j]; }
        set { elements[i, j] = value; }
    }

    public int[,] GetMatrix
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


    public static Matrix operator +(Matrix m1, Matrix m2)
    {
        if (m1.RowCount != m2.RowCount || m1.ColCount != m2.ColCount)
        {
            throw new InvalidOperationException("Matrix sizes mismatch");
        }
        Matrix result = new Matrix(m1.GetMatrix);
        for (int i = 0; i < m1.RowCount; i++)
            for (int j = 0; j < m1.ColCount; j++)
                result[i, j] = m1[i,j]+ m2[i, j];
        return result;
    }

    public static Matrix operator -(Matrix m1, Matrix m2)
    {
        if (m1.RowCount != m2.RowCount || m1.ColCount != m2.ColCount)
        {
            throw new InvalidOperationException("Matrix sizes mismatch");
        }
        Matrix result = new Matrix(m1.GetMatrix);
        for (int i = 0; i < m1.RowCount; i++)
            for (int j = 0; j < m1.ColCount; j++)
                result[i, j] = m1[i, j] - m2[i, j];
        return result;
    }

    public static Matrix operator *(Matrix m1, Matrix m2)
    {
        if (m1.ColCount != m2.RowCount)
        {
            throw new InvalidOperationException("Matrix sizes mismatch");
        }
        int[,] res = new int[m1.RowCount, m2.ColCount];
        for (int i = 0; i < m1.RowCount; i++)
            for (int j = 0; j < m2.ColCount; j++)
                for (int k = 0; k < m1.ColCount; k++)
                {
                    res[i, j] = res[i, j] + m1[i, k] * m2[k, j];
                }
        Matrix result = new Matrix(res);
        return result;
    }

    public override string ToString()
    {
        string s = "";
        for (int i = 0; i < this.RowCount; i++)
        {
            for (int j = 0; j < this.ColCount; j++)
                s = s + this[i, j].ToString().PadLeft(4);
            s = s + System.Environment.NewLine;
        }
        return s;
    }

}

class TestMatrix
{
    static void Main(string[] args)

    /* Write a class Matrix, to holds a matrix of integers. Overload the operators 
     * for adding, subtracting and multiplying of matrices, indexer for accessing 
     * the matrix content and ToString(). */
    {
        Matrix matrix1 = new Matrix(new int[,] 
        {   { 12, 11, 10 }, 
            {  9,  8,  7 }, 
            {  6,  5,  4 }, 
            {  3,  2,  1 } });
        Matrix matrix2 = new Matrix(new int[,] 
        {   {  1,  2,  3 }, 
            {  4,  5,  6 }, 
            {  7,  8,  9 }, 
            { 10, 11, 12 } });

        Console.WriteLine("Matrix 1:");
        Console.WriteLine(matrix1);
        Console.WriteLine("Matrix 2:");
        Console.WriteLine(matrix2);
        Console.WriteLine();

        Console.WriteLine("Matrix1 + Matrix2:");
        Console.WriteLine(matrix1 + matrix2);
        Console.WriteLine();

        Console.WriteLine("Matrix1 - Matrix2:");
        Console.WriteLine(matrix1 - matrix2);
        Console.WriteLine();

        matrix1 = new Matrix(new int[,] {   { 1, 2 }, 
                                            { 3, 4 }, 
                                            { 5, 6 } 
                                        });

        matrix2 = new Matrix(new int[,] {   { 1, 2, 3, 4 }, 
                                            { 5, 6, 7, 8 } 
                                        });
        Console.WriteLine("Matrix 1:");
        Console.WriteLine(matrix1);
        Console.WriteLine("Matrix 2:");
        Console.WriteLine(matrix2);
        Console.WriteLine();

        Console.WriteLine("Matrix1 * Matrix2:");
        Console.WriteLine(matrix1 * matrix2);
    }
}
