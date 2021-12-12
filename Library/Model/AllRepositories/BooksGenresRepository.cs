using Library.Model.Tables;
using Library.Properties;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;

namespace Library.Model.AllRepositories
{
    class BooksGenresRepository
    {
        private BooksGenresTable _booksGenresTable;

        public BooksGenresRepository()
        {
            _booksGenresTable = new BooksGenresTable(Resources.connectionString);
        }

        public void CreateTable()
        {
            _booksGenresTable.Create();
        }

        public void Insert(string bookId, string genreId)
        {
            _booksGenresTable.Insert(new List<string>() { bookId, genreId });
        }

        public void Update(string id, string bookId, string genreId)
        {
            try
            {
                _booksGenresTable.Update(Int32.Parse(id), new List<string>() { bookId, genreId });
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
                _booksGenresTable.Delete(Int32.Parse(id));
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error Message: {ex.Message}\n\n\nError Stack Trace: {ex.StackTrace}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        public void InsertInitialValues()
        {
            _booksGenresTable.InsertAllInitialValues();
        }

    }
}
