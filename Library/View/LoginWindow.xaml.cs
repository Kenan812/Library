using Library.ViewModel;
using System;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;

namespace Library.View
{
    /// <summary>
    /// Interaction logic for LoginWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {
        private LoginWindowViewModel loginWindowViewModel;

        public LoginWindow()
        {
            InitializeComponent();

            loginWindowViewModel = new LoginWindowViewModel();
        }

        #region Admin Label

        private void adminLabel_MouseEnter(object sender, MouseEventArgs e)
        {
            if (adminLabel.Foreground != Brushes.Red)
                adminLabel.Foreground = (SolidColorBrush)new BrushConverter().ConvertFrom("#283caa");
        }

        private void adminLabel_MouseLeave(object sender, MouseEventArgs e)
        {
            if (adminLabel.Foreground != Brushes.Red)
                adminLabel.Foreground = Brushes.White;
        }

        private void adminLabel_MouseDown(object sender, MouseButtonEventArgs e)
        {
            adminLabel.Foreground = Brushes.Red;
            customerLabel.Foreground = Brushes.White;

            loginWindowViewModel.SetUserAdmin();
        }

        #endregion


        #region Customer Label

        private void customerLabel_MouseEnter(object sender, MouseEventArgs e)
        {
            if (customerLabel.Foreground != Brushes.Red)
                customerLabel.Foreground = (SolidColorBrush)new BrushConverter().ConvertFrom("#283caa");
        }

        private void customerLabel_MouseLeave(object sender, MouseEventArgs e)
        {
            if (customerLabel.Foreground != Brushes.Red)
                customerLabel.Foreground = Brushes.White;
        }

        private void customerLabel_MouseDown(object sender, MouseButtonEventArgs e)
        {
            customerLabel.Foreground = Brushes.Red;
            adminLabel.Foreground = Brushes.White;

            loginWindowViewModel.SetUserCustomer();
        }

        #endregion


        #region Register Label

        private void registerLabel_MouseEnter(object sender, MouseEventArgs e)
        {
            registerLabel.Foreground = (SolidColorBrush)new BrushConverter().ConvertFrom("#283caa");
        }

        private void registerLabel_MouseLeave(object sender, MouseEventArgs e)
        {
            registerLabel.Foreground = Brushes.White;
        }

        private void registerLabel_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (loginWindowViewModel.IsUserAdmin())
            {
                RegisterNewAdminWindow registerNewAdminWindow = new RegisterNewAdminWindow();
                registerNewAdminWindow.ShowDialog();
            }
            else if (loginWindowViewModel.IsUserCustomer())
            {
                RegisterNewCustomerWindow registerNewCustomerWindow = new RegisterNewCustomerWindow();
                registerNewCustomerWindow.ShowDialog();
            }
            else
            {
                MessageBox.Show("User not chosen", "Unable to open registration window", MessageBoxButton.OK);
            }


        }

        #endregion


        #region Username textbox

        private void usernameTextBox_GotFocus(object sender, RoutedEventArgs e)
        {
            if (usernameTextBox.Text == "Username")
            {
                usernameTextBox.Text = String.Empty;
                usernameTextBox.Foreground = Brushes.White;
            }
        }

        private void usernameTextBox_LostFocus(object sender, RoutedEventArgs e)
        {
            if (usernameTextBox.Text == String.Empty)
            {
                usernameTextBox.Text = "Username";
                usernameTextBox.Foreground = (SolidColorBrush)new BrushConverter().ConvertFrom("#a6a6a6");
            }
        }

        #endregion



        #region Password textbox


        private void passwordTextBox_GotFocus(object sender, RoutedEventArgs e)
        {
            if (passwordTextBox.Text == "Password")
            {
                passwordTextBox.Text = String.Empty;
                passwordTextBox.Foreground = Brushes.White;
            }
        }

        private void passwordTextBox_LostFocus(object sender, RoutedEventArgs e)
        {
            if (passwordTextBox.Text == String.Empty)
            {
                passwordTextBox.Text = "Password";
                passwordTextBox.Foreground = (SolidColorBrush)new BrushConverter().ConvertFrom("#a6a6a6");
            }
        }


        #endregion


    }
}
