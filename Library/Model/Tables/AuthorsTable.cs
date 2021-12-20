using Dapper;
using Library.Model.Interfaces;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows;

namespace Library.Model.Tables
{
    class AuthorsTable : ITable
    {
        private SqlConnection _connection;

        public AuthorsTable(string conStr)
        {
            _connection = new SqlConnection(conStr);
        }
        
        public void Create()
        {
            try
            {
                _connection.Open();

                string query = @"CREATE TABLE Authors(
	                                Id INT IDENTITY(1,1) PRIMARY KEY,
	                                FirstName NVARCHAR(100) NOT NULL,
	                                LastName NVARCHAR(100) NOT NULL
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

                string query = $"DELETE FROM Authors WHERE Id = {id}";

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
        ///     values[0] = firstname
        ///     values[1] = lastname
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

                string firstName = ls[0];
                string lastName = ls[1];

                string query = $"INSERT INTO Authors(FirstName, LastName) VALUES('{firstName}', '{lastName}')";

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
        ///     values[0] = firstname
        ///     values[1] = lastname
        /// </summary>
        public void Update(int id, IEnumerable<string> values)
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

                string firstName = ls[0];
                string lastName = ls[1];

                string query = $"UPDATE Authors SET FirstName = '{firstName}', LastName = '{lastName}' WHERE Id = {id}";

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
            Insert(new List<string> { "Ernest", "Hemingway" });
            Insert(new List<string> { "William", "Shakespeare" });
            Insert(new List<string> { "George", "Orwell" });
            Insert(new List<string> { "Agatha", "Christie" });
            Insert(new List<string> { "Leo", "Tolstoy" });
            Insert(new List<string> { "Oscar", "Wilde" });
            Insert(new List<string> { "Edgar Poe", "Allan" });
            Insert(new List<string> { "Alexander", "Pushkin" });
            Insert(new List<string> { "Anton", "Chekhov" });
            Insert(new List<string> { "Mikhail", "Lermontov" });
        }


        public DataTable GetAuthorsInfo()
        {
            try
            {
                string query = @"SELECT * FROM Authors";


                IEnumerable<dynamic> r = _connection.Query(query);

                return IEnumerableToDataTable.ToDataTable(_connection.Query(query));
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error Message: {ex.Message}\n\n\nError Stack Trace: {ex.StackTrace}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }

            return null;
        }


        /// <summary>
        /// RETURN: 
        ///     values[0] = firstname
        ///     values[1] = lastname
        /// </summary>
        public List<string> GetAuthorInfo(int authorId)
        {
            try
            {
                string query = $"SELECT Authors.FirstName, Authors.LastName FROM Authors WHERE Authors.Id = '{authorId}'";

                return IEnumerableToStringList.ToStringList(_connection.Query(query));
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error Message: {ex.Message}\n\n\nError Stack Trace: {ex.StackTrace}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }

            return null;
        }

        public DataTable GetMostPopularAuthors()
        {
            try
            {
                string query = @"SELECT TOP(3) Authors.FirstName, Authors.LastName FROM Authors
	                                LEFT JOIN Books ON Books.AuthorId = Authors.Id
	                                LEFT JOIN SoldBooks ON SoldBooks.BookId = Books.Id
	                                GROUP BY Authors.FirstName, Authors.LastName
	                                ORDER BY COUNT(SoldBooks.Id) DESC";


                return IEnumerableToDataTable.ToDataTable(_connection.Query(query));
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error Message: {ex.Message}\n\n\nError Stack Trace: {ex.StackTrace}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }

            return null;
        }



    }
}
