using Library.Model.Interfaces;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;

namespace Library.Model.Tables
{
    class AdminsTable : ITable
    {
        private SqlConnection _connection;

        public AdminsTable(string conStr)
        {
            _connection = new SqlConnection(conStr);
        }

        public void Create()
        {
            try
            {
                _connection.Open();

                string query = @"CREATE TABLE Admins(
	                                Id INT IDENTITY(1, 1) PRIMARY KEY,
	                                FirstName NVARCHAR(100) NOT NULL,
	                                LastName NVARCHAR(100) NOT NULL,
	                                UserName NVARCHAR (200) NOT NULL,
	                                [Password] NVARCHAR(150) NOT NULL
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
            MessageBox.Show("Unable to delete admin information");
        }


        /// <summary>
        ///     values[0] = firstname
        ///     values[1] = lastname
        ///     values[2] = username
        ///     values[3] = password
        /// </summary>
        public void Insert(IEnumerable<string> values)
        {
            try
            {
                _connection.Open();

                List<string> ls = values as List<string>;

                if (ls.Count != 4)
                {
                    MessageBox.Show($"Invalid input", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }

                string firstName = ls[0];
                string lastName = ls[1];
                string username = ls[2];
                string pswr = ls[3];

                string query = $"INSERT INTO Admins (FirstName, LastName, UserName, Password) VALUES('{firstName}', '{lastName}', '{username}', '{pswr}')";

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
        ///     values[2] = username
        ///     values[3] = password
        /// </summary>
        public void Update(int id, IEnumerable<string> values)
        {
            MessageBox.Show("Unable to update admin information");
        }

        public int GetAdminCount()
        {
            try
            {
                _connection.Open();

                string query = @"SELECT COUNT(*) FROM Admins";

                SqlCommand command = new SqlCommand(query, _connection);

                int count = (int)command.ExecuteScalar();

                return count;
            }
            catch (Exception)
            {
                return 0;
            }
            finally
            {
                _connection.Close();
            }
        }


        public bool CheckAdminLoginAndPassword(string username, string password)
        {
            bool check = false;

            try
            {
                _connection.Open();

                string query = $"SELECT Password FROM Admins WHERE UserName = '{username}'";

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
