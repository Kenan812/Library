using Library.Model.Tables;
using Library.Properties;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows;

namespace Library.Model.AllRepositories
{
    class BooksOnSalesRepository
    {
        private BooksOnSaleTable _booksOnSaleTable;

        public BooksOnSalesRepository()
        {
            _booksOnSaleTable = new BooksOnSaleTable(Resources.connectionString);
        }

        public void CreateTable()
        {
            _booksOnSaleTable.Create();
        }

        public void Insert(string bookid, string price, DateTime datePutUpForSale, string publishingHouseId, DateTime publishingDate)
        {
            _booksOnSaleTable.Insert(new List<string>() { bookid, price, $"{datePutUpForSale.Month}/{datePutUpForSale.Day}/{datePutUpForSale.Year}", publishingHouseId, $"{publishingDate.Month}/{publishingDate.Day}/{publishingDate.Year}" } );
        }

        public void Update(string id, string bookid, string price, DateTime datePutUpForSale, string publishingHouseId, DateTime publishingDate)
        {
            try
            {
                _booksOnSaleTable.Update(Int32.Parse(id), new List<string>() { bookid, price, $"{datePutUpForSale.Month}/{datePutUpForSale.Day}/{datePutUpForSale.Year}", publishingHouseId, $"{publishingDate.Month}/{publishingDate.Day}/{publishingDate.Year}" });
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error Message: {ex.Message}\n\n\nError Stack Trace: {ex.StackTrace}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        public void Delete(string id)
        {
            try
            {
                _booksOnSaleTable.Delete(Int32.Parse(id));
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error Message: {ex.Message}\n\n\nError Stack Trace: {ex.StackTrace}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        public void InsertInitialValues()
        {
            _booksOnSaleTable.InsertAllInitialValues();
        }

        public DataTable GetBooksInfo()
        {
            return _booksOnSaleTable.GetBooksInfo();
        }

        public void SellBook(int bookId)
        {
            try
            {
                _booksOnSaleTable.SellBook(bookId);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error Message: {ex.Message}\n\n\nError Stack Trace: {ex.StackTrace}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        public int GetBookId(string bookOnSaleId)
        {
            try
            {
                return _booksOnSaleTable.GetBookId(Int32.Parse(bookOnSaleId));
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error Message: {ex.Message}\n\n\nError Stack Trace: {ex.StackTrace}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return -1;
            }
        }

        public void AddDiscount(string bookOnSaleId, string discount)
        {
            try
            {
                _booksOnSaleTable.AddDiscount(Int32.Parse(bookOnSaleId), float.Parse(discount));
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error Message: {ex.Message}\n\n\nError Stack Trace: {ex.StackTrace}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

    }
}
