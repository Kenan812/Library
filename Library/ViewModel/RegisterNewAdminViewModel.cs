using Library.Model;
using Library.Model.Tables;
using Library.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Library.ViewModel
{
    class RegisterNewAdminViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private LibraryDbTool _libraryDbTool;

        public RegisterNewAdminViewModel()
        {
            _libraryDbTool = new LibraryDbTool();
        }

        
        public void RegisterAdmin(string firstName, string lastName, string username, string password)
        {
            _libraryDbTool.UserRepository.AdminsRepo.Insert(firstName, lastName, username, password);
        }


        protected virtual void OnPropertyChanged(string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
