using Library.ViewModel;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Media;

namespace Library.View
{
    /// <summary>
    /// Interaction logic for AdminPageWindow.xaml
    /// </summary>
    public partial class AdminPageWindow : Window
    {
        private AdminPageViewModel _adminPageViewModel;

        public AdminPageWindow()
        {
            InitializeComponent();

            _adminPageViewModel = new AdminPageViewModel();
            tableDataGrid.ItemsSource = _adminPageViewModel.GetBooksOnSale().DefaultView;
            SetDefaultPageSettings();
        }

        private void showBooksButton_Click(object sender, RoutedEventArgs e)
        {
            tableDataGrid.ItemsSource = _adminPageViewModel.GetBooksOnSale().DefaultView;
        }

        private void showAuthorsButton_Click(object sender, RoutedEventArgs e)
        {
            tableDataGrid.ItemsSource = _adminPageViewModel.GetAuthors().DefaultView;
        }

        private void showbooksButton_Click_1(object sender, RoutedEventArgs e)
        {
            tableDataGrid.ItemsSource = _adminPageViewModel.GetBooks().DefaultView;
        }

        private void showGenresButton_Click(object sender, RoutedEventArgs e)
        {
            tableDataGrid.ItemsSource = _adminPageViewModel.GetGenres().DefaultView;
        }

        private void showPublishingHousesButton_Click(object sender, RoutedEventArgs e)
        {
            tableDataGrid.ItemsSource = _adminPageViewModel.GetPublishingHouses().DefaultView;
        }

        private void showCustomersButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                tableDataGrid.ItemsSource = _adminPageViewModel.GetCustomers().DefaultView;
            }
            catch (Exception)
            {
                MessageBox.Show("Table is empty");
            }
        }

        private void showSoldBooksButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                tableDataGrid.ItemsSource = _adminPageViewModel.GetSoldBooks().DefaultView;

            }
            catch (Exception)
            {
                MessageBox.Show("Table is empty");
            }
        }




        private void SetDefaultPageSettings()
        {
            bookIdTextBox.Text = "Book Id";
            bookIdTextBox.IsEnabled = false;
            bookIdTextBox.Foreground = Brushes.DarkMagenta;

            bookNameTextBox.Text = "Book name";
            bookNameTextBox.IsEnabled = false;
            bookNameTextBox.Foreground = Brushes.DarkMagenta;


            numberOfPagesTextBox.Text = "# of pages";
            numberOfPagesTextBox.IsEnabled = false;
            numberOfPagesTextBox.Foreground = Brushes.DarkMagenta;


            authorIdTextBox.Text = "Author Id";
            authorIdTextBox.IsEnabled = false;
            authorIdTextBox.Foreground = Brushes.DarkMagenta;


            costPriceTextBox.Text = "Cost Price";
            costPriceTextBox.IsEnabled = false;
            costPriceTextBox.Foreground = Brushes.DarkMagenta;


            isSequelTextBox.Text = "Is sequel(0/1)";
            isSequelTextBox.IsEnabled = false;
            isSequelTextBox.Foreground = Brushes.DarkMagenta;


            authorFirstNameTextBox.Text = "Author first name";
            authorFirstNameTextBox.IsEnabled = false;
            authorFirstNameTextBox.Foreground = Brushes.DarkMagenta;


            authorlastNameTextBox.Text = "Author last name";
            authorlastNameTextBox.IsEnabled = false;
            authorlastNameTextBox.Foreground = Brushes.DarkMagenta;


            genreIdTextBox.Text = "Genre Id";
            genreIdTextBox.IsEnabled = false;
            genreIdTextBox.Foreground = Brushes.DarkMagenta;


            genreNameTextBox.Text = "Genre name";
            genreNameTextBox.IsEnabled = false;
            genreNameTextBox.Foreground = Brushes.DarkMagenta;


            publishingHouseIdTextBox.Text = "Publishing house Id";
            publishingHouseIdTextBox.IsEnabled = false;
            publishingHouseIdTextBox.Foreground = Brushes.DarkMagenta;


            publishingHouseNameTextBox.Text = "Publishing house name";
            publishingHouseNameTextBox.IsEnabled = false;
            publishingHouseNameTextBox.Foreground = Brushes.DarkMagenta;


            bookonSaleIdTextBox.Text = "Book in sale Id";
            bookonSaleIdTextBox.IsEnabled = false;
            bookonSaleIdTextBox.Foreground = Brushes.DarkMagenta;


            sellPriceTextBox.Text = "Sell price";
            sellPriceTextBox.IsEnabled = false;
            sellPriceTextBox.Foreground = Brushes.DarkMagenta;


            dicountTextBox.Text = "Discount(in %)";
            dicountTextBox.IsEnabled = false;
            dicountTextBox.Foreground = Brushes.DarkMagenta;


            customerIdTextBox.Text = "Customer Id";
            customerIdTextBox.IsEnabled = false;
            customerIdTextBox.Foreground = Brushes.DarkMagenta;


            datePutUpForSaleTextBox.Text = "Date put up for sale(mm/dd/yyyy)";
            datePutUpForSaleTextBox.IsEnabled = false;
            datePutUpForSaleTextBox.Foreground = Brushes.DarkMagenta;


            publishingDateTextBox.Text = "Publishing date(mm/dd/yyyy)";
            publishingDateTextBox.IsEnabled = false;
            publishingDateTextBox.Foreground = Brushes.DarkMagenta;

        }


        #region TextBoxes


        #region bookIdTextBox

        private void bookIdTextBox_GotFocus(object sender, RoutedEventArgs e)
        {
            if (bookIdTextBox.Text == "Book Id")
            {
                bookIdTextBox.Text = String.Empty;
                bookIdTextBox.Foreground = Brushes.Black;
            }
        }

        private void bookIdTextBox_LostFocus(object sender, RoutedEventArgs e)
        {
            if (bookIdTextBox.Text == String.Empty)
            {
                bookIdTextBox.Text = "Book Id";
                bookIdTextBox.Foreground = Brushes.DarkMagenta;
            }
        }

        #endregion


        #region bookNameTextBox

        private void bookNameTextBox_GotFocus(object sender, RoutedEventArgs e)
        {
            if (bookNameTextBox.Text == "Book name")
            {
                bookNameTextBox.Text = String.Empty;
                bookNameTextBox.Foreground = Brushes.Black;
            }
        }

        private void bookNameTextBox_LostFocus(object sender, RoutedEventArgs e)
        {
            if (bookNameTextBox.Text == String.Empty)
            {
                bookNameTextBox.Text = "Book name";
                bookNameTextBox.Foreground = Brushes.DarkMagenta;
            }
        }

        #endregion


        #region numberOfPagesTextBox

        private void numberOfPagesTextBox_GotFocus(object sender, RoutedEventArgs e)
        {
            if (numberOfPagesTextBox.Text == "# of pages")
            {
                numberOfPagesTextBox.Text = String.Empty;
                numberOfPagesTextBox.Foreground = Brushes.Black;
            }
        }

        private void numberOfPagesTextBox_LostFocus(object sender, RoutedEventArgs e)
        {
            if (numberOfPagesTextBox.Text == String.Empty)
            {
                numberOfPagesTextBox.Text = "# of pages";
                numberOfPagesTextBox.Foreground = Brushes.DarkMagenta;
            }
        }

        #endregion


        #region authorIdTextBox

        private void authorIdTextBox_GotFocus(object sender, RoutedEventArgs e)
        {
            if (authorIdTextBox.Text == "Author Id")
            {
                authorIdTextBox.Text = String.Empty;
                authorIdTextBox.Foreground = Brushes.Black;
            }
        }

        private void authorIdTextBox_LostFocus(object sender, RoutedEventArgs e)
        {
            if (authorIdTextBox.Text == String.Empty)
            {
                authorIdTextBox.Text = "Author Id";
                authorIdTextBox.Foreground = Brushes.DarkMagenta;
            }
        }


        #endregion


        #region costPriceTextBox

        private void costPriceTextBox_GotFocus(object sender, RoutedEventArgs e)
        {
            if (costPriceTextBox.Text == "Cost Price")
            {
                costPriceTextBox.Text = String.Empty;
                costPriceTextBox.Foreground = Brushes.Black;
            }
        }

        private void costPriceTextBox_LostFocus(object sender, RoutedEventArgs e)
        {
            if (costPriceTextBox.Text == String.Empty)
            {
                costPriceTextBox.Text = "Cost Price";
                costPriceTextBox.Foreground = Brushes.DarkMagenta;
            }
        }

        #endregion


        #region isSequelTextBox

        private void isSequelTextBox_GotFocus(object sender, RoutedEventArgs e)
        {
            if (isSequelTextBox.Text == "Is sequel(0/1)")
            {
                isSequelTextBox.Text = String.Empty;
                isSequelTextBox.Foreground = Brushes.Black;
            }
        }

        private void isSequelTextBox_LostFocus(object sender, RoutedEventArgs e)
        {
            if (isSequelTextBox.Text == String.Empty)
            {
                isSequelTextBox.Text = "Is sequel(0/1)";
                isSequelTextBox.Foreground = Brushes.DarkMagenta;
            }
        }


        #endregion


        #region authorFirstNameTextBox

        private void authorFirstNameTextBox_GotFocus(object sender, RoutedEventArgs e)
        {
            if (authorFirstNameTextBox.Text == "Author first name")
            {
                authorFirstNameTextBox.Text = String.Empty;
                authorFirstNameTextBox.Foreground = Brushes.Black;
            }
        }

        private void authorFirstNameTextBox_LostFocus(object sender, RoutedEventArgs e)
        {
            if (authorFirstNameTextBox.Text == String.Empty)
            {
                authorFirstNameTextBox.Text = "Author first name";
                authorFirstNameTextBox.Foreground = Brushes.DarkMagenta;
            }
        }


        #endregion


        #region authorlastNameTextBox

        private void authotlastNameTextBox_GotFocus(object sender, RoutedEventArgs e)
        {
            if (authorlastNameTextBox.Text == "Author last name")
            {
                authorlastNameTextBox.Text = String.Empty;
                authorlastNameTextBox.Foreground = Brushes.Black;
            }
        }

        private void authotlastNameTextBox_LostFocus(object sender, RoutedEventArgs e)
        {
            if (authorlastNameTextBox.Text == String.Empty)
            {
                authorlastNameTextBox.Text = "Author last name";
                authorlastNameTextBox.Foreground = Brushes.DarkMagenta;
            }
        }


        #endregion


        #region genreIdTextBox

        private void genreIdTextBox_GotFocus(object sender, RoutedEventArgs e)
        {
            if (genreIdTextBox.Text == "Genre Id")
            {
                genreIdTextBox.Text = String.Empty;
                genreIdTextBox.Foreground = Brushes.Black;
            }
        }

        private void genreIdTextBox_LostFocus(object sender, RoutedEventArgs e)
        {
            if (genreIdTextBox.Text == String.Empty)
            {
                genreIdTextBox.Text = "Genre Id";
                genreIdTextBox.Foreground = Brushes.DarkMagenta;
            }
        }


        #endregion


        #region genreNameTextBox

        private void genreNameTextBox_GotFocus(object sender, RoutedEventArgs e)
        {
            if (genreNameTextBox.Text == "Genre name")
            {
                genreNameTextBox.Text = String.Empty;
                genreNameTextBox.Foreground = Brushes.Black;
            }
        }

        private void genreNameTextBox_LostFocus(object sender, RoutedEventArgs e)
        {
            if (genreNameTextBox.Text == String.Empty)
            {
                genreNameTextBox.Text = "Genre name";
                genreNameTextBox.Foreground = Brushes.DarkMagenta;
            }
        }


        #endregion


        #region publishingHouseIdTextBox

        private void publishingHouseIdTextBox_GotFocus(object sender, RoutedEventArgs e)
        {
            if (publishingHouseIdTextBox.Text == "Publishing house Id")
            {
                publishingHouseIdTextBox.Text = String.Empty;
                publishingHouseIdTextBox.Foreground = Brushes.Black;
            }
        }

        private void publishingHouseIdTextBox_LostFocus(object sender, RoutedEventArgs e)
        {
            if (publishingHouseIdTextBox.Text == String.Empty)
            {
                publishingHouseIdTextBox.Text = "Publishing house Id";
                publishingHouseIdTextBox.Foreground = Brushes.DarkMagenta;
            }
        }


        #endregion


        #region publishingHouseNameTextBox

        private void publishingHouseNameTextBox_GotFocus(object sender, RoutedEventArgs e)
        {
            if (publishingHouseNameTextBox.Text == "Publishing house name")
            {
                publishingHouseNameTextBox.Text = String.Empty;
                publishingHouseNameTextBox.Foreground = Brushes.Black;
            }
        }

        private void publishingHouseNameTextBox_LostFocus(object sender, RoutedEventArgs e)
        {
            if (publishingHouseNameTextBox.Text == String.Empty)
            {
                publishingHouseNameTextBox.Text = "Publishing house name";
                publishingHouseNameTextBox.Foreground = Brushes.DarkMagenta;
            }
        }
        #endregion


        #region bookonSaleIdTextBox

        private void bookonSaleIdTextBox_GotFocus(object sender, RoutedEventArgs e)
        {
            if (bookonSaleIdTextBox.Text == "Book in sale Id")
            {
                bookonSaleIdTextBox.Text = String.Empty;
                bookonSaleIdTextBox.Foreground = Brushes.Black;
            }
        }

        private void bookonSaleIdTextBox_LostFocus(object sender, RoutedEventArgs e)
        {
            if (bookonSaleIdTextBox.Text == String.Empty)
            {
                bookonSaleIdTextBox.Text = "Book in sale Id";
                bookonSaleIdTextBox.Foreground = Brushes.DarkMagenta;
            }
        }

        #endregion


        #region sellPriceTextBox

        private void sellPriceTextBox_GotFocus(object sender, RoutedEventArgs e)
        {
            if (sellPriceTextBox.Text == "Sell price")
            {
                sellPriceTextBox.Text = String.Empty;
                sellPriceTextBox.Foreground = Brushes.Black;
            }
        }

        private void sellPriceTextBox_LostFocus(object sender, RoutedEventArgs e)
        {
            if (sellPriceTextBox.Text == String.Empty)
            {
                sellPriceTextBox.Text = "Sell price";
                sellPriceTextBox.Foreground = Brushes.DarkMagenta;
            }
        }

        #endregion


        #region dicountTextBox

        private void dicountTextBox_GotFocus(object sender, RoutedEventArgs e)
        {
            if (dicountTextBox.Text == "Discount(in %)")
            {
                dicountTextBox.Text = String.Empty;
                dicountTextBox.Foreground = Brushes.Black;
            }
        }

        private void dicountTextBox_LostFocus(object sender, RoutedEventArgs e)
        {
            if (dicountTextBox.Text == String.Empty)
            {
                dicountTextBox.Text = "Discount(in %)";
                dicountTextBox.Foreground = Brushes.DarkMagenta;
            }
        }

        #endregion


        #region customerIdTextBox

        private void customerIdTextBox_GotFocus(object sender, RoutedEventArgs e)
        {
            if (customerIdTextBox.Text == "Customer Id")
            {
                customerIdTextBox.Text = String.Empty;
                customerIdTextBox.Foreground = Brushes.Black;
            }
        }

        private void customerIdTextBox_LostFocus(object sender, RoutedEventArgs e)
        {
            if (customerIdTextBox.Text == String.Empty)
            {
                customerIdTextBox.Text = "Customer Id";
                customerIdTextBox.Foreground = Brushes.DarkMagenta;
            }
        }

        #endregion


        #region datePutUpForSaleTextBox

        private void datePutUpForSaleTextBox_GotFocus(object sender, RoutedEventArgs e)
        {
            if (datePutUpForSaleTextBox.Text == "Date put up for sale(mm/dd/yyyy)")
            {
                datePutUpForSaleTextBox.Text = String.Empty;
                datePutUpForSaleTextBox.Foreground = Brushes.Black;
            }
        }

        private void datePutUpForSaleTextBox_LostFocus(object sender, RoutedEventArgs e)
        {
            if (datePutUpForSaleTextBox.Text == String.Empty)
            {
                datePutUpForSaleTextBox.Text = "Date put up for sale(mm/dd/yyyy)";
                datePutUpForSaleTextBox.Foreground = Brushes.DarkMagenta;
            }
        }


        #endregion


        #region publishingDateTextBox

        private void publishingDateTextBox_GotFocus(object sender, RoutedEventArgs e)
        {
            if (publishingDateTextBox.Text == "Publishing date(mm/dd/yyyy)")
            {
                publishingDateTextBox.Text = String.Empty;
                publishingDateTextBox.Foreground = Brushes.Black;
            }
        }

        private void publishingDateTextBox_LostFocus(object sender, RoutedEventArgs e)
        {
            if (publishingDateTextBox.Text == String.Empty)
            {
                publishingDateTextBox.Text = "Publishing date(mm/dd/yyyy)";
                publishingDateTextBox.Foreground = Brushes.DarkMagenta;
            }
        }




        #endregion

        #endregion



        #region Buttons

        private void addNewBookButton_Click(object sender, RoutedEventArgs e)
        {
            SetDefaultPageSettings();

            bookNameTextBox.IsEnabled = true;
            numberOfPagesTextBox.IsEnabled = true;
            costPriceTextBox.IsEnabled = true;
            isSequelTextBox.IsEnabled = true;
            authorIdTextBox.IsEnabled = true;

            _adminPageViewModel.PrepareForNewBookAdding();
        }

        private void addNewAuthorButton_Click(object sender, RoutedEventArgs e)
        {
            SetDefaultPageSettings();

            authorFirstNameTextBox.IsEnabled = true;
            authorlastNameTextBox.IsEnabled = true;

            _adminPageViewModel.PrepareForNewAuthorAdding();
        }

        private void addNewGenreButton_Click(object sender, RoutedEventArgs e)
        {
            SetDefaultPageSettings();

            genreNameTextBox.IsEnabled = true;

            _adminPageViewModel.PrepareForNewGenreAdding();
        }

        private void addNewPublishinghouseButton_Click(object sender, RoutedEventArgs e)
        {
            SetDefaultPageSettings();

            publishingHouseNameTextBox.IsEnabled = true;

            _adminPageViewModel.PrepareForNewPubHouseAdding();
        }

        private void addbookOnSaleButton_Click(object sender, RoutedEventArgs e)
        {
            SetDefaultPageSettings();

            bookIdTextBox.IsEnabled = true;
            sellPriceTextBox.IsEnabled = true;
            datePutUpForSaleTextBox.IsEnabled = true;
            publishingHouseIdTextBox.IsEnabled = true;
            publishingDateTextBox.IsEnabled = true;

            _adminPageViewModel.PrepareForNewBookOnSaleAdding();
        }

        private void addGenreToBookButton_Click(object sender, RoutedEventArgs e)
        {
            SetDefaultPageSettings();

            bookIdTextBox.IsEnabled = true;
            genreIdTextBox.IsEnabled = true;

            _adminPageViewModel.PrepareForNewGenreToBookAdding();
        }

        private void sellBookButton_Click(object sender, RoutedEventArgs e)
        {
            SetDefaultPageSettings();

            bookonSaleIdTextBox.IsEnabled = true;
            customerIdTextBox.IsEnabled = true;

            _adminPageViewModel.PrepareForBookSelling();
        }

        private void addDiscountButton_Click(object sender, RoutedEventArgs e)
        {
            SetDefaultPageSettings();

            bookonSaleIdTextBox.IsEnabled = true;
            dicountTextBox.IsEnabled = true;

            _adminPageViewModel.PrepareForDiscountAdding();
        }

        private void updateBookButton_Click(object sender, RoutedEventArgs e)
        {
            SetDefaultPageSettings();

            bookIdTextBox.IsEnabled = true;
            bookNameTextBox.IsEnabled = true;
            numberOfPagesTextBox.IsEnabled = true;
            costPriceTextBox.IsEnabled = true;
            isSequelTextBox.IsEnabled = true;
            authorIdTextBox.IsEnabled = true;

            _adminPageViewModel.PrepareForBookUpdating();
        }

        private void updateAuthorButton_Click(object sender, RoutedEventArgs e)
        {
            SetDefaultPageSettings();

            authorIdTextBox.IsEnabled = true;
            authorFirstNameTextBox.IsEnabled = true;
            authorlastNameTextBox.IsEnabled = true;

            _adminPageViewModel.PrepareForAuthorUpdating();
        }

        private void updateGenreButton_Click(object sender, RoutedEventArgs e)
        {
            SetDefaultPageSettings();

            genreIdTextBox.IsEnabled = true;
            genreNameTextBox.IsEnabled = true;

            _adminPageViewModel.PrepareForGenreUpdating();
        }

        private void updatePublishinHouseButton_Click(object sender, RoutedEventArgs e)
        {
            SetDefaultPageSettings();

            publishingHouseIdTextBox.IsEnabled = true;
            publishingHouseNameTextBox.IsEnabled = true;

            _adminPageViewModel.PrepareForPubHouseUpdating();
        }

        private void updateBookOnSaleButton_Click(object sender, RoutedEventArgs e)
        {
            SetDefaultPageSettings();

            bookonSaleIdTextBox.IsEnabled = true;
            bookIdTextBox.IsEnabled = true;
            sellPriceTextBox.IsEnabled = true;
            datePutUpForSaleTextBox.IsEnabled = true;
            publishingHouseIdTextBox.IsEnabled = true;
            publishingDateTextBox.IsEnabled = true;

            _adminPageViewModel.PrepareForBookOnSaleUpdating();
        }

        private void removeDiscountButton_Click(object sender, RoutedEventArgs e)
        {
            SetDefaultPageSettings();

            bookonSaleIdTextBox.IsEnabled = true;

            _adminPageViewModel.PrepareForDiscountRemove();
        }

        private void removeBookFromSaleButton_Click(object sender, RoutedEventArgs e)
        {
            SetDefaultPageSettings();

            bookonSaleIdTextBox.IsEnabled = true;

            _adminPageViewModel.PrepareForSaleRemoval();
        }

        private void reserveBookButton_Click(object sender, RoutedEventArgs e)
        {
            SetDefaultPageSettings();

            bookonSaleIdTextBox.IsEnabled = true;
            customerIdTextBox.IsEnabled = true;

            _adminPageViewModel.PrepareForBookReserving();
        }

        #endregion



        private void submitButton_Click(object sender, RoutedEventArgs e)
        {
            if (_adminPageViewModel.BookAdding) SubmitBookAdding();

            else if (_adminPageViewModel.AuthorAdding) SubmitAuthorAdding();

            else if (_adminPageViewModel.GenreAdding) SubmitGenreAdding();

            else if (_adminPageViewModel.PublishingHOuseAdding) SubmitPublishingHouseAdding();

            else if (_adminPageViewModel.BookOnSaleAdding) SubmitBookOnSaleAdding();

            else if (_adminPageViewModel.GenreToBookAdding) SubmitGenreToBookAdding();

            else if (_adminPageViewModel.BookSelling) SubmitBookSelling();

            else if (_adminPageViewModel.DiscountAdding) SubmitDiscountAdding();

            else if (_adminPageViewModel.BookUpdating) SubmitBookUpdating();

            else if (_adminPageViewModel.AuthorUpdating) SubmitAuthorUpdating();

            else if (_adminPageViewModel.GenreUpdating) SubmitGenreUpdating();

            else if (_adminPageViewModel.PublisherHouseUpdating) SubmitPublishingHouseUpdating();


            _adminPageViewModel.SetAllActionsToFalse();
            SetDefaultPageSettings();
        }

        private void SubmitBookAdding()
        {
            Dictionary<string, string> d = new Dictionary<string, string>();

            if (bookNameTextBox.Text != String.Empty && bookNameTextBox.Text != "Book name"
                && numberOfPagesTextBox.Text != String.Empty && numberOfPagesTextBox.Text != "# of pages"
                && costPriceTextBox.Text != String.Empty && costPriceTextBox.Text != "Cost Price"
                && isSequelTextBox.Text != String.Empty && isSequelTextBox.Text != "Is sequel(0/1)"
                && authorIdTextBox.Text != String.Empty && authorIdTextBox.Text != "Author Id")
            {
                d.Add("BookName", bookNameTextBox.Text);
                d.Add("NumberOfPages", numberOfPagesTextBox.Text);
                d.Add("CostPrice", costPriceTextBox.Text);
                d.Add("IsSequel", isSequelTextBox.Text);
                d.Add("AuthorId", authorIdTextBox.Text);

                _adminPageViewModel.AddNewBook(d);
                tableDataGrid.ItemsSource = _adminPageViewModel.GetBooks().DefaultView;
            }
        }

        private void SubmitAuthorAdding()
        {
            Dictionary<string, string> d = new Dictionary<string, string>();

            if (authorFirstNameTextBox.Text != String.Empty && authorFirstNameTextBox.Text != "Author first name"
                && authorlastNameTextBox.Text != String.Empty && authorlastNameTextBox.Text != "Author last name")
            {
                d.Add("Author first name", authorFirstNameTextBox.Text);
                d.Add("Author last name", authorlastNameTextBox.Text);

                _adminPageViewModel.AddNewAuthor(d);
                tableDataGrid.ItemsSource = _adminPageViewModel.GetAuthors().DefaultView;
            }
        }

        private void SubmitGenreAdding()
        {
            Dictionary<string, string> d = new Dictionary<string, string>();

            if (genreNameTextBox.Text != String.Empty && authorFirstNameTextBox.Text != "Genre name")
            {
                d.Add("Genre name", genreNameTextBox.Text);

                _adminPageViewModel.AddNewGenre(d);
                tableDataGrid.ItemsSource = _adminPageViewModel.GetGenres().DefaultView;
            }
        }

        private void SubmitPublishingHouseAdding()
        {
            Dictionary<string, string> d = new Dictionary<string, string>();

            if (publishingHouseNameTextBox.Text != String.Empty && publishingHouseNameTextBox.Text != "Publishing house name")
            {
                d.Add("Publishing house name", publishingHouseNameTextBox.Text);

                _adminPageViewModel.AddNewPublishingHouse(d);
                tableDataGrid.ItemsSource = _adminPageViewModel.GetPublishingHouses().DefaultView;
            }
        }

        private void SubmitBookOnSaleAdding()
        {
            Dictionary<string, string> d = new Dictionary<string, string>();

            if (bookIdTextBox.Text != String.Empty && bookIdTextBox.Text != "Book Id" 
                && publishingHouseIdTextBox.Text != String.Empty && bookIdTextBox.Text != "Publishing house Id"
                && sellPriceTextBox.Text != String.Empty && bookIdTextBox.Text != "Sell price"
                && datePutUpForSaleTextBox.Text != String.Empty && bookIdTextBox.Text != "Date put up for sale(mm/dd/yyyy)"
                && publishingDateTextBox.Text != String.Empty && bookIdTextBox.Text != "Publishing date(mm/dd/yyyy)")
            {
                d.Add("Book Id", bookIdTextBox.Text);
                d.Add("Publishing house Id", publishingHouseIdTextBox.Text);
                d.Add("Sell price", sellPriceTextBox.Text);
                d.Add("Date put up for sale", datePutUpForSaleTextBox.Text);
                d.Add("Publishing date", publishingDateTextBox.Text);

                _adminPageViewModel.AddNewBookOnSale(d);
                tableDataGrid.ItemsSource = _adminPageViewModel.GetBooksOnSale().DefaultView;
            }
        }

        private void SubmitGenreToBookAdding()
        {
            Dictionary<string, string> d = new Dictionary<string, string>();

            if (genreIdTextBox.Text != String.Empty && genreIdTextBox.Text != "Genre Id"
                && bookIdTextBox.Text != String.Empty && bookIdTextBox.Text != "Book Id")
            {
                d.Add("Genre Id", genreIdTextBox.Text);
                d.Add("Book Id", bookIdTextBox.Text);

                _adminPageViewModel.AddNewGenreToBook(d);
            }
        }

        private void SubmitBookSelling()
        {
            Dictionary<string, string> d = new Dictionary<string, string>();

            if (bookonSaleIdTextBox.Text != String.Empty && bookonSaleIdTextBox.Text != "Book in sale Id"
                && customerIdTextBox.Text != String.Empty && customerIdTextBox.Text != "Customer Id")
            {
                d.Add("Book in sale Id", bookonSaleIdTextBox.Text);
                d.Add("Customer Id", customerIdTextBox.Text);

                _adminPageViewModel.SellBook(d);
                tableDataGrid.ItemsSource = _adminPageViewModel.GetSoldBooks().DefaultView;
            }
        }

        private void SubmitDiscountAdding()
        {
            Dictionary<string, string> d = new Dictionary<string, string>();

            if (dicountTextBox.Text != String.Empty && dicountTextBox.Text != "Discount(in %)"
                && bookonSaleIdTextBox.Text != String.Empty && bookonSaleIdTextBox.Text != "Book in sale Id")
            {
                d.Add("Book in sale Id", bookonSaleIdTextBox.Text);
                d.Add("Discount", dicountTextBox.Text);

                _adminPageViewModel.AddDiscount(d);
                tableDataGrid.ItemsSource = _adminPageViewModel.GetBooksOnSale().DefaultView;

            }
        }

        private void SubmitBookUpdating()
        {
            Dictionary<string, string> d = new Dictionary<string, string>();

            if (bookNameTextBox.Text != String.Empty && bookNameTextBox.Text != "Book name")
                d.Add("Book name", bookNameTextBox.Text);
            else
                d.Add("Book name", String.Empty);


            if (numberOfPagesTextBox.Text != String.Empty && numberOfPagesTextBox.Text != "# of pages")
                d.Add("Number of pages", numberOfPagesTextBox.Text);
            else
                d.Add("Number of pages", String.Empty);


            if (costPriceTextBox.Text != String.Empty && costPriceTextBox.Text != "Cost Price")
                d.Add("Cost Price", costPriceTextBox.Text);
            else
                d.Add("Cost Price", String.Empty);


            if (isSequelTextBox.Text != String.Empty && isSequelTextBox.Text != "Is sequel(0/1)")
                d.Add("Is sequel", isSequelTextBox.Text);
            else
                d.Add("Is sequel", String.Empty);


            if (authorIdTextBox.Text != String.Empty && authorIdTextBox.Text != "Author Id")
                d.Add("Author Id", authorIdTextBox.Text);
            else
                d.Add("Author Id", String.Empty);


            if (bookIdTextBox.Text != String.Empty && authorIdTextBox.Text != "Book Id")
            {
                d.Add("Book Id", bookIdTextBox.Text);

                _adminPageViewModel.UpdateBook(d);
                tableDataGrid.ItemsSource = _adminPageViewModel.GetBooks().DefaultView;
            }


        }

        private void SubmitAuthorUpdating()
        {
            Dictionary<string, string> d = new Dictionary<string, string>();
            
            if (authorFirstNameTextBox.Text != String.Empty && authorFirstNameTextBox.Text != "Author first name")
                d.Add("Author first name", authorFirstNameTextBox.Text);
            else
                d.Add("Author first name", String.Empty);


            if (authorlastNameTextBox.Text != String.Empty && authorlastNameTextBox.Text != "Author last name")
                d.Add("Author last name", authorlastNameTextBox.Text);
            else
                d.Add("Author last name", String.Empty);


            if (authorIdTextBox.Text != String.Empty && authorIdTextBox.Text != "Author Id")
            {
                d.Add("Author Id", authorIdTextBox.Text);

                _adminPageViewModel.UpdateAuthor(d);
                tableDataGrid.ItemsSource = _adminPageViewModel.GetAuthors().DefaultView;
            }
        }

        private void SubmitGenreUpdating()
        {
            Dictionary<string, string> d = new Dictionary<string, string>();

            if (genreNameTextBox.Text != String.Empty && genreNameTextBox.Text != "Genre name")
                d.Add("Genre name", genreNameTextBox.Text);
            else
                d.Add("Genre name", String.Empty);


            if (genreIdTextBox.Text != String.Empty && genreIdTextBox.Text != "Genre Id")
            {
                d.Add("Genre Id", genreIdTextBox.Text);

                _adminPageViewModel.UpdateGenre(d);
                tableDataGrid.ItemsSource = _adminPageViewModel.GetGenres().DefaultView;
            }
        }

        private void SubmitPublishingHouseUpdating()
        {
            Dictionary<string, string> d = new Dictionary<string, string>();

            if (publishingHouseNameTextBox.Text != String.Empty && publishingHouseNameTextBox.Text != "Publishing house name")
                d.Add("Publishing house name", publishingHouseNameTextBox.Text);
            else
                d.Add("Publishing house name", String.Empty);


            if (publishingHouseIdTextBox.Text != String.Empty && publishingHouseIdTextBox.Text != "Publishing house Id")
            {
                d.Add("Publishing house Id", publishingHouseIdTextBox.Text);

                _adminPageViewModel.UpdatePublishingHouse(d);
                tableDataGrid.ItemsSource = _adminPageViewModel.GetPublishingHouses().DefaultView;
            }

        }



    }
}
