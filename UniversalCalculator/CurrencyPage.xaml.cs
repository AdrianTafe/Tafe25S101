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

namespace Calculator
{

	public sealed partial class CurrencyPage : Page
	{
		// Dictionary for currency conversion rates

		private readonly Dictionary<string, Dictionary<string, double>> conversionRates = new Dictionary<string, Dictionary<string, double>>()
		{
			["USD"] = new Dictionary<string, double> { ["EUR"] = 0.85189982, ["GBP"] = 0.72872436, ["INR"] = 74.257327 },
			["EUR"] = new Dictionary<string, double> { ["USD"] = 1.1739732, ["GBP"] = 0.8556672, ["INR"] = 87.00755 },
			["GBP"] = new Dictionary<string, double> { ["USD"] = 1.371907, ["EUR"] = 1.1686692, ["INR"] = 101.68635 },
			["INR"] = new Dictionary<string, double> { ["USD"] = 0.011492628, ["EUR"] = 0.013492774, ["GBP"] = 0.0098339397 }
		};

		// Dictionary mapping currency codes to their full names
		private readonly Dictionary<string, string> currencyNames = new Dictionary<string, string>()
		{
			["USD"] = "US Dollars",
			["EUR"] = "European Euros",
			["GBP"] = "Great British Pound",
			["INR"] = "Indian Rupee"
		};

		// Constructor: initializes the page and its components
		public CurrencyPage()
		{
			this.InitializeComponent();
		}

		// Event handler for the Convert button
		private void ConvertButton_Click(object sender, RoutedEventArgs e)
		{
			try
			{
				// Parse the amount entered by the user
				double amount = double.Parse(AmountTextBox.Text);

				// Extract selected currency codes from ComboBoxes
				string fromCurrencyCode = ((ComboBoxItem)FromCurrencyComboBox.SelectedItem).Content.ToString().Split('-')[0].Trim();
				string toCurrencyCode = ((ComboBoxItem)ToCurrencyComboBox.SelectedItem).Content.ToString().Split('-')[0].Trim();

				// Get full currency names for display
				string fromCurrencyName = currencyNames[fromCurrencyCode];
				string toCurrencyName = currencyNames[toCurrencyCode];

				// If the same currency is selected for both "from" and "to"
				if (fromCurrencyCode == toCurrencyCode)
				{
					InputSummaryTextBlock.Text = $"{amount:F2} {fromCurrencyName}";
					ConvertedAmountTextBlock.Text = $"{amount:F2} {toCurrencyName}";
					RateInfoTextBlock.Text = $"1 {fromCurrencyCode} = 1 {toCurrencyCode}";
					return;
				}

				// Perform conversion if rate is available
				if (conversionRates.ContainsKey(fromCurrencyCode) && conversionRates[fromCurrencyCode].ContainsKey(toCurrencyCode))
				{
					double rate = conversionRates[fromCurrencyCode][toCurrencyCode];
					double converted = amount * rate;

					InputSummaryTextBlock.Text = $"{amount:F2} {fromCurrencyName}";
					ConvertedAmountTextBlock.Text = $"{converted:F2} {toCurrencyName}";
					RateInfoTextBlock.Text = $"1 {fromCurrencyCode} = {rate:F4} {toCurrencyCode}";
				}
				else
				{
					// Handle case where conversion rate is not there
					InputSummaryTextBlock.Text = "";
					ConvertedAmountTextBlock.Text = "Conversion rate not available.";
					RateInfoTextBlock.Text = "";
				}
			}
			catch (Exception ex)
			{
				// Handle invalid input or other errors
				InputSummaryTextBlock.Text = "";
				ConvertedAmountTextBlock.Text = $"Error: {ex.Message}";
				RateInfoTextBlock.Text = "";
			}
		}

		// Event handler for the Exit button — navigates back to the main menu
		private void ExitButton_Click(object sender, RoutedEventArgs e)
		{
			this.Frame.Navigate(typeof(MainMenu));
		}
	}
}
