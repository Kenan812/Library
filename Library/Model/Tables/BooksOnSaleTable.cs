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
    class BooksOnSaleTable : ITable
    {
        private SqlConnection _connection;

        public BooksOnSaleTable(string conStr)
        {
            _connection = new SqlConnection(conStr);
        }

        public void Create()
        {
            try
            {
                _connection.Open();

                string query = @"CREATE TABLE BooksOnSale(
	                                Id INT IDENTITY(1,1) PRIMARY KEY,
	                                BookId INT FOREIGN KEY REFERENCES Books(Id) ON DELETE CASCADE NOT NULL,
	                                Price INT NOT NULL,
	                                DatePutUpForSale DATE DEFAULT(GETDATE()),
	                                PublishingHouseId INT NOT NULL,
	                                PublishingDate DATE,
	                                Discount FLOAT DEFAULT(0)
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
        ///     values[0] = book id
        ///     values[1] = price
        ///     values[2] = date put up for sale(mm/dd/yyyy)
        ///     values[3] = publishing house id
        ///     values[4] = publishing date(mm/dd/yyyy)
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

                string bookId = ls[0];
                string price = ls[1];
                string datePutUpForSale = ls[2];
                string publishingHouseId = ls[3];
                string publishingDate = ls[4];

                string query = $"INSERT INTO BooksOnSale(BookId, Price, DatePutUpForSale, PublishingHouseId, PublishingDate) VALUES('{bookId}', '{price}', '{datePutUpForSale}', '{publishingHouseId}', '{publishingDate}')";

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
        ///     values[0] = book id
        ///     values[1] = price
        ///     values[2] = date put up for sale(mm/dd/yyyy)
        ///     values[3] = publishing house id
        ///     values[4] = publishing date(mm/dd/yyyy)
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

                string bookId = ls[0];
                string price = ls[1];
                string datePutUpForSale = ls[2];
                string publishingHouseId = ls[3];
                string publishingDate = ls[4];

                string query = $"UPDATE BooksOnSale SET BookId = '{bookId}', Price = '{price}', DatePutUpForSale = '{datePutUpForSale}', PublishingHouseId = '{publishingHouseId}', PublishingDate = '{publishingDate}' WHERE Id = '{id}'";

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

                string query = $"DELETE FROM BooksOnSale WHERE Id = '{id}'";

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

        public void SellBook(int bookId)
        {
            try
            {
                _connection.Open();

                string query = $"DELETE TOP (1) FROM BooksOnSale WHERE BookId = '{bookId}'";

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
            Insert(new List<string> { "1", "100", "7/17/2020", "1", "" });
            Insert(new List<string> { "2", "120", "7/17/2020", "2", "7/21/2020" });
            Insert(new List<string> { "3", "220", "7/17/2020", "2", "9/14/1987" });
            Insert(new List<string> { "4", "120", "7/17/2020", "1", "4/2/1603" });
            Insert(new List<string> { "5", "160", "7/17/2020", "1", "7/15/1883" });
            Insert(new List<string> { "6", "95", "7/17/2020", "3", "8/17/1945" });
            Insert(new List<string> { "7", "125", "7/17/2020", "4", "6/12/1939" });
            Insert(new List<string> { "8", "180", "7/17/2020", "5", "9/25/1934" });
            Insert(new List<string> { "9", "75", "7/17/2020", "6", " 1/1/1934" });
            Insert(new List<string> { "10", "90", "7/17/2020", "7", "6/17/1926" });
            Insert(new List<string> { "11", "65", "7/17/2020", "8", "3/15/1949" });

            Insert(new List<string> { "12", "170", "7/17/2020", "9", "6/6/1869" });
            Insert(new List<string> { "13", "170", "7/17/2020", "9", "6/6/1869" });
            Insert(new List<string> { "14", "170", "7/17/2020", "9", "6/6/1869" });
            Insert(new List<string> { "15", "170", "7/17/2020", "9", "6/6/1869" });

            Insert(new List<string> { "16", "90", "7/17/2020", "10", "8/17/1890" });
            Insert(new List<string> { "17", "85", "7/17/2020", "1", "2/23/1887" });
            Insert(new List<string> { "18", "35", "7/17/2020", "1", "5/1/1888" });
            Insert(new List<string> { "19", "50", "7/17/2020", "11", "8/19/1843" });
            Insert(new List<string> { "20", "60", "7/17/2020", "12", "4/4/1843" });
            Insert(new List<string> { "21", "50", "7/17/2020", "13", "5/14/2020" });
            Insert(new List<string> { "22", "65", "7/17/2020", "14", "9/2/2014" });
            Insert(new List<string> { "23", "95", "7/17/2020", "15", "2/16/2017" });
            Insert(new List<string> { "24", "35", "7/17/2020", "16", "12/4/1899" });
            Insert(new List<string> { "25", "80", "7/17/2020", "17", "9/9/1840" });
        }

        public DataTable GetBooksInfo()
        {
            try
            {
                string query = @"SELECT BooksOnSale.Id, Books.BookName, Authors.FirstName + Authors.LastName AS 'Author', Books.NumberOfPages, BooksOnSale.Price, PublishingHouses.PhouseName, Books.IsSequel, BooksOnSale.Discount
                                    FROM BooksOnSale
                                    LEFT JOIN Books ON BooksOnSale.BookId = Books.Id
                                    LEFT JOIN Authors ON Books.AuthorId = Authors.Id
                                    LEFT JOIN PublishingHouses ON PublishingHouses.Id = BooksOnSale.PublishingHouseId";


                return IEnumerableToDataTable.ToDataTable(_connection.Query(query));

            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error Message: {ex.Message}\n\n\nError Stack Trace: {ex.StackTrace}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }

            return null;
        }

        public int GetBookId(int bookOnSaleId)
        {
            try
            {
                _connection.Open();

                string query = $"SELECT BooksOnSale.BookId FROM BooksOnSale WHERE Id = '{bookOnSaleId}'";

                SqlCommand command = new SqlCommand(query, _connection);

                return (int)command.ExecuteScalar();

            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error Message: {ex.Message}\n\n\nError Stack Trace: {ex.StackTrace}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            finally
            {
                _connection.Close();
            }

            return -1;
        }

        public void AddDiscount(int bookOnSaleId, float discount)
        {
            try
            {
                _connection.Open();

                string query = $"UPDATE BooksOnSale SET Discount = '{discount}' WHERE Id = '{bookOnSaleId}'";

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
        /// RETURN: 
        ///     values[0] = book id
        ///     values[1] = price
        ///     values[2] = date put up for sale(mm/dd/yyyy)
        ///     values[3] = publishing house id
        ///     values[4] = publishing date(mm/dd/yyyy)
        /// </summary>
        public List<string> GetBookOnSaleInfo(int bookOnSaleId)
        {
            try
            {
                string query = $"SELECT BooksOnSale.BookId, BooksOnSale.Price, BooksOnSale.DatePutUpForSale, BooksOnSale.PublishingHouseId, BooksOnSale.PublishingDate FROM BooksOnSale WHERE Id = '{bookOnSaleId}'";

                return IEnumerableToStringList.ToStringList(_connection.Query(query));
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error Message: {ex.Message}\n\n\nError Stack Trace: {ex.StackTrace}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }

            return null;
        }


        public DataTable GetBooksOnSaleByAuthor(string firstname, string lastname)
        {
            try
            {
                string query = $@"SELECT Books.BookName, Books.NumberOfPages, Authors.FirstName + ' ' + Authors.LastName AS 'Author', BooksOnSale.Price, 
	                                    BooksOnSale.Discount, PublishingHouses.PhouseName AS 'Publishing House'
                                    FROM BooksOnSale
                                    LEFT JOIN Books ON BooksOnSale.BookId = Books.Id
                                    LEFT JOIN Authors ON Books.AuthorId = Authors.Id
                                    LEFT JOIN PublishingHouses ON PublishingHouses.Id = BooksOnSale.PublishingHouseId
                                    WHERE Authors.FirstName LIKE '{firstname}' AND Authors.LastName LIKE '{lastname}'";


                return IEnumerableToDataTable.ToDataTable(_connection.Query(query));
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error Message: {ex.Message}\n\n\nError Stack Trace: {ex.StackTrace}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }

            return null;
        }



        public DataTable GetBooksOnSaleByBookName(string bookname)
        {
            try
            {
                string query = $@"SELECT Books.BookName, Books.NumberOfPages, Authors.FirstName + ' ' + Authors.LastName AS 'Author', BooksOnSale.Price, 
	                                    BooksOnSale.Discount, PublishingHouses.PhouseName AS 'Publishing House'
                                    FROM BooksOnSale
                                    LEFT JOIN Books ON BooksOnSale.BookId = Books.Id
                                    LEFT JOIN Authors ON Books.AuthorId = Authors.Id
                                    LEFT JOIN PublishingHouses ON PublishingHouses.Id = BooksOnSale.PublishingHouseId
                                    WHERE Books.BookName LIKE '{bookname}'";


                return IEnumerableToDataTable.ToDataTable(_connection.Query(query));
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error Message: {ex.Message}\n\n\nError Stack Trace: {ex.StackTrace}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }

            return null;
        }



        public DataTable GetBooksOnSaleByGenreName(string genrename)
        {
            try
            {
                string query = $@"        SELECT Books.BookName, Books.NumberOfPages, Authors.FirstName + ' ' + Authors.LastName AS 'Author', BooksOnSale.Price,
                                                BooksOnSale.Discount, PublishingHouses.PhouseName AS 'Publishing House'
                                            FROM BooksOnSale
                                            LEFT JOIN Books ON BooksOnSale.BookId = Books.Id
                                            LEFT JOIN Authors ON Books.AuthorId = Authors.Id
                                            LEFT JOIN PublishingHouses ON PublishingHouses.Id = BooksOnSale.PublishingHouseId
                                            LEFT JOIN BooksGenres ON Books.Id = BooksGenres.BookId
                                            LEFT JOIN Genres ON Genres.Id = BooksGenres.GenreId
                                            WHERE Genres.GenreName LIKE '{genrename}'";


                return IEnumerableToDataTable.ToDataTable(_connection.Query(query));
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error Message: {ex.Message}\n\n\nError Stack Trace: {ex.StackTrace}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }

            return null;
        }



        public DataTable GetMostRecentBooks()
        {
            try
            {
                string query = @"SELECT Books.BookName, Books.NumberOfPages, Authors.FirstName + ' ' + Authors.LastName AS 'Author', BooksOnSale.Price,
                                        BooksOnSale.Discount, PublishingHouses.PhouseName AS 'Publishing House'
                                    FROM BooksOnSale
                                    LEFT JOIN Books ON BooksOnSale.BookId = Books.Id
                                    LEFT JOIN Authors ON Books.AuthorId = Authors.Id
                                    LEFT JOIN PublishingHouses ON PublishingHouses.Id = BooksOnSale.PublishingHouseId
                                    LEFT JOIN BooksGenres ON Books.Id = BooksGenres.BookId
                                    LEFT JOIN Genres ON Genres.Id = BooksGenres.GenreId
                                    WHERE DATEDIFF(DAY, BooksOnSale.DatePutUpForSale, GETDATE()) < 15";


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
