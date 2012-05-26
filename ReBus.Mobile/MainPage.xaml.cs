﻿using System;
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
using ReBus.Mobile.AuthenticatoinServiceReference;

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
            if (userNameTextBox.Text.Equals("") || passwordTextBox.Password.Equals(""))
            {
                MessageBox.Show("Toate campurile trebuie completate.");
            }
            else
            {
                AuthenticationWebServiceClient proxy = new AuthenticationWebServiceClient();
                proxy.AuthenticateCompleted += new EventHandler<AuthenticateCompletedEventArgs>(proxy_AuthenticateCompleted);
                proxy.AuthenticateAsync(userNameTextBox.Text, passwordTextBox.Password);
            }
        }

        void proxy_AuthenticateCompleted(object sender, AuthenticateCompletedEventArgs e)
        {
            if (e.Error == null && e.Result != null)
            {
                this.NavigationService.Navigate(new Uri("/ReBusPivotMenu.xaml", UriKind.Relative));
            }
            else
            {
                MessageBox.Show("Eroare la log in.");
            }
        }

        private void NewAccountButton_Click(object sender, EventArgs e)
        {
            this.NavigationService.Navigate(new Uri("/AccountCreationPage.xaml", UriKind.Relative));
        }
    }
}