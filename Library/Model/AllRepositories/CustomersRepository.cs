using Library.Model.Tables;
using Library.Properties;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;

namespace Library.Model.AllRepositories
{
    class CustomersRepository
    {
        private CustomersTable _customersTable;

        public CustomersRepository()
        {
            _customersTable = new CustomersTable(Resources.connectionString);
        }

        public void CreateTable()
        {
            _customersTable.Create();
        }

        public void Insert(string firstname, string lastname, string username, string password, string age)
        {
            _customersTable.Insert(new List<string>() { firstname, lastname, username, password, age });
        }

        public void Update(string id, string firstname, string lastname, string username, string password, string age)
        {
            try
            {
                _customersTable.Update(Int32.Parse(id), new List<string>() { firstname, lastname, username, password, age });
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
                _customersTable.Delete(Int32.Parse(id));
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error Message: {ex.Message}\n\n\nError Stack Trace: {ex.StackTrace}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        public bool CheckUserPassword(string username, string password)
        {
            return _customersTable.CheckCustomerLoginAndPassword(username, password);
        }

    }
}
