using Dapper;
using Library.Model.Interfaces;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Windows;

namespace Library.Model.Tables
{
    class PublishingHousesTable : ITable
    {
        private SqlConnection _connection;

        public PublishingHousesTable(string conStr)
        {
            _connection = new SqlConnection(conStr);
        }

        public void Create()
        {
            try
            {
                _connection.Open();

                string query = @"CREATE TABLE PublishingHouses(
	                                Id INT IDENTITY (1,1) PRIMARY KEY,
	                                PhouseName NVARCHAR(200) NOT NULL
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

        /// <summary>
        ///     values[0] = publishing house name
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

                string publishingHouseName = ls[0];

                string query = $"INSERT INTO PublishingHouses(PhouseName) VALUES('{publishingHouseName}')";

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
        ///     values[0] = publishing house name
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

                string publishingHouseName = ls[0];

                string query = $"UPDATE PublishingHouses SET PhouseName = '{publishingHouseName}' WHERE Id = '{id}'";

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

                string query = $"DELETE FROM PublishingHouses WHERE Id = '{id}'";

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
            Insert(new List<string> { "Simon & Schuster" });  // 1
            Insert(new List<string> { "Scribner" });  // 2
            Insert(new List<string> { "Secker and Warburg" });  // 3
            Insert(new List<string> { "Victor Gollancz" });  // 4
            Insert(new List<string> { "Harper & Brothers (US)" });  // 5
            Insert(new List<string> { "Collins Crime Club" });  // 6
            Insert(new List<string> { "William Collins, Sons" });  // 7
            Insert(new List<string> { "Dodd, Mead and Company" });  // 8
            Insert(new List<string> { "The Russian Messenger" });  // 9
            Insert(new List<string> { "Lippincotts Monthly Magazine" });  // 10
            Insert(new List<string> { "United States Saturday Post" });  // 11
            Insert(new List<string> { "The Pit and the Pendulum" });  // 12
            Insert(new List<string> { "Tacet Books" });  // 13
            Insert(new List<string> { "NYRB Classics" });  // 14
            Insert(new List<string> { "Alma Classics" });  // 15
            Insert(new List<string> { "Russkaya Mysl" });  // 16
            Insert(new List<string> { "Iliya Glazunov & Co" });  // 17
        }


        public DataTable GetPublishingHousesInfo()
        {
            try
            {
                string query = @"SELECT * FROM PublishingHouses";

                IEnumerable<dynamic> r = _connection.Query(query);

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
