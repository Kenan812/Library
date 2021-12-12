using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Windows;
using Library.Model;
using Library.Model.Tables;
using Library.Properties;

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



        protected virtual void OnPropertyChanged(string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
