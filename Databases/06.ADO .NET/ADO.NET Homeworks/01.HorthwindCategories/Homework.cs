using System;
using System.Data.SqlClient;
using System.Configuration;
using System.IO;
using System.Data.OleDb;

namespace _01.HorthwindCategories
{
    class Homework
    {
        static SqlConnection CreateNorthwindConnection()
        {
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["Northwind"].ConnectionString);
            conn.Open();
            return conn;
        }

        static OleDbConnection CreateExcelConnection()
        {
//            OleDbConnection conn = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=..\\..\\..\\scores.xlsx;Extended Properties= \"Excel 12.0;HDR=Yes;IMEX=2\"");
            OleDbConnection conn = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=..\\..\\..\\scores.xlsx;Extended Properties= \"Excel 12.0;HDR=Yes\"");
            conn.Open();
            return conn;
        }

        static void Pause()
        {
            Console.WriteLine();
            Console.WriteLine("Press 'ENTER' to continue");
            Console.ReadLine();
            Console.Clear();
        }


        static void Main(string[] args)
        {
            SqlCommand command;
            SqlDataReader reader;
            string query;

            Console.WriteLine("TASK 1: Write a program that retrieves from the Northwind sample database in MS SQL Server the number of  rows in the Categories table.");
            Console.WriteLine();
            SqlConnection dbCon = CreateNorthwindConnection();
            using (dbCon)
            {
                command = new SqlCommand("SELECT COUNT(*) FROM Categories", dbCon);
                int numOfCategories = (int)command.ExecuteScalar();
                Console.WriteLine("Number of categories is {0}", numOfCategories);
            }
            Pause();

            Console.WriteLine("TASK 2: Write a program that retrieves the name and description of all categories in the Northwind DB.");
            Console.WriteLine();
            dbCon = CreateNorthwindConnection();
            using (dbCon)
            {
                command = new SqlCommand("SELECT CategoryName, Description FROM Categories", dbCon);
                reader = command.ExecuteReader();
                while (reader.Read())
                {
                    Console.WriteLine("Name: {0}, Description: {1}", (string)reader[0], (string)reader[1]);
                }
            }

            Pause();

            Console.WriteLine("TASK 3: Write a program that retrieves from the Northwind database all product categories and the names of the products in each category. Can you do this with a single SQL query (with table join)?");
            dbCon = CreateNorthwindConnection();
            using (dbCon)
            {
                query = "SELECT cat.CategoryName, prod.ProductName FROM Categories cat INNER JOIN Products prod ON prod.CategoryID = cat.CategoryID ORDER BY cat.CategoryID";
                command = new SqlCommand(query, dbCon);
                reader = command.ExecuteReader();
                string categoryName = "";
                while (reader.Read())
                {
                    if ((string)reader[0] != categoryName)
                    {
                        Console.WriteLine("\n\nCategory: {0}", (string)reader[0]);
                        Console.Write("Products: ");
                        categoryName = (string)reader[0];

                    }

                    Console.Write((string)reader[1] + ", ");
                }
            }

            Console.WriteLine();
            Pause();

            Console.WriteLine("TASK 4: Write a method that adds a new product in the products table in the Northwind database. Use a parameterized SQL command.");
            dbCon = CreateNorthwindConnection();
            using (dbCon)
            {
                query = "INSERT INTO Products(ProductName, SupplierID, CategoryID, QuantityPerUnit, UnitPrice, UnitsInStock, UnitsOnOrder, ReorderLevel, Discontinued)" +
                                " VALUES(@ProductName,@SupplierID,@CategoryID,@QuantityPerUnit,@UnitPrice,@UnitsInStock,@UnitsOnOrder,@ReorderLevel,@Discontinued)";
                command = new SqlCommand(query, dbCon);
                command.Parameters.AddWithValue("@ProductName", "My Product 1");
                command.Parameters.AddWithValue("@SupplierID", 1);
                command.Parameters.AddWithValue("@CategoryID", 1);
                command.Parameters.AddWithValue("@QuantityPerUnit", 10);
                command.Parameters.AddWithValue("@UnitPrice", 1.25);
                command.Parameters.AddWithValue("@UnitsInStock", 1.2);
                command.Parameters.AddWithValue("@UnitsOnOrder", 1.5);
                command.Parameters.AddWithValue("@ReorderLevel", 2.2);
                command.Parameters.AddWithValue("@Discontinued", 1);
                command.ExecuteScalar();
                command = new SqlCommand("SELECT @@Identity", dbCon);
                Console.WriteLine("ElementInserted with index {0}", (int)(decimal)command.ExecuteScalar());
            }

            Pause();


            Console.WriteLine("TASK 5: Write a program that retrieves the images for all categories in the Northwind database and stores them as JPG files in the file system.");
            dbCon = CreateNorthwindConnection();
            using (dbCon)
            {
                command = new SqlCommand("SELECT CategoryName, Picture FROM Categories", dbCon);
                reader = command.ExecuteReader();
                while (reader.Read())
                {
                    string fileName = "..\\..\\..\\" + ((string)reader[0]).Replace('/', '_') + ".jpg";
                    FileStream stream = new FileStream(fileName, FileMode.Create, FileAccess.Write);
                    byte[] buffer = (byte[])reader[1];
                    stream.Write(buffer, 78, buffer.Length - 78);
                    stream.Close();
                }
            }

            Console.WriteLine("\nTake a look at solution directory");
            Pause();

            Console.WriteLine("Task 6: Create an Excel file with 2 columns: name and score. Write a program that reads your MS Excel file through the OLE DB data provider and displays the name and score row by row.");
            OleDbConnection excelCon = CreateExcelConnection();
            using (excelCon)
            {
                query = "SELECT * FROM [Scores$]";
                OleDbCommand excelCommand = new OleDbCommand(query, excelCon);
                OleDbDataReader excelReader = excelCommand.ExecuteReader();
                while (excelReader.Read())
                {
                    Console.WriteLine("{0} -> {1}", (string)excelReader["Name"], (double)excelReader["Score"]);
                }
            }

            Pause();


            Console.WriteLine("Task 7: Implement appending new rows to the Excel file");
            excelCon = CreateExcelConnection();
            using (excelCon)
            {
                query = "INSERT INTO [Scores$](Name, Score) VALUES(@Name, @Score)";
                OleDbCommand excelCommand = new OleDbCommand(query, excelCon);
                excelCommand.Parameters.AddWithValue("@Name", "Doncho");
                excelCommand.Parameters.AddWithValue("@Score", 88);

                excelCommand.ExecuteNonQuery();
            }

            Pause();

            Console.WriteLine("TASK 8: Write a program that reads a string from the console and finds all products that contain this string. Ensure you handle correctly characters like ', %, \", \\ and _.");
            dbCon = CreateNorthwindConnection();

            Console.Write("Please enter your search string: ");
            string input = Console.ReadLine();
            input = input.Replace("%", "[%]");
            input = input.Replace("_", "[_]");
            input = input.Replace("\\", "[\\]");
            input = input.Replace("[", "[[");
            input = input.Replace("]", "]]");
            input = input.Replace("'", "''");
            using (dbCon)
            {

                command = new SqlCommand("SELECT ProductName FROM Products WHERE ProductName LIKE '%" + @input + "%' ", dbCon);
                command.Parameters.AddWithValue("@input", input);

                reader = command.ExecuteReader();

                using (reader)
                {
                    while (reader.Read())
                    {
                        Console.WriteLine("Product: " + (string)reader["ProductName"]);
                    }
                }
            }
            Pause();

        }
    }
}


// Съжалавам но ... просто не знам как може някой да напише самостоятелно цялото домашно. Успях да измисля 7 от задачите само с помощта на чичко гугъл, 
// 8-та леко я заимствах, но за другите просто нямам време.