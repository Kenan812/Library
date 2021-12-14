using Library.Model;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;

namespace Library.ViewModel
{
    class AdminPageViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private LibraryDbTool _libraryDbTool;

        private bool _bookAdding;
        private bool _authorAdding;
        private bool _genreAdding;
        private bool _publishingHOuseAdding;
        private bool _bookOnSaleAdding;
        private bool _genreToBookAdding;
        private bool _bookSelling;
        private bool _discountAdding;
        private bool _bookUpdating;
        private bool _authorUpdating;
        private bool _genreUpdating;
        private bool _publisherHouseUpdating;
        private bool _bookOnSaleUpdating;
        private bool _bookSaleRemove;
        private bool _bookReserving;
        private bool _dicountRemove;

        public bool BookAdding { get => _bookAdding; }
        public bool AuthorAdding { get => _authorAdding; }
        public bool GenreAdding { get => _genreAdding; }
        public bool PublishingHOuseAdding { get => _publishingHOuseAdding; }
        public bool BookOnSaleAdding { get => _bookOnSaleAdding; }
        public bool GenreToBookAdding { get => _genreToBookAdding; }
        public bool BookSelling { get => _bookSelling; }
        public bool DiscountAdding { get => _discountAdding; }
        public bool BookUpdating { get => _bookUpdating; }
        public bool AuthorUpdating { get => _authorUpdating; }
        public bool GenreUpdating { get => _genreUpdating; }
        public bool PublisherHouseUpdating { get => _publisherHouseUpdating; }
        public bool BookOnSaleUpdating { get => _bookOnSaleUpdating; }
        public bool BookSaleRemove { get => _bookSaleRemove; }
        public bool BookReserving { get => _bookReserving; }
        public bool DicountRemove { get => _dicountRemove; }

        public AdminPageViewModel()
        {
            _libraryDbTool = new LibraryDbTool();

            SetAllActionsToFalse();
        }

        public DataTable GetBooksOnSale()
        {
            return _libraryDbTool.UserRepository.BooksOnSalesRepo.GetBooksInfo();
        }

        public DataTable GetAuthors()
        {
            return _libraryDbTool.UserRepository.AuthorsRepo.GetAuthorsInfo();
        }

        public DataTable GetBooks()
        {
            return _libraryDbTool.UserRepository.BooksRepo.GetBooksInfo();
        }

        public DataTable GetGenres()
        {
            return _libraryDbTool.UserRepository.GenreRepo.GetGenresInfo();
        }

        public DataTable GetPublishingHouses()
        {
            return _libraryDbTool.UserRepository.PublishingHousesRepo.GetPublishingHousesInfo();
        }

        public DataTable GetCustomers()
        {
            return _libraryDbTool.UserRepository.CustomersRepo.GetCustomersInfo();
        }

        public DataTable GetSoldBooks()
        {
            return _libraryDbTool.UserRepository.SoldBooksRepo.GetSoldBooksInfo();
        }


        #region Perform Operations

        public void AddNewBook(Dictionary<string, string> dictionary)
        {
            _libraryDbTool.UserRepository.BooksRepo.Insert(dictionary["BookName"], dictionary["NumberOfPages"], dictionary["AuthorId"], dictionary["CostPrice"], dictionary["IsSequel"]);
        }



        #endregion




        #region Managing Operations


        public void PrepareForNewBookAdding()
        {
            SetAllActionsToFalse();
            _bookAdding = true;
        }

        public void PrepareForNewAuthorAdding()
        {
            SetAllActionsToFalse();
            _authorAdding = true;
        }

        public void PrepareForNewGenreAdding()
        {
            SetAllActionsToFalse();
            _genreAdding = true;
        }

        public void PrepareForNewPubHouseAdding()
        {
            SetAllActionsToFalse();
            _publishingHOuseAdding = true;
        }

        public void PrepareForNewBookOnSaleAdding()
        {
            SetAllActionsToFalse();
            _bookOnSaleAdding = true;
        }

        public void PrepareForNewGenreToBookAdding()
        {
            SetAllActionsToFalse();
            _genreToBookAdding = true;
        }

        public void PrepareForBookSelling()
        {
            SetAllActionsToFalse();
            _bookSelling = true;
        }

        public void PrepareForDiscountAdding()
        {
            SetAllActionsToFalse();
            _discountAdding = true;
        }

        public void PrepareForBookUpdating()
        {
            SetAllActionsToFalse();
            _bookUpdating = true;
        }

        public void PrepareForAuthorUpdating()
        {
            SetAllActionsToFalse();
            _authorUpdating = true;
        }

        public void PrepareForGenreUpdating()
        {
            SetAllActionsToFalse();
            _genreUpdating = true;
        }

        public void PrepareForPubHouseUpdating()
        {
            SetAllActionsToFalse();
            _publisherHouseUpdating = true;
        }

        public void PrepareForBookOnSaleUpdating()
        {
            SetAllActionsToFalse();
            _bookOnSaleUpdating = true;
        }

        public void PrepareForSaleRemoval()
        {
            SetAllActionsToFalse();
            _bookSaleRemove = true;
        }

        public void PrepareForBookReserving()
        {
            SetAllActionsToFalse();
            _bookReserving = true;
        }

        public void PrepareForDiscountRemove()
        {
            SetAllActionsToFalse();
            _dicountRemove = true;
        }


        #endregion


        private void SetAllActionsToFalse()
        {
            _bookAdding = false;
            _authorAdding = false;
            _genreAdding = false;
            _publishingHOuseAdding = false;
            _bookOnSaleAdding = false;
            _genreToBookAdding = false;
            _bookSelling = false;
            _discountAdding = false;
            _bookUpdating = false;
            _authorUpdating = false;
            _genreUpdating = false;
            _publisherHouseUpdating = false;
            _bookOnSaleUpdating = false;
            _bookSaleRemove = false;
            _bookReserving = false;
            _dicountRemove = false;
        }

        protected virtual void OnPropertyChanged(string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
