using Library.Model.Interfaces;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Windows;

namespace Library.Model.Tables
{
    class ReservedBooksTable : ITable
    {

        private SqlConnection _connection;

        public ReservedBooksTable(string conStr)
        {
            _connection = new SqlConnection(conStr);
        }

        public void Create()
        {
            try
            {
                _connection.Open();

                string query = @"CREATE TABLE ReservedBooks(
	                                Id INT IDENTITY(1,1) PRIMARY KEY,
	                                ReservedBookOnSaleId INT FOREIGN KEY REFERENCES BooksOnSale(Id) ON DELETE CASCADE NOT NULL,
	                                CustomerId INT FOREIGN KEY REFERENCES Customers(Id) ON DELETE CASCADE NOT NULL,
	                                ReservedDate DATE DEFAULT(GETDATE()) NOT NULL
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
        ///     values[0] = Reserved Book On Sale Id
        ///     values[1] = CustomerId
        ///     values[2] = ReservedDate
        /// </summary>
        public void Insert(IEnumerable<string> values)
        {
            try
            {
                _connection.Open();

                List<string> ls = values as List<string>;

                if (ls.Count != 3)
                {
                    MessageBox.Show($"Invalid input", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }

                string reservedBookOnSaleId = ls[0];
                string customerId = ls[1];
                string reservedDate = ls[2];

                string query = $"INSERT INTO ReservedBooks(ReservedBookOnSaleId, CustomerId, ReservedDate) VALUES('{reservedBookOnSaleId}', '{customerId}', '{reservedDate}')";

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
            MessageBox.Show($"Unable to update resered book info", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
        }

        public void Delete(int id)
        {
            try
            {
                _connection.Open();

                string query = $"DELETE FROM ReservedBooks WHERE Id = '{id}'";

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
    }
}
