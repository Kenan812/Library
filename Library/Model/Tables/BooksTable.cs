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
    class BooksTable : ITable
    {
        private SqlConnection _connection;

        public BooksTable(string conStr)
        {
            _connection = new SqlConnection(conStr);
        }

        public void Create()
        {
            try
            {
                _connection.Open();

                string query = @"CREATE TABLE Books (
	                                Id INT IDENTITY(1,1) PRIMARY KEY,
	                                BookName NVARCHAR(MAX) NOT NULL,
	                                NumberOfPages INT NOT NULL,
	                                AuthorId INT FOREIGN KEY REFERENCES Authors(id) ON DELETE CASCADE NOT NULL,
	                                CostPrice INT NOT NULL,
	                                IsSequel BIT NOT NULL
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

                string query = $"DELETE FROM Books WHERE Id = '{id}'";

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
        ///     values[0] = bookname
        ///     values[1] = numberofpages
        ///     values[2] = authorid
        ///     values[3] = costprice
        ///     values[4] = issequel
        /// </summary>
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

                string bookName = ls[0];
                string numberOfPages = ls[1];
                string AuthorId = ls[2];
                string CostPrice = ls[3];
                string IsSequel = ls[4];

                string query = $"INSERT INTO Books (BookName, NumberOfPages, AuthorId, CostPrice, IsSequel) VALUES('{bookName}', {numberOfPages}, {AuthorId}, {CostPrice}, {IsSequel})";

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
        ///     values[0] = bookname
        ///     values[1] = numberofpages
        ///     values[2] = authorid
        ///     values[3] = costprice
        ///     values[4] = issequel
        /// </summary>
        public void Update(int id, IEnumerable<string> values)
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

                string bookName = ls[0];
                string numberOfPages = ls[1];
                string authorId = ls[2];
                string costPrice = ls[3];
                string isSequel = ls[4];

                string query = $"UPDATE Books SET BookName = '{bookName}', NumberOfPages = '{numberOfPages}', AuthorId = '{authorId}', CostPrice = '{costPrice}', IsSequel = '{isSequel}' WHERE Id = '{id}'  ";

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
            Insert(new List<string> { "The Old Man and the Sea", "127", "1", "80", "0"}); // 1
            Insert(new List<string> { "For Whom the Bell Tolls", "576", "1", "100", "0"});  // 2
            Insert(new List<string> { "The Complete Short Stories of Ernest Hemingway", "127", "1", "200", "0"});  // 3

            Insert(new List<string> { "Hamlet", "104", "2", "100", "0"}); // 4
            Insert(new List<string> { "Othello", "320", "2", "140", "0"}); // 5

            Insert(new List<string> { "Animal Farm", "112", "3", "75", "0"}); // 6
            Insert(new List<string> { "Coming Up for Air", "237", "3", "105", "0"});  // 7
            Insert(new List<string> { "Burmese Days", "300", "3", "160", "0"});  // 8

            Insert(new List<string> { "Murder on the Orient Express", "256", "4", "55", "0"});  // 9
            Insert(new List<string> { "The Murder of Roger Ackroyd", "312", "4", "70", "0"});  // 10
            Insert(new List<string> { "Crooked House", "211", "4", "45", "0"});  // 11

            Insert(new List<string> { "Peace and War 1", "423", "5", "150", "0" });  // 12
            Insert(new List<string> { "Peace and War 2", "411", "5", "150", "1" });  // 13
            Insert(new List<string> { "Peace and War 3", "406", "5", "150", "1" });  // 14
            Insert(new List<string> { "Peace and War 4", "414", "5", "150", "1" });  // 15

            Insert(new List<string> { "The Picture of Dorian Gray", "230", "6", "70", "0" });  // 16
            Insert(new List<string> { "The Canterville Ghost", "126", "6", "65", "0" });
            Insert(new List<string> { "The Selfish Giant", "10", "6", "15", "0" }); // 18

            Insert(new List<string> { "The Black Cat", "26", "7", "30", "0" }); // 19
            Insert(new List<string> { "The Fall of the House of Usher", "25", "7", "40", "0" }); // 20

            Insert(new List<string> { "7 Best Short Stories by Alexander Pushkin", "158", "8", "30", "0" }); // 21
            Insert(new List<string> { "The Captains Daughter", "192", "8", "45", "0" }); // 22
            Insert(new List<string> { "Ruslan and Ludmila", "240", "8", "75", "0" }); // 23

            Insert(new List<string> { "The Lady with the Dog", "15", "9", "15", "0" }); // 24

            Insert(new List<string> { "A Hero of Our Time", "124", "10", "60", "0" }); // 25
        }

        public DataTable GetBooksInfo()
        {
            try
            {
                string query = @"SELECT Books.Id, Books.BookName, Authors.FirstName + ' ' +Authors.LastName AS 'Author', Books.NumberOfPages, Books.IsSequel FROM Books
                                    LEFT JOIN Authors ON Authors.Id = Books.AuthorId";


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
