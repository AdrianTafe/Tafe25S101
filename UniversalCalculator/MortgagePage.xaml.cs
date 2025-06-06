using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Security.Cryptography.Core;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace TestMortgage
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class SecondPage : Page
    {
        public SecondPage()
        {
            this.InitializeComponent();
        }
        
        private async void CalculatorButton_Click(object sender, RoutedEventArgs e)
        {
            double principal;
            double annualInterestRate;
            int loanTermYears;
            int loanTermMonths;

            principal = double.Parse(principalTextBox.Text);
            annualInterestRate = double.Parse(yearlyRateTextBox.Text);

            loanTermYears = int.Parse(yearTextBox.Text);
            loanTermMonths = int.Parse(monthsTextBox.Text);


            double monthlyInterestRate = annualInterestRate / 100 / 12;
            int totalLoanTermMonths = (loanTermYears * 12) + loanTermMonths;

            double monthlyPayment = CalculateMonthlyRepayment(principal, monthlyInterestRate, totalLoanTermMonths);

            monthlyRateTextBox.Text = monthlyInterestRate.ToString("N4", CultureInfo.InvariantCulture);
            monthlyRepaymentTextBox.Text = monthlyPayment.ToString("N2", CultureInfo.InvariantCulture);


        }

        private double CalculateMonthlyRepayment(double principal, double monthlyInterestRate, int n)
        {
            double i = monthlyInterestRate;

            if (i == 0)
            {
                return principal / n;
            }

            double factor = Math.Pow(1 + i, n);
            double M = principal * (i * factor) / (factor - 1);
            return M;
        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            principalTextBox.Text = "";
            yearTextBox.Text = "";
            monthsTextBox.Text = "";
            yearlyRateTextBox.Text = "";
            monthlyRateTextBox.Text = "";
            monthlyRepaymentTextBox.Text = "";

        }
    }
}
