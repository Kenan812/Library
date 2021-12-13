using Library.Model.Tables;
using Library.Properties;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;

namespace Library.Model.AllRepositories
{
    class AdminsRepository
    {
        private AdminsTable _adminsTable;

        public AdminsRepository()
        {
            _adminsTable = new AdminsTable(Resources.connectionString);
        }

        public void CreateTable()
        {
            _adminsTable.Create();
        }

        public void Insert(string firstName, string lastName, string username, string password)
        {
            _adminsTable.Insert(new List<string>() { firstName, lastName, username, password });
        }

        public void Update(string id, string firstName, string lastName, string username, string password)
        {
            try
            {
                _adminsTable.Update(Int32.Parse(id), new List<string>() { firstName, lastName, username, password });
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
                _adminsTable.Delete(Int32.Parse(id));
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error Message: {ex.Message}\n\n\nError Stack Trace: {ex.StackTrace}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        public int GetAdminCount()
        {
            return _adminsTable.GetAdminCount();
        }

        public bool CheckUserPassword(string username, string password)
        {
            return _adminsTable.CheckAdminLoginAndPassword(username, password);
        }
    }
}
