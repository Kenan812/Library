using Dapper;
using Library.Model.Interfaces;
using Library.Properties;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Windows;

namespace Library.Model.Tables
{
    class SoldBooksTable : ITable
    {
        private SqlConnection _connection;

        public SoldBooksTable(string conStr)
        {
            _connection = new SqlConnection(conStr);
        }

        public void Create()
        {
            try
            {
                _connection.Open();

                string query = @"CREATE TABLE SoldBooks(
	                                Id INT IDENTITY(1,1) PRIMARY KEY,
	                                BookId INT NOT NULL FOREIGN KEY REFERENCES Books(Id) ON DELETE CASCADE,
	                                CustomerId INT NOT NULL FOREIGN KEY REFERENCES Customers(Id) ON DELETE CASCADE,
	                                DateOfSale DATE DEFAULT(GETDATE())
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
        ///     values[0] = bookId
        ///     values[1] = customerId
        ///     values[2] = dateOfSale
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

                string bookId = ls[0];
                string customerId = ls[1];
                string dateOfSale = ls[2];

                string query = $"INSERT INTO SoldBooks(BookId, CustomerId, DateOfSale) VALUES('{bookId}', '{customerId}', '{dateOfSale}')";

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
            MessageBox.Show($"Unable to update sold book info", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
        }

        public void Delete(int id)
        {
            MessageBox.Show($"Unable to delete sold book", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
        }

        public DataTable GetSoldBooksInfo()
        {
            try
            {
                string query = @"SELECT Books.Id AS 'BookId', Books.BookName, Authors.FirstName + ' ' +Authors.LastName AS 'Author', Books.NumberOfPages, Customers.Id, Customers.FirstName + ' ' +Customers.LastName AS 'Customer'
                                    FROM SoldBooks
                                    LEFT JOIN Books ON SoldBooks.BookId = Books.Id
                                    LEFT JOIN Authors ON Authors.Id = Books.AuthorId
                                    LEFT JOIN Customers ON Customers.Id = SoldBooks.CustomerId";


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
