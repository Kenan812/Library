using Library.Model;
using Library.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Library.ViewModel
{
    class RegisterNewCustomerViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private LibraryDbTool _libraryDbTool;

        public RegisterNewCustomerViewModel()
        {
            _libraryDbTool = new LibraryDbTool();
        }

        public void RegisterCustomer(string firstName, string lastName, string username, string password, string age)
        {
            _libraryDbTool.UserRepository.CustomersRepo.Insert(firstName, lastName, username, password, age);
        }

        protected virtual void OnPropertyChanged(string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
