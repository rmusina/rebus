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
    public partial class TicketPage : PhoneApplicationPage
    {
        public TicketPage()
        {
            InitializeComponent();
        }

        private void PhoneApplicationPage_Loaded(object sender, RoutedEventArgs e)
        {
            if (this.NavigationContext.QueryString.ContainsKey("Name"))
            {
                userNameTextBlock.Text = NavigationContext.QueryString["Name"];
            }
            if (this.NavigationContext.QueryString.ContainsKey("Date"))
            {
                dateTextBlock.Text = NavigationContext.QueryString["Date"];
            }
        }
    }
}