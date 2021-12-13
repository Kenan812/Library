using Library.ViewModel;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

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


        private void SetDefaultPageSettings()
        {
            bookIdTextBox.Text = "Book Id";
            //bookIdTextBox.IsEnabled = false;

            bookNameTextBox.Text = "Book name";
            //bookNameTextBox.IsEnabled = false;

            numberOfPagesTextBox.Text = "# of pages";
            //numberOfPagesTextBox.IsEnabled = false;

            authorIdTextBox.Text = "Author Id";
            //authorIdTextBox.IsEnabled = false;

            costPriceTextBox.Text = "Cost Price";
            //costPriceTextBox.IsEnabled = false;

            isSequelTextBox.Text = "Is sequel(0/1)";
            //isSequelTextBox.IsEnabled = false;

            authorFirstNameTextBox.Text = "Author first name";
            //authorFirstNameTextBox.IsEnabled = false;

            authorlastNameTextBox.Text = "Author last name";
            //authorlastNameTextBox.IsEnabled = false;

        }


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


    }
}
