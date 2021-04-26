using SwiftGenerator.Utility;
using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;

namespace SwiftGenerator.Authentication
{
    public partial class AuthenticationWindow : Window
    {
        public AuthenticationWindow()
        {
            InitializeComponent();
            WindowStartupLocation = WindowStartupLocation.CenterScreen;
        }

        private void Button_Click_OK(object sender, RoutedEventArgs e)
        {
            MainWindow main = new MainWindow();
            main.PassData(Sid.Text, UserPassword.Password);
            Close();
        }

        private void Button_Click_CANCEL(object sender, RoutedEventArgs e)
        {
            Debug.WriteLine("Client declined");
            Close();
        }
    }
}
