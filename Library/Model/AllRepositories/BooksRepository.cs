using Library.Model.Tables;
using Library.Properties;
using System;
using System.Collections.Generic;
using System.Data;
using System.Windows;

namespace Library.Model.AllRepositories
{
    class BooksRepository
    {
        private BooksTable _booksTable;

        public BooksRepository()
        {
            _booksTable = new BooksTable(Resources.connectionString);
        }

        public void CreateTable()
        {
            _booksTable.Create();
        }

        public void Insert(string bookname, string numberofpages, string authorid, string costprice, string issequel)
        {
            _booksTable.Insert(new List<string>() { bookname, numberofpages, authorid, costprice, issequel });
        }

        public void Update(string id, string bookname, string numberofpages, string authorid, string costprice, string issequel)
        {
            try
            {
                _booksTable.Update(Int32.Parse(id), new List<string>() { bookname, numberofpages, authorid, costprice, issequel });
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
                _booksTable.Delete(Int32.Parse(id));
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error Message: {ex.Message}\n\n\nError Stack Trace: {ex.StackTrace}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    
        public void InsertInitialValues()
        {
            _booksTable.InsertAllInitialValues();
        }

        public DataTable GetBooksInfo()
        {
            return _booksTable.GetBooksInfo();
        }

    }
}
