using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using Microsoft.Phone.Controls;

namespace ReBus.Mobile
{
    public partial class MainPage : PhoneApplicationPage
    {
        // Constructor
        public MainPage()
        {
            InitializeComponent();
        }

        private void logInButton_Click(object sender, RoutedEventArgs e)
        {
            // TODO: log in

            this.NavigationService.Navigate(new Uri("/ReBusPivotMenu.xaml", UriKind.Relative));
        }

        private void NewAccountButton_Click(object sender, EventArgs e)
        {
            this.NavigationService.Navigate(new Uri("/AccountCreationPage.xaml", UriKind.Relative));
        }
    }
}