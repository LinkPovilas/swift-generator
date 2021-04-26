using System;
using System.Text.RegularExpressions;
using System.Windows;

namespace SwiftGenerator.Errors
{
    internal class ErrorPrompt
    {
        public void CheckFields(string[] array)
        {
            string
                date = array[0], number = array[1],
                name = array[2], account = array[3],
                amount = array[4];

            Regex numPattern = new Regex("^(([1-9]\\d*)?\\d)((\\.|\\,)(\\d |\\d\\d))?$");
            Regex checkForZeroes = new Regex("^[1-9][0-9]*$");

            if (string.IsNullOrEmpty(date) && string.IsNullOrEmpty(number) && string.IsNullOrEmpty(name) && string.IsNullOrEmpty(account) && string.IsNullOrEmpty(amount))
            {
                MessageBox.Show(Application.Current.MainWindow, "System Error ( ͡° ͜ʖ ͡°)", "Error");
                throw new Exception("All of the fields are empty");
            }

            if (string.IsNullOrEmpty(date))
            {
                MessageBox.Show(Application.Current.MainWindow, "Date is empty", "Error");
                throw new Exception("Date is empty");
            }

            if (string.IsNullOrEmpty(name))
            {
                MessageBox.Show(Application.Current.MainWindow, "Name is empty", "Error");
                throw new Exception("Name is empty");
            }

            if (string.IsNullOrEmpty(account))
            {
                MessageBox.Show(Application.Current.MainWindow, "IBAN is empty", "Error");
                throw new Exception("iban is empty");
            }

            if (string.IsNullOrEmpty(amount))
            {
                MessageBox.Show(Application.Current.MainWindow, "Amount is empty", "Error");
                throw new Exception("Amount is empty");
            }

            if (DateTime.TryParse(date, out DateTime dDate))
            {
                String.Format("{0:d/MM/yyyy}", dDate);
            }
            else
            {
                MessageBox.Show(Application.Current.MainWindow, "You've entered: " + "\"" + date + "\"" + ". Date format should be YYYY-MM-DD");
                throw new Exception("Wrong date format");
            }

            if (Int32.Parse(number) > 500)
            {
                MessageBox.Show(Application.Current.MainWindow, "Restricted to maximum: 500 files", "Error");
                throw new Exception("Too many files requested error");
            }

            if (!checkForZeroes.Match(number).Success)
            {
                MessageBox.Show(Application.Current.MainWindow, "Sanity error", "Error");
                throw new Exception("Sanity error");
            }

            if (!numPattern.Match(amount).Success)
            {
                MessageBox.Show(Application.Current.MainWindow, "Not a valid amount format.", "Error");
                throw new Exception("Wrong amount format");
            }

            if (amount.Equals("0") || amount.Equals("0.00") || amount.Equals("0,00"))
            {
                MessageBox.Show(Application.Current.MainWindow, "Wrong amount format. Amount can not be equal to zero.", "Error");
                throw new Exception("Wrong amount format");
            }
        }
    }
}