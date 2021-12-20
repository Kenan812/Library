using Library.ViewModel;
using System.Data;
using System.Windows;
using System.Windows.Controls;

namespace Library.View
{
    /// <summary>
    /// Interaction logic for CustomerPageWindow.xaml
    /// </summary>
    public partial class CustomerPageWindow : Window
    {
        private CustomerPageViewModel _customerPageViewModel;
        public CustomerPageWindow(string username)
        {
            InitializeComponent();
            _customerPageViewModel = new CustomerPageViewModel(username);

            usernameLabel.Content = _customerPageViewModel.UserName;
            tableDataGrid.ItemsSource = _customerPageViewModel.GetMyBooks().DefaultView;
        }

        private void showBooksButton_Click(object sender, RoutedEventArgs e)
        {
            tableDataGrid.ItemsSource = _customerPageViewModel.GetMyBooks().DefaultView;
        }

        private void showBooksForAuthorCbi_Selected(object sender, RoutedEventArgs e)
        {
            specifierLabel.Content = "Authors";
            searchListComboBox.ItemsSource = _customerPageViewModel.GetAllAuthors();
        }

        private void showBooksForBookNameCbi_Selected(object sender, RoutedEventArgs e)
        {
            specifierLabel.Content = "Books";
            searchListComboBox.ItemsSource = _customerPageViewModel.GetAllBooks();
        }

        private void showBooksForGenreCbi_Selected(object sender, RoutedEventArgs e)
        {
            specifierLabel.Content = "Genres";
            searchListComboBox.ItemsSource = _customerPageViewModel.GetAllGenres();
        }
         

        private void searchListComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                if (searchListComboBox.SelectedIndex != -1)
                {
                    if (specifierLabel.Content.ToString() == "Authors")
                    {
                        string[] s = searchListComboBox.SelectedItem.ToString().Split(' ');
                        DataTable dt = _customerPageViewModel.GetBooksByAuthor(s[0], s[1]);

                        if (dt == null) MessageBox.Show("No books on sale for current author", "Unable to find book on sale", MessageBoxButton.OK, MessageBoxImage.Information);
                        else tableDataGrid.ItemsSource = dt.DefaultView;
                    }


                    else if (specifierLabel.Content.ToString() == "Books")
                    {
                        DataTable dt = _customerPageViewModel.GetBookByBookName(searchListComboBox.SelectedItem.ToString());

                        if (dt == null) MessageBox.Show("No books on sale for current book name", "Unable to find book on sale", MessageBoxButton.OK, MessageBoxImage.Information);
                        else tableDataGrid.ItemsSource = dt.DefaultView;
                    }

                    else if (specifierLabel.Content.ToString() == "Genres")
                    {
                        DataTable dt = _customerPageViewModel.GetBookByGenre(searchListComboBox.SelectedItem.ToString());

                        if (dt == null) MessageBox.Show("No books on sale for current genre", "Unable to find book on sale", MessageBoxButton.OK, MessageBoxImage.Information);
                        else tableDataGrid.ItemsSource = dt.DefaultView;
                    }
                }
            }
            catch (System.Exception ex)
            {
                MessageBox.Show($"Message: {ex.Message}\n\nStack Trace: {ex.StackTrace}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }



        private void showLatestCbi_Selected(object sender, RoutedEventArgs e)
        {
            DataTable table = _customerPageViewModel.GetLatestAddedBooks();

            if (table == null) MessageBox.Show("No recent books for slae added", "Unable to find book on sale", MessageBoxButton.OK, MessageBoxImage.Information);
            else tableDataGrid.ItemsSource = table.DefaultView;
        }

        private void showMostPopularAuthorsCbi_Selected(object sender, RoutedEventArgs e)
        {
            DataTable table = _customerPageViewModel.GetMostPopularAuthors();

            if (table == null) MessageBox.Show("No authors in database", "Unable to find 'Authors'", MessageBoxButton.OK, MessageBoxImage.Information);
            else tableDataGrid.ItemsSource = table.DefaultView;
        }

        private void showMostPopularBooksCbi_Selected(object sender, RoutedEventArgs e)
        {
            DataTable table = _customerPageViewModel.GetMostPopularBooks();

            if (table == null) MessageBox.Show("No books in database", "Unable to find 'Books'", MessageBoxButton.OK, MessageBoxImage.Information);
            else tableDataGrid.ItemsSource = table.DefaultView;
        }

        private void showMostPopularGenresCbi_Selected(object sender, RoutedEventArgs e)
        {
            DataTable table = _customerPageViewModel.GetMostPopularGenres();
            
            if (table == null) MessageBox.Show("No genres in database", "Unable to find 'Genres'", MessageBoxButton.OK, MessageBoxImage.Information);
            else tableDataGrid.ItemsSource = table.DefaultView;
        }
    }
}
