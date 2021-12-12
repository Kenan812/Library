using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using Library.Model.Tables;
using Library.Properties;

namespace Library.Model.AllRepositories
{
    class ReservedBooksRepository
    {
        private ReservedBooksTable _reservedBooksTable;

        public ReservedBooksRepository()
        {
            _reservedBooksTable = new ReservedBooksTable(Resources.connectionString);
        }

        public void CreateTable()
        {
            _reservedBooksTable.Create();
        }

        public void Insert(string reservedBookOnSaleId, string customerId, DateTime reservedDate)
        {
            _reservedBooksTable.Insert(new List<string>() { reservedBookOnSaleId, customerId, $"{reservedDate.Month}/{reservedDate.Day}/{reservedDate.Year}" } );
        }

        public void Update(string id, string reservedBookOnSaleId, string customerId, DateTime reservedDate)
        {
            try
            {
                _reservedBooksTable.Update(Int32.Parse(id), new List<string>() { reservedBookOnSaleId, customerId, $"{reservedDate.Month}/{reservedDate.Day}/{reservedDate.Year}" });
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
                _reservedBooksTable.Delete(Int32.Parse(id));
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error Message: {ex.Message}\n\n\nError Stack Trace: {ex.StackTrace}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

    }
}
