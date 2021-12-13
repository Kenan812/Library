using Library.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;

namespace Library.ViewModel
{
    class AdminPageViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private LibraryDbTool _libraryDbTool;

        public AdminPageViewModel()
        {
            _libraryDbTool = new LibraryDbTool();
        }

        public DataTable GetBooksOnSale()
        {
            return _libraryDbTool.UserRepository.BooksOnSalesRepo.GetBooksInfo();
        }


        protected virtual void OnPropertyChanged(string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
