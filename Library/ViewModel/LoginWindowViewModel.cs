using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Windows;
using Library.Model;
using Library.Model.Tables;
using Library.Properties;
using Library.View;

namespace Library.ViewModel
{
    class LoginWindowViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private LibraryDbTool _libraryDbTool;

        private bool _isAdmin = false;
        private bool _isCustomer = false;

        public LoginWindowViewModel()
        {
            _libraryDbTool = new LibraryDbTool();

            if (_libraryDbTool.IsFirstLaunch())
            {
                _libraryDbTool.CreateAllTablesOnCheck();
                _libraryDbTool.InsertInitialValues();
                _libraryDbTool.UserRepository.AdminsRepo.Insert("admin", "admin", "admin", "admin");
            }
        }


        public void SetUserAdmin()
        {
            _isAdmin = true;
            _isCustomer = false;
        }

        public void SetUserCustomer()
        {
            _isAdmin = false;
            _isCustomer = true;
        }

        public bool IsUserAdmin() { return _isAdmin; }

        public bool IsUserCustomer() { return _isCustomer; }


        public void LoginCustomer(string username, string password)
        {
            if (_libraryDbTool.UserRepository.CustomersRepo.CheckUserPassword(username, password))
            {
                CustomerPageWindow customerPageWindow = new CustomerPageWindow(username);
                customerPageWindow.ShowDialog();
            }
            else
            {
                MessageBox.Show("Wrong username or password", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        public void LoginAdmin(string username, string password)
        {
            if (_libraryDbTool.UserRepository.AdminsRepo.CheckUserPassword(username, password))
            {
                AdminPageWindow adminPageWindow = new AdminPageWindow();
                adminPageWindow.ShowDialog();
            }
            else
            {
                MessageBox.Show("Wrong username or password", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }


        protected virtual void OnPropertyChanged(string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
