using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Classes_1___KlasseBankrekening
{
    public partial class MainWindow : Window
    {
        private BankAccount account = new BankAccount();

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            account.CurrentBalance = 500;
            balanceTextBox.Text = account.CurrentBalance.ToString();

            amountTextBox.Focus();
        }

        private void amountTextBox_KeyDown(object sender, KeyEventArgs e)
        {

            if ((e.Key >= Key.NumPad0 && e.Key <= Key.NumPad9) || // cijfers 0 tot 9
                (e.Key >= Key.D0 && e.Key <= Key.D9) ||
                e.Key == Key.Subtract || e.Key == Key.Add ||  //  '­-' of '+'
                e.Key == Key.OemComma || // ','
                e.Key == Key.LeftShift || e.Key == Key.RightShift)
            {
                // Als we geldige tekens invoeren: event nog niet afhandelen
                e.Handled = false;
            }
            else if (e.Key == Key.Return)
            {
                // Als we op enter drukken (return toets): event afhandelen
                e.Handled = true;
                decimal amount;
                bool isSucceeded = decimal.TryParse(amountTextBox.Text, out amount);
                if (!isSucceeded)
                {
                    MessageBox.Show("Geef correct getal", "Bedrag niet numeriek", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                else
                {
                    if (amount >= 0)
                    {
                        // indien bedrag positief dan verhogen.
                        account.Deposit(amount);
                    }
                    else
                    {
                        try
                        {
                            // indien bedrag negatief dan verminderen.
                            account.Withdrawel(-amount); // negatief bedrag positief maken, want in method gaan we aftrekken

                        }
                        catch (ArithmeticException)
                        {
                            MessageBox.Show($"Bedrag ontoereikend.\r\n\r\nHuidig saldo is {account.CurrentBalance:c}", "Invoer fout!");
                        }
                    }
                }

                // Stand van de rekening weergeven
                balanceTextBox.Text = account.CurrentBalance.ToString();
                amountTextBox.Focus();
                amountTextBox.Clear();
            }
            else
            {
                e.Handled = true;
                MessageBox.Show("Geef correct getal", "Bedrag niet numeriek", MessageBoxButton.OK, MessageBoxImage.Error);
                amountTextBox.Focus();
                amountTextBox.SelectAll();
            }
        }
    }
}
