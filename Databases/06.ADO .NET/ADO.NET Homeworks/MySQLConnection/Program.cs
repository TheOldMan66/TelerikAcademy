using MySql.Data.MySqlClient;
using System;
using System.Configuration;
using System.Data;

internal class BooksManager
{
    private static MySqlConnection GetConnection()
    {
        MySqlConnection connection = new MySqlConnection(
            ConfigurationManager.ConnectionStrings["bookshop"].ConnectionString);

        return connection;
    }

    private static DataSet FindBooks(string searchString)
    {
        searchString = searchString
            .Replace("%", "!%")
            .Replace("'", "!'")
            .Replace("\"", "!\"")
            .Replace("_", "!_")
            .ToLower();

        MySqlConnection connection = GetConnection();

        connection.Open();
        using (connection)
        {
            DataSet dataSet = new DataSet();

            MySqlDataAdapter adapter = new MySqlDataAdapter(
                string.Format(
                @"SELECT BookTitle, BookAuthor FROM Books
                  WHERE LOWER(BookTitle) LIKE '%{0}%' ESCAPE '!'", searchString),
                connection);

            adapter.Fill(dataSet);
            return dataSet;
        }
    }

    private static DataSet GetAllBooks()
    {
        MySqlConnection connection = GetConnection();

        connection.Open();
        using (connection)
        {
            DataSet dataSet = new DataSet();

            MySqlDataAdapter adapter = new MySqlDataAdapter(
                "SELECT BookTitle, BookAuthor FROM Books",
                connection);

            adapter.Fill(dataSet);
            return dataSet;
        }
    }

    private static int InsertNewBook(
        string title,
        string author,
        DateTime publicationDate,
        string isbn)
    {
        MySqlConnection connection = GetConnection();

        connection.Open();
        using (connection)
        {
            MySqlCommand insertBookCommand = new MySqlCommand(
                @"INSERT INTO Books (BookTitle, BookAuthor, PublicationDate, ISBN)
                  VALUES (@bookTitle, @bookAuthor, @publicationDate, @isbn)", connection);

            insertBookCommand.Parameters.AddWithValue("@bookTitle", title);
            insertBookCommand.Parameters.AddWithValue("@bookAuthor", author);
            insertBookCommand.Parameters.AddWithValue("@publicationDate", publicationDate);
            insertBookCommand.Parameters.AddWithValue("@isbn", isbn);

            int rowsAffected = insertBookCommand.ExecuteNonQuery();
            return rowsAffected;
        }
    }

    private static void Main()
    {

        int rowsAffected = InsertNewBook(
            "WPF 4_5 Unleashed",
            "Adam Nathan",
            new DateTime(2013, 8, 5),
            "978-0672336973");
        rowsAffected = InsertNewBook(
            "Intro profgramming",
            "Svetlin Nakov",
            new DateTime(2011, 2, 3),
            "000-0000010001");

    }
}