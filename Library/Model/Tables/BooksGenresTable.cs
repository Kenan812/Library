using Library.Model.Interfaces;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;

namespace Library.Model.Tables
{
    class BooksGenresTable : ITable
    {
        private SqlConnection _connection;

        public BooksGenresTable(string conStr)
        {
            _connection = new SqlConnection(conStr);
        }

        public void Create()
        {
            try
            {
                _connection.Open();

                string query = @"CREATE TABLE BooksGenres(
	                                Id INT IDENTITY(1, 1) PRIMARY KEY,
	                                BookId INT FOREIGN KEY REFERENCES Books(Id) ON DELETE CASCADE NOT NULL,
	                                GenreId INT FOREIGN KEY REFERENCES Genres(Id) ON DELETE CASCADE NOT NULL
                                )";

                SqlCommand command = new SqlCommand(query, _connection);

                command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error Message: {ex.Message}\n\n\nError Stack Trace: {ex.StackTrace}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            finally
            {
                _connection.Close();
            }

        }

        public void Delete(int id)
        {
            try
            {
                _connection.Open();

                string query = $"DELETE FROM BooksGenres WHERE Id = '{id}'";

                SqlCommand command = new SqlCommand(query, _connection);

                command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error Message: {ex.Message}\n\n\nError Stack Trace: {ex.StackTrace}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            finally
            {
                _connection.Close();
            }
        }


        /// <summary>
        ///     values[0] = bookId
        ///     values[1] = genreId
        /// </summary>
        public void Insert(IEnumerable<string> values)
        {
            try
            {
                _connection.Open();

                List<string> ls = values as List<string>;

                if (ls.Count != 2)
                {
                    MessageBox.Show($"Invalid input", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }

                string bookid = ls[0];
                string genreId = ls[1];

                string query = $"INSERT INTO BooksGenres(BookId, GenreId) VALUES({bookid}, {genreId})";

                SqlCommand command = new SqlCommand(query, _connection);

                command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error Message: {ex.Message}\n\n\nError Stack Trace: {ex.StackTrace}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            finally
            {
                _connection.Close();
            }
        }


        /// <summary>
        ///     values[0] = bookId
        ///     values[1] = genreId
        /// </summary>
        public void Update(int id, IEnumerable<string> values)
        {
            MessageBox.Show($"Unable to update\nTry delete instead", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
        }


        public void InsertAllInitialValues()
        {
            Insert(new List<string> { "1", "1" });
            Insert(new List<string> { "2", "2" });
            Insert(new List<string> { "3", "3" });
            Insert(new List<string> { "3", "4" });
            Insert(new List<string> { "4", "5" });
            Insert(new List<string> { "4", "6" });
            Insert(new List<string> { "5", "6" });
            Insert(new List<string> { "6", "7" });
            Insert(new List<string> { "7", "8" });
            Insert(new List<string> { "7", "9" });
            Insert(new List<string> { "7", "10" });
            Insert(new List<string> { "8", "11" });
            Insert(new List<string> { "9", "11" });
            Insert(new List<string> { "9", "12" });
            Insert(new List<string> { "9", "13" });
            Insert(new List<string> { "10", "11" });
            Insert(new List<string> { "10", "12" });
            Insert(new List<string> { "11", "11" });
            Insert(new List<string> { "11", "12" });
            Insert(new List<string> { "11", "13" });
            Insert(new List<string> { "12", "11" });
            Insert(new List<string> { "13", "11" });
            Insert(new List<string> { "14", "11" });
            Insert(new List<string> { "15", "11" });
            Insert(new List<string> { "16", "14" });
            Insert(new List<string> { "17", "15" });
            Insert(new List<string> { "18", "10" });
            Insert(new List<string> { "19", "15" });
            Insert(new List<string> { "19", "16" });
            Insert(new List<string> { "20", "15" });
            Insert(new List<string> { "20", "16" });
            Insert(new List<string> { "21", "2" });
            Insert(new List<string> { "21", "10" });
            Insert(new List<string> { "22", "17" });
            Insert(new List<string> { "23", "18" });
            Insert(new List<string> { "24", "10" });
            Insert(new List<string> { "25", "18" });
            Insert(new List<string> { "25", "11" });
            Insert(new List<string> { "25", "14" });
        }
    }
}
