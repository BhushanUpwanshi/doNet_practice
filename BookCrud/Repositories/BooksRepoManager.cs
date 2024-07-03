using BookCrud.Models;
using MySql.Data.MySqlClient;
using System.Data;
using System.Collections.Generic;

namespace BookCrud.Repositories
{
    public static class BooksRepoManager
    {
  
        private static string connectionString = "Server=localhost;Port=3306;Database=test;User=root;Password=Pass@123;";

        public static bool Delete(int id)
        {
            bool status = false;
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                string query = "DELETE FROM books WHERE Id = @Id";
                MySqlCommand command = new MySqlCommand(query, connection);
                command.Parameters.AddWithValue("@Id", id);

                try
                {
                    connection.Open();
                    int result = command.ExecuteNonQuery();
                    status = result > 0;
                }
                catch (MySqlException e)
                {
                    // Handle exception
                }
                finally
                {
                    if (connection.State != ConnectionState.Closed)
                        connection.Close();
                }
            }
            return status;
        }

        public static Book GetBook(int id)
        {
            Book book = null;
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                string query = "SELECT * FROM books WHERE Id = @Id";
                MySqlCommand command = new MySqlCommand(query, connection);
                command.Parameters.AddWithValue("@Id", id);

                try
                {
                    connection.Open();
                    MySqlDataReader reader = command.ExecuteReader();
                    if (reader.Read())
                    {
                        book = new Book
                        {
                            Id = reader.GetInt32("Id"),
                            Title = reader.GetString("Title"),
                            Author = reader.GetString("Author")
                        };
                    }
                    reader.Close();
                }
                catch (MySqlException e)
                {
                    // Handle exception
                }
                finally
                {
                    if (connection.State != ConnectionState.Closed)
                        connection.Close();
                }
            }
            return book;
        }

        public static List<Book> GetBooks()
        {
            List<Book> books = new List<Book>();
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                string query = "SELECT * FROM books";
                MySqlCommand command = new MySqlCommand(query, connection);

                try
                {
                    connection.Open();
                    MySqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        Book book = new Book
                        {
                            Id = reader.GetInt32("Id"),
                            Title = reader.GetString("Title"),
                            Author = reader.GetString("Author")
                        };
                        books.Add(book);
                    }
                    reader.Close();
                }
                catch (MySqlException e)
                {
                    // Handle exception
                }
                finally
                {
                    if (connection.State != ConnectionState.Closed)
                        connection.Close();
                }
            }
            return books;
        }

        public static bool Insert(Book book)
        {
            bool status = false;
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                string query = "INSERT INTO books (Id,Title, Author) VALUES (@Id,@Title, @Author)";
                MySqlCommand command = new MySqlCommand(query, connection);
                command.Parameters.AddWithValue("@Id", book.Id);
                command.Parameters.AddWithValue("@Title", book.Title);
                command.Parameters.AddWithValue("@Author", book.Author);

                try
                {
                    connection.Open();
                    int result = command.ExecuteNonQuery();
                    status = result > 0;
                }
                catch (MySqlException e)
                {
                    // Handle exception
                }
                finally
                {
                    if (connection.State != ConnectionState.Closed)
                        connection.Close();
                }
            }
            return status;
        }

        public static bool Update(Book book)
        {
            bool status = false;
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                string query = "UPDATE books SET Title = @Title, Author = @Author WHERE Id = @Id";
                MySqlCommand command = new MySqlCommand(query, connection);
                command.Parameters.AddWithValue("@Title", book.Title);
                command.Parameters.AddWithValue("@Author", book.Author);
                command.Parameters.AddWithValue("@Id", book.Id);

                try
                {
                    connection.Open();
                    int result = command.ExecuteNonQuery();
                    status = result > 0;
                }
                catch (MySqlException e)
                {
                    // Handle exception
                }
                finally
                {
                    if (connection.State != ConnectionState.Closed)
                        connection.Close();
                }
            }
            return status;
        }
    }
}
