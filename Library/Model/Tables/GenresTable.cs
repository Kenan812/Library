using Library.Model.Interfaces;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;

namespace Library.Model.Tables
{
    class GenresTable : ITable
    {
        private SqlConnection _connection;

        public GenresTable(string conStr)
        {
            _connection = new SqlConnection(conStr);
        }

        public void Create()
        {
            try
            {
                _connection.Open();

                string query = @"CREATE TABLE Genres (
	                                Id INT IDENTITY(1,1) PRIMARY KEY,
	                                GenreName NVARCHAR(100) NOT NULL)";

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

                string query = $"DELETE FROM Genres WHERE Id = '{id}'";

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
        ///     values[0] = genrename
        /// </summary>
        public void Insert(IEnumerable<string> values)
        {
            try
            {
                _connection.Open();

                List<string> ls = values as List<string>;

                if (ls.Count != 1)
                {
                    MessageBox.Show($"Invalid input", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }

                string genreName = ls[0];

                string query = $"INSERT INTO Genres (GenreName) VALUES('{genreName}')";

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
        ///     values[0] = genrename
        /// </summary>
        public void Update(int id, IEnumerable<string> values)
        {
            try
            {
                _connection.Open();

                List<string> ls = values as List<string>;

                if (ls.Count != 1)
                {
                    MessageBox.Show($"Invalid input", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }

                string genreName = ls[0];

                string query = $"UPDATE Genres SET GenreName = '{genreName}' WHERE Id = '{id}'";

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


        public void InsertAllInitialValues()
        {
            Insert(new List<string> { "Literary Fiction" });  // 1
            Insert(new List<string> { "War novel" }); // 2
            Insert(new List<string> { "Anthology"}); // 3
            Insert(new List<string> { "Short Story"}); // 4
            Insert(new List<string> { "Drama"}); // 5
            Insert(new List<string> { "Tragedy"}); // 6
            Insert(new List<string> { "Political satire" }); // 7
            Insert(new List<string> { "Satire" }); // 8
            Insert(new List<string> { "Humor" }); // 9
            Insert(new List<string> { "Fiction" }); // 10
            Insert(new List<string> { "Novel" }); // 11
            Insert(new List<string> { "Detective" }); // 12
            Insert(new List<string> { "Mystery"}); // 13
            Insert(new List<string> { "Philosophical fiction" }); // 14
            Insert(new List<string> { "Gothic fiction" }); // 15
            Insert(new List<string> { "Horror"}); // 16
            Insert(new List<string> { "Historical novel" }); // 17
            Insert(new List<string> { "Romantic narrative poem" }); // 18
        }

    }
}
