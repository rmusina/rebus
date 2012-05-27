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
using ReBus.Mobile.TicketCollector.AuthenticationWebServiceReference;

namespace ReBus.Mobile.TicketCollector
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
        /*    if (userNameTextBox.Text.Equals("") || passwordTextBox.Password.Equals(""))
            {
                MessageBox.Show("Toate campurile trebuie completate.");
            }
            else
            {
                AuthenticationWebServiceClient proxy = new AuthenticationWebServiceClient();
                proxy.AuthenticateTicketControllerCompleted += new EventHandler<AuthenticateTicketControllerCompletedEventArgs>(proxy_AuthenticateTicketControllerCompleted);
                proxy.AuthenticateTicketControllerAsync(userNameTextBox.Text, passwordTextBox.Password);
            }*/
            this.NavigationService.Navigate(new Uri("/ReBusPivotMenu.xaml", UriKind.Relative));
        }

        void proxy_AuthenticateTicketControllerCompleted(object sender, AuthenticateTicketControllerCompletedEventArgs e)
        {
            if (e.Error == null && e.Result != null)
            {
                this.NavigationService.Navigate(new Uri("/ReBusPivotMenu.xaml", UriKind.Relative));
            }
            else
            {
                MessageBox.Show("Eroare la login");
            }
        }
    }
}