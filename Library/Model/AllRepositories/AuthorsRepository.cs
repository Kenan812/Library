using Library.Model.Tables;
using Library.Properties;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Windows;

namespace Library.Model.AllRepositories
{
    class AuthorsRepository
    {
        private AuthorsTable _authorsTable;

        public AuthorsRepository()
        {
            _authorsTable = new AuthorsTable(Resources.connectionString);
        }

        public void CreateTable()
        {
            _authorsTable.Create();
        }
        
        public void Insert(string firstName, string lastName)
        {
            _authorsTable.Insert(new List<string>() { firstName, lastName });
        }

        public void Update(string id, string firstName, string lastName)
        {
            try
            {
                _authorsTable.Update(Int32.Parse(id), new List<string>() { firstName, lastName});
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
                _authorsTable.Delete(Int32.Parse(id));
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error Message: {ex.Message}\n\n\nError Stack Trace: {ex.StackTrace}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        public void InsertInitialValues()
        {
            _authorsTable.InsertAllInitialValues();
        }

        public DataTable GetAuthorsInfo()
        {
            return _authorsTable.GetAuthorsInfo();
        }

    }
}
