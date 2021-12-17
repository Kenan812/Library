using Library.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Windows;

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


        #region Get Tables

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

        #endregion



        #region Perform Operations

        public void AddNewBook(Dictionary<string, string> dictionary)
        {
            _libraryDbTool.UserRepository.BooksRepo.Insert(dictionary["BookName"], dictionary["NumberOfPages"], dictionary["AuthorId"], dictionary["CostPrice"], dictionary["IsSequel"]);
        }

        public void AddNewAuthor(Dictionary<string, string> dictionary)
        {
            _libraryDbTool.UserRepository.AuthorsRepo.Insert(dictionary["Author first name"], dictionary["Author last name"]);
        }

        public void AddNewGenre(Dictionary<string, string> dictionary)
        {
            _libraryDbTool.UserRepository.GenreRepo.Insert(dictionary["Genre name"]);
        }

        public void AddNewPublishingHouse(Dictionary<string, string> dictionary)
        {
            _libraryDbTool.UserRepository.PublishingHousesRepo.Insert(dictionary["Publishing house name"]);
        }

        public void AddNewBookOnSale(Dictionary<string, string> dictionary)
        {
            DateTimeConverter converter = new DateTimeConverter();
            DateTime dateputupforsale = (DateTime)converter.ConvertFromString(dictionary["Date put up for sale"]);
            DateTime publishingdate = (DateTime)converter.ConvertFromString(dictionary["Publishing date"]);

            _libraryDbTool.UserRepository.BooksOnSalesRepo.Insert(dictionary["Book Id"], dictionary["Sell price"], dateputupforsale, dictionary["Publishing house Id"], publishingdate);
        }

        public void AddNewGenreToBook(Dictionary<string, string> dictionary)
        {
            _libraryDbTool.UserRepository.BooksGenresRepo.Insert(dictionary["Book Id"], dictionary["Genre Id"]);
        }

        public void SellBook(Dictionary<string, string> dictionary)
        {
            _libraryDbTool.UserRepository.SoldBooksRepo.Insert(dictionary["Book in sale Id"], dictionary["Customer Id"], DateTime.Now);
            _libraryDbTool.UserRepository.BooksOnSalesRepo.SellBook(_libraryDbTool.UserRepository.BooksOnSalesRepo.GetBookId(dictionary["Book in sale Id"]));
        }

        public void AddDiscount(Dictionary<string, string> dictionary)
        {
            _libraryDbTool.UserRepository.BooksOnSalesRepo.AddDiscount(dictionary["Book in sale Id"], dictionary["Discount"]);
        }

        public void UpdateBook(Dictionary<string, string> dictionary)
        {
            try
            {

                List<string> l = _libraryDbTool.UserRepository.BooksRepo.GetBookInfo(dictionary["Book Id"]);

                string bookName = l[0];
                string numberOfPages = l[1];
                string authorId = l[2];
                string costPrice = l[3];
                string isSequel = l[4];


                if (dictionary["Book name"] != String.Empty)
                    bookName = dictionary["Book name"];

                if (dictionary["Number of pages"] != String.Empty)
                    numberOfPages = dictionary["Number of pages"];

                if (dictionary["Author Id"] != String.Empty)
                    authorId = dictionary["Author Id"];

                if (dictionary["Cost Price"] != String.Empty)
                    costPrice = dictionary["Cost Price"];

                if (dictionary["Is sequel"] != String.Empty)
                    isSequel = dictionary["Is sequel"];

                _libraryDbTool.UserRepository.BooksRepo.Update(dictionary["Book Id"], bookName, numberOfPages, authorId, costPrice, isSequel);

            }
            catch (Exception)
            { MessageBox.Show("Invalid id", "Error", MessageBoxButton.OK, MessageBoxImage.Error); }
        }

        public void UpdateAuthor(Dictionary<string, string> dictionary)
        {
            try
            {
                List<string> l = _libraryDbTool.UserRepository.AuthorsRepo.GetAuthorInfo(dictionary["Author Id"]);

                string firstName = l[0];
                string lastName = l[1];

                if (dictionary["Author first name"] != String.Empty)
                    firstName = dictionary["Author first name"];

                if (dictionary["Author last name"] != String.Empty)
                    lastName = dictionary["Author last name"];

                _libraryDbTool.UserRepository.AuthorsRepo.Update(dictionary["Author Id"], firstName, lastName);

            }
            catch (Exception)
            { MessageBox.Show("Invalid id", "Error", MessageBoxButton.OK, MessageBoxImage.Error); }
        }

        public void UpdateGenre(Dictionary<string, string> dictionary)
        {
            try
            {
                List<string> l = _libraryDbTool.UserRepository.GenreRepo.GetGenreInfo(dictionary["Genre Id"]);

                string genreName = l[0];

                if (dictionary["Genre name"] != String.Empty)
                    genreName = dictionary["Genre name"];

                _libraryDbTool.UserRepository.GenreRepo.Update(dictionary["Genre Id"], genreName);

            }
            catch (Exception)
            { MessageBox.Show("Invalid id", "Error", MessageBoxButton.OK, MessageBoxImage.Error); }
        }

        public void UpdatePublishingHouse(Dictionary<string, string> dictionary)
        {
            try
            {
                List<string> l = _libraryDbTool.UserRepository.PublishingHousesRepo.GetPublishingHouseInfo(dictionary["Publishing house Id"]);

                string pubHouseName = l[0];

                if (dictionary["Publishing house name"] != String.Empty)
                    pubHouseName = dictionary["Publishing house name"];

                _libraryDbTool.UserRepository.PublishingHousesRepo.Update(dictionary["Publishing house Id"], pubHouseName);

            }
            catch (Exception) { MessageBox.Show("Invalid id", "Error", MessageBoxButton.OK, MessageBoxImage.Error); }
        }

        public void UpdateBookOnSale(Dictionary<string, string> dictionary)
        {
            try
            {
                List<string> l = _libraryDbTool.UserRepository.BooksOnSalesRepo.GetBookOnSaleInfo(dictionary["Book in sale Id"]);

                DateTimeConverter converter = new DateTimeConverter();

                string bookid = l[0];
                string price = l[1];
                DateTime dateputupforsale = (DateTime)converter.ConvertFromString(l[2]);
                string publishinghouseid = l[3];
                DateTime publishingdate = (DateTime)converter.ConvertFromString(l[4]);


                if (dictionary["Book Id"] != String.Empty)
                    bookid = dictionary["Book Id"];

                if (dictionary["Publishing house Id"] != String.Empty)
                    publishinghouseid = dictionary["Publishing house Id"];


                if (dictionary["Sell price"] != String.Empty)
                    price = dictionary["Sell price"];


                if (dictionary["Date put up for sale"] != String.Empty)
                    dateputupforsale = (DateTime)converter.ConvertFromString(dictionary["Date put up for sale"]);


                if (dictionary["Publishing date"] != String.Empty)
                    publishingdate = (DateTime)converter.ConvertFromString(dictionary["Publishing date"]);


                _libraryDbTool.UserRepository.BooksOnSalesRepo.Update(dictionary["Book in sale Id"], bookid, price, dateputupforsale, publishinghouseid, publishingdate);
            }
            catch (Exception)
            {
                MessageBox.Show("Invalid id", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        public void RemoveDiscout(Dictionary<string, string> dictionary)
        {
            try
            {
                _libraryDbTool.UserRepository.BooksOnSalesRepo.RemoveDiscount(dictionary["Book in sale Id"]);
            }
            catch (Exception) { MessageBox.Show("Invalid id", "Error", MessageBoxButton.OK, MessageBoxImage.Error); }
        }

        public void RemoveBookOnSale(Dictionary<string, string> dictionary)
        {
            try
            {
                _libraryDbTool.UserRepository.BooksOnSalesRepo.Delete(dictionary["Book in sale Id"]);
            }
            catch (Exception) { MessageBox.Show("Invalid id", "Error", MessageBoxButton.OK, MessageBoxImage.Error); }
        }

        public void ReserveBookOnSale(Dictionary<string, string> dictionary)
        {
            try
            {
                _libraryDbTool.UserRepository.ReservedBooksRepo.Insert(dictionary["Book in sale Id"], dictionary["Customer Id"], DateTime.Now);
            }
            catch (Exception) { MessageBox.Show("Invalid id", "Error", MessageBoxButton.OK, MessageBoxImage.Error); }
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


        public void SetAllActionsToFalse()
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
