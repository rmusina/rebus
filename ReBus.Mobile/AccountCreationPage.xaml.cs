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
using System.ServiceModel;
using ReBus.Mobile.AuthenticationServiceReference;
using System.Windows.Controls.Primitives;

namespace ReBus.Mobile
{
    public partial class AccountCreationPage : PhoneApplicationPage
    {
        Popup popup;

        public AccountCreationPage()
        {
            InitializeComponent();
        }

        private void ShowPopup()
        {
            this.popup = new Popup();
            this.popup.Child = new PopupSplash();
            this.popup.IsOpen = true;
        }

        private void HidePopup()
        {
            this.popup.IsOpen = false;
        }

        private void createAccountButton_Click(object sender, RoutedEventArgs e)
        {
            if (userTextBox.Text.Equals("") || pass1TextBox.Password.Equals("") || 
                pass2TextBox.Password.Equals("") || nameTextBox.Text.Equals("") || 
                surnameTextBox.Text.Equals(""))
            {
                MessageBox.Show("Toate campurile trebuie completate.");
            }
            else if (!pass1TextBox.Password.Equals(pass2TextBox.Password))
            {
                MessageBox.Show("Parolele nu sunt aceleasi.");
            }
            else
            {
                AuthenticationWebServiceClient proxy = new AuthenticationWebServiceClient();
                proxy.RegisterCompleted += new EventHandler<RegisterCompletedEventArgs>(proxy_RegisterCompleted);
                proxy.RegisterAsync(userTextBox.Text, pass1TextBox.Password, nameTextBox.Text, surnameTextBox.Text);
                ShowPopup();
            }
        }

        void proxy_RegisterCompleted(object sender, RegisterCompletedEventArgs e)
        {
            if (string.IsNullOrEmpty(e.Result) && e.Error == null)
            {
                MessageBox.Show("Un nou cont a fost creat.");
                this.NavigationService.GoBack();
            }
            else
            {
                MessageBox.Show("Eroare in crearea noului utilizator.");
            }
            HidePopup();
        }
    }
}