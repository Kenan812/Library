using Library.Model.Interfaces;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;

namespace Library.Model.Tables
{
    class CustomersTable : ITable
    {
        private SqlConnection _connection;

        public CustomersTable(string conStr)
        {
            _connection = new SqlConnection(conStr);
        }

        public void Create()
        {
            try
            {
                _connection.Open();

                string query = @"CREATE TABLE Customers(
	                                Id INT IDENTITY(1, 1) PRIMARY KEY,
	                                FirstName NVARCHAR(100) NOT NULL,
	                                LastName NVARCHAR(100) NOT NULL,
	                                UserName NVARCHAR(200) NOT NULL UNIQUE,
	                                Password NVARCHAR(100) NOT NULL,
	                                Age INT NOT NULL
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
            MessageBox.Show($"Unable to delete customer yet");
        }

        public void Insert(IEnumerable<string> values)
        {
            try
            {
                _connection.Open();

                List<string> ls = values as List<string>;

                if (ls.Count != 5)
                {
                    MessageBox.Show($"Invalid input", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }

                string firstName = ls[0];
                string lastName = ls[1];
                string username = ls[2];
                string pswr = ls[3];
                string age = ls[4].ToString();

                string query = $"INSERT INTO Customers (FirstName, LastName, UserName, Password, Age) VALUES('{firstName}', '{lastName}', '{username}', '{pswr}', {age})";

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

        public void Update(int id, IEnumerable<string> values)
        {
            MessageBox.Show($"Unable to update customers info yet");
        }

        public bool CheckCustomerLoginAndPassword(string username, string password)
        {
            bool check = false;

            try
            {
                _connection.Open();

                string query = $"SELECT Password FROM Customers WHERE UserName = '{username}'";

                SqlCommand command = new SqlCommand(query, _connection);
                string pswrd_check = command.ExecuteScalar().ToString();

                if (pswrd_check == password) check = true;
            }
            catch (Exception)
            {
                return false;
            }
            finally
            {
                _connection.Close();
            }

            return check;
        }
    }
}
