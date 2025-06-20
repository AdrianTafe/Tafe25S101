﻿using Calculator;
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
	public sealed partial class MainMenu : Page
	{
		public MainMenu()
		{
			this.InitializeComponent();
		}
		//The click function for the currency button 
		private void CurrencyButton_Click(object sender, RoutedEventArgs e)
		{
			this.Frame.Navigate(typeof(CurrencyPage));
		}

		private void mortgageButton_Click(object sender, RoutedEventArgs e)
		{
			this.Frame.Navigate(typeof(MortgagePage));
		}

		private void unitButton_Click(object sender, RoutedEventArgs e)
		{
			this.Frame.Navigate(typeof(UnitPage));
		}

		private void mathsButton_Click(object sender, RoutedEventArgs e)
		{
			this.Frame.Navigate(typeof(MainPage));
        }
		private void tripButton_Click(object sender, RoutedEventArgs e)
		{
			//Trip Calculator C# code will be developed later
		}
	}
	
}
