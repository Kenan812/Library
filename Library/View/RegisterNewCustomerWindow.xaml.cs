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
    /// Interaction logic for RegisterNewCustomerWindow.xaml
    /// </summary>
    public partial class RegisterNewCustomerWindow : Window
    {
        private RegisterNewCustomerViewModel _registerNewCustomerViewModel;

        public RegisterNewCustomerWindow()
        {
            InitializeComponent();

            _registerNewCustomerViewModel = new RegisterNewCustomerViewModel();
        }

        #region Firstname Text Box

        private void firstNameTextBox_GotFocus(object sender, RoutedEventArgs e)
        {
            if (firstNameTextBox.Text == "First name")
            {
                firstNameTextBox.Text = String.Empty;
                firstNameTextBox.Foreground = Brushes.White;
            }
        }

        private void firstNameTextBox_LostFocus(object sender, RoutedEventArgs e)
        {
            if (firstNameTextBox.Text == String.Empty)
            {
                firstNameTextBox.Text = "First name";
                firstNameTextBox.Foreground = (SolidColorBrush)new BrushConverter().ConvertFrom("#a6a6a6");
            }
        }

        #endregion


        #region Last Name Text Box

        private void lastNameTextBox_GotFocus(object sender, RoutedEventArgs e)
        {
            if (lastNameTextBox.Text == "Last name")
            {
                lastNameTextBox.Text = String.Empty;
                lastNameTextBox.Foreground = Brushes.White;
            }
        }

        private void lastNameTextBox_LostFocus(object sender, RoutedEventArgs e)
        {
            if (lastNameTextBox.Text == String.Empty)
            {
                lastNameTextBox.Text = "Last name";
                lastNameTextBox.Foreground = (SolidColorBrush)new BrushConverter().ConvertFrom("#a6a6a6");
            }
        }

        #endregion


        #region User Name Text Box

        private void userNameTextBox_GotFocus(object sender, RoutedEventArgs e)
        {
            if (userNameTextBox.Text == "Username")
            {
                userNameTextBox.Text = String.Empty;
                userNameTextBox.Foreground = Brushes.White;
            }
        }

        private void userNameTextBox_LostFocus(object sender, RoutedEventArgs e)
        {
            if (userNameTextBox.Text == String.Empty)
            {
                userNameTextBox.Text = "Username";
                userNameTextBox.Foreground = (SolidColorBrush)new BrushConverter().ConvertFrom("#a6a6a6");
            }
        }

        #endregion


        #region Password Texx Box

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


        #region Age TExt Box

        private void ageTextBox_GotFocus(object sender, RoutedEventArgs e)
        {
            if (ageTextBox.Text == "Age")
            {
                ageTextBox.Text = String.Empty;
                ageTextBox.Foreground = Brushes.White;
            }
        }

        private void ageTextBox_LostFocus(object sender, RoutedEventArgs e)
        {
            if (ageTextBox.Text == String.Empty)
            {
                ageTextBox.Text = "Age";
                ageTextBox.Foreground = (SolidColorBrush)new BrushConverter().ConvertFrom("#a6a6a6");
            }
        }

        #endregion

        private void submitButton_Click(object sender, RoutedEventArgs e)
        {
            if (firstNameTextBox.Text == String.Empty || firstNameTextBox.Text == "First name" ||
                lastNameTextBox.Text == String.Empty || lastNameTextBox.Text == "Last name" ||
                userNameTextBox.Text == String.Empty || userNameTextBox.Text == "Username" ||
                passwordTextBox.Text == String.Empty || passwordTextBox.Text == "Password" ||
                ageTextBox.Text == String.Empty || ageTextBox.Text == "Age")
            {
                MessageBox.Show("Input is invalid");
                return;
            }

            _registerNewCustomerViewModel.RegisterCustomer(firstNameTextBox.Text, lastNameTextBox.Text, userNameTextBox.Text, passwordTextBox.Text, ageTextBox.Text);
            this.Close();
        }

        private void returnButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
