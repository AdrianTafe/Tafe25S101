using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace Calculator
{
	/// <summary>
	/// An empty page that can be used on its own or navigated to within a Frame.
	/// </summary>
	public sealed partial class MortgagePage : Page
	{
		public MortgagePage()
		{
			this.InitializeComponent();
		}

		private void Calculator_Click(object sender, RoutedEventArgs e)
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

			monthlyRateTextBox.Text = monthlyInterestRate.ToString("P2");
			monthlyRepaymentTextBox.Text = monthlyPayment.ToString("C");


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
			this.Frame.Navigate(typeof(MainMenu));
		}
	}
}
