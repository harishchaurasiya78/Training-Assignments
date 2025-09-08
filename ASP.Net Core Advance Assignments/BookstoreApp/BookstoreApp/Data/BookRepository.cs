using BookstoreApp.Models;
using System.Data;
using Microsoft.Data.SqlClient;

namespace BookstoreApp.Data
{
    public class BookRepository
    {
        private readonly string connectionString = "Server=(localdb)\\mssqllocaldb;Database=BookstoreDB;Trusted_Connection=True;";

        // READ: Using SqlDataReader (Connected Architecture)
        public List<Book> GetAllBooksWithReader()
        {
            var books = new List<Book>();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string sql = "SELECT * FROM Books";
                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            books.Add(new Book
                            {
                                BookId = reader.GetInt32(0),
                                Title = reader.IsDBNull(1) ? string.Empty : reader.GetString(1),
                                Author = reader.IsDBNull(2) ? string.Empty : reader.GetString(2),
                                Price = reader.GetDecimal(3)
                            });
                        }
                    }
                }
            }
            return books;
        }

        // READ: Using SqlDataAdapter (Disconnected Architecture)
        public DataTable GetAllBooksWithAdapter()
        {
            var dataTable = new DataTable();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string sql = "SELECT * FROM Books";
                using (SqlDataAdapter adapter = new SqlDataAdapter(sql, connection))
                {
                    adapter.Fill(dataTable);
                }
            }
            return dataTable;
        }

        // CREATE: Using Stored Procedure and Parameterized Query
        public void AddBook(Book book)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand("AddBook", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@Title", book.Title);
                    command.Parameters.AddWithValue("@Author", book.Author);
                    command.Parameters.AddWithValue("@Price", book.Price);

                    command.ExecuteNonQuery();
                }
            }
        }

        // UPDATE: Using Stored Procedure and Parameterized Query
        public void UpdateBook(Book book)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand("UpdateBook", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@BookId", book.BookId);
                    command.Parameters.AddWithValue("@Title", book.Title);
                    command.Parameters.AddWithValue("@Author", book.Author);
                    command.Parameters.AddWithValue("@Price", book.Price);

                    command.ExecuteNonQuery();
                }
            }
        }

        // DELETE: Using Stored Procedure and Parameterized Query
        public void DeleteBook(int id)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand("DeleteBook", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@BookId", id);

                    command.ExecuteNonQuery();
                }
            }
        }
    }
}