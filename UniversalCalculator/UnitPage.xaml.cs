using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Popups;
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
	public sealed partial class UnitPage : Page
	{
		public UnitPage()
		{
			this.InitializeComponent();
		}

		private async void convertButton_Click(object sender, RoutedEventArgs e)
		{
			double unitInput, result;

			//try and catch to ensure the input is numerical
			try
			{
				unitInput = double.Parse(inputTextBox.Text);
			}
			catch (Exception ex)
			{
				var dialog = new MessageDialog("Error! Please enter a valid number for the units input");
				await dialog.ShowAsync();
				inputTextBox.Focus(FocusState.Programmatic);
				inputTextBox.SelectAll();
				return;
			}

			//determine if conversion is metric to imperial
			if (metricToImperialRadioButton.IsChecked == true)
			{
				//determine the unit to be converted from metric to imperial
				if (temperatureRadioButton.IsChecked == true)
				{
					result = (unitInput * 1.8) + 32;
					outputTextBlock.Text = unitInput.ToString() + " degrees C is: " + result.ToString() + " degrees F";
				}
				else if (distanceRadioButton.IsChecked == true)
				{
					result = unitInput / 0.3048;
					outputTextBlock.Text = unitInput.ToString() + " metres is: " + result.ToString() + " feet";
				}
				else if (massRadioButton.IsChecked == true)
				{
					result = unitInput / 0.45359237;
					outputTextBlock.Text = unitInput.ToString() + " kilograms is: " + result.ToString() + " pounds";
				}
				else if (pressureRadioButton.IsChecked == true)
				{
					result = unitInput / 6.89475729;
					outputTextBlock.Text = unitInput.ToString() + " kPa is: " + result.ToString() + " psi";
				}
			}
			//determine if the conversion is imperial to metric
			else if (imperialToMetricRadioButton.IsChecked == true)
			{
				//determine the unit to be converted from imperial to metric
				if (temperatureRadioButton.IsChecked == true)
				{
					result = (unitInput - 32) / 1.8;
					outputTextBlock.Text = unitInput.ToString() + " degrees F is: " + result.ToString() + " degrees C";
				}
				else if (distanceRadioButton.IsChecked == true)
				{
					result = unitInput * 0.3048;
					outputTextBlock.Text = unitInput.ToString() + " feet is: " + result.ToString() + " metres";
				}
				else if (massRadioButton.IsChecked == true)
				{
					result = unitInput * 0.45359237;
					outputTextBlock.Text = unitInput.ToString() + " pounds is: " + result.ToString() + " kilograms";
				}
				else if (pressureRadioButton.IsChecked == true)
				{
					result = unitInput * 6.89475729;
					outputTextBlock.Text = unitInput.ToString() + " psi is: " + result.ToString() + " kPa";
				}
			}
		}

		private void temperatureRadioButton_Checked(object sender, RoutedEventArgs e)
		{
			//output if changed to the temperature radio button
			//metric conversion
			if (temperatureRadioButton.IsChecked == true && metricToImperialRadioButton.IsChecked == true)
			{
				outputTextBlock.Text = "Converting temperature from celsius to fahrenheit!";
			}
			//imperial conversion
			else if (temperatureRadioButton.IsChecked == true && imperialToMetricRadioButton.IsChecked == true)
			{
				outputTextBlock.Text = "Converting temperature from fahrenheit to celsius";
			}
		}

		private void distanceRadioButton_Checked(object sender, RoutedEventArgs e)
		{
			//output if changed to the distance radio button
			//metric conversion
			if (distanceRadioButton.IsChecked == true && metricToImperialRadioButton.IsChecked == true)
			{
				outputTextBlock.Text = "Converting distance from metre to foot!";
			}
			//imperial conversion
			else if (distanceRadioButton.IsChecked == true && imperialToMetricRadioButton.IsChecked == true)
			{
				outputTextBlock.Text = "Converting distance from foot to metre!";
			}
		}

		private void massRadioButton_Checked(object sender, RoutedEventArgs e)
		{
			//output if changed to the mass radio button
			//metric conversion
			if (massRadioButton.IsChecked == true && metricToImperialRadioButton.IsChecked == true)
			{
				outputTextBlock.Text = "Converting mass from kilogram to pound!";
			}
			//imperial conversion
			else if (massRadioButton.IsChecked == true && imperialToMetricRadioButton.IsChecked == true)
			{
				outputTextBlock.Text = "Converting mass from pound to kilogram";
			}
		}

		private void pressureRadioButton_Checked(object sender, RoutedEventArgs e)
		{
			//output if changed to the pressure radio button
			//metric conversion
			if (pressureRadioButton.IsChecked == true && metricToImperialRadioButton.IsChecked == true)
			{
				outputTextBlock.Text = "Converting pressure from kPa to psi!";
			}
			//imperial conversion
			else if (pressureRadioButton.IsChecked == true && imperialToMetricRadioButton.IsChecked == true)
			{
				outputTextBlock.Text = "Converting pressure from psi to kPa";
			}
		}

		private void exitButton_Click(object sender, RoutedEventArgs e)
		{
			//exit back to the main menu
			this.Frame.Navigate(typeof(MainMenu));
		}
	}
}
