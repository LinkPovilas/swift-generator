using MahApps.Metro.Controls;
using SwiftGenerator.Authentication;
using SwiftGenerator.Errors;
using SwiftGenerator.Utility;
using System;
using System.Diagnostics;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace SwiftGenerator
{

    public partial class MainWindow : MetroWindow
    {
        public RadioButton env;
        public string ccy;
        private readonly BankIdentification bank = new BankIdentification();
        public string bic;
        public bool errorReceived;
        string sid;
        string password;

        public MainWindow()
        {
            InitializeComponent();
            WindowStartupLocation = WindowStartupLocation.CenterScreen;
            Currencies.ItemsSource = Enum.GetValues(typeof(Enums.Currencies));
            DateField.Text = DateTime.Now.ToString("yyyy-MM-dd");

        }

        private void RadioButton_Checked(object sender, RoutedEventArgs e)
        {
            {
                RadioButton ck = sender as RadioButton;
                if (ck.IsChecked.Value)
                    env = ck;
            }
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            DateField.Text = DateTime.Now.ToString("yyyy-MM-dd");
            NumberField.Text = "1";
            NameField.Text = "";
            AccountField.Text = "";
            AmountField.Text = "";
        }

        private void NumericField_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("^[1-9]\\d*$");
            e.Handled = !regex.IsMatch(e.Text);

            if (!string.IsNullOrEmpty(NumberField.Text))
            {
                regex = new Regex("^[0-9]\\d*$");
                e.Handled = !regex.IsMatch(e.Text);
            }
        }

        private void NumericField2_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("^[0-9.,]*$");
            e.Handled = !regex.IsMatch(e.Text);
        }

        private void Generate_Click(object sender, RoutedEventArgs e)
        {
            if (env == null) env = ALT;

            ccy = Currencies.SelectedItem.ToString();
            bic = bank.SetBIC(env).ToString();
            errorReceived = false;

            try
            {
                ErrorPrompt err = new ErrorPrompt();
                err.CheckFields(GetAllValues());
            }
            catch (Exception x)
            {
                errorReceived = true;
                Debug.WriteLine("<<< catch : " + x.ToString());
            }

            switch (errorReceived)
            {
                case false:
                    if (MessageBox.Show("Create " + NumberField.Text + " file(s)?", "Confirmation", MessageBoxButton.OKCancel) == MessageBoxResult.OK)
                    {
                        switch (FTPtoggle.IsOn)
                        {
                            case true:

                                AuthenticationWindow authenticationWindow = new AuthenticationWindow();
                                authenticationWindow.Show();
                                authenticationWindow.Activate();
                                // authenticationWindow.Topmost = true;
                                break;

                            case false:
                                ReaderAndWriter writer = new ReaderAndWriter();

                                int count = 1;
                                int times = Int32.Parse(NumberField.Text);
                                bool moreThanOnce = times > 1;

                                while (count <= times)
                                {
                                    writer.WriteFile(env.Name, bic, DateField.Text, NameField.Text, AccountField.Text, AmountField.Text, ccy, count, moreThanOnce);
                                    count++;
                                }
                                MessageBox.Show("Accepted");
                                break;
                        }
                    }
                    else
                    {
                        Debug.WriteLine("Client declined");
                    }
                    break;

                case true:
                    break;
            }
        }

        private string[] GetAllValues()
        {
            return new string[] { DateField.Text, NumberField.Text, NameField.Text, AccountField.Text, AmountField.Text };
        }

        public void PassData(string sid, string password)
        {
            if (env == null) env = ALT;
            ccy = Currencies.SelectedItem.ToString();
            bic = bank.SetBIC(env).ToString();
            bool writeErr = false;
            ReaderAndWriter writer = new ReaderAndWriter();

            int count = 1;
            int times = Int32.Parse(NumberField.Text);
            bool moreThanOnce = times > 1;
            try
            {
                while (count <= times)
                {
                    writer.WriteFileToNetwork(env.Name, bic, DateField.Text, NameField.Text, AccountField.Text, AmountField.Text, ccy, count, moreThanOnce, sid, password);
                    count++;
                }
            }
            catch (Exception e)
            {
                Debug.WriteLine("<<< catch : " + e.ToString());
                writeErr = true;
                MessageBox.Show(Application.Current.MainWindow, e.Message);
            }
            if (!writeErr) { MessageBox.Show("Accepted"); }
        }
    }
}
