using System;
using System.Collections.Generic;
using System.Text;
using Library.Model.Tables;
using System.Windows;
using Library.Properties;
using System.Data;

namespace Library.Model.AllRepositories
{
    class SoldBooksRepository
    {
        private SoldBooksTable _soldBooksTable;

        public SoldBooksRepository()
        {
            _soldBooksTable = new SoldBooksTable(Resources.connectionString);
        }

        public void CreateTable()
        {
            _soldBooksTable.Create();
        }

        public void Insert(string bookid, string customerid, DateTime dateofsale)
        {
            _soldBooksTable.Insert(new List<string>() { bookid, customerid, $"{dateofsale.Month}/{dateofsale.Day}/{dateofsale.Year}" } );
        }

        public void Update(string id, string bookid, string customerid, DateTime dateofsale)
        {
            try
            {
                _soldBooksTable.Update(Int32.Parse(id), new List<string>() { bookid, customerid, $"{dateofsale.Month}/{dateofsale.Day}/{dateofsale.Year}" });
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
                _soldBooksTable.Delete(Int32.Parse(id));
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error Message: {ex.Message}\n\n\nError Stack Trace: {ex.StackTrace}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        public DataTable GetSoldBooksInfo()
        {
            return _soldBooksTable.GetSoldBooksInfo();
        }
    }
}
