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
using WP7_Barcode_Library;
using WP7_Common_Code;
using com;
using System.Diagnostics;
using Microsoft.Phone.Tasks;
using ReBus.Mobile.Model;
using System.Windows.Media.Imaging;
using ReBus.Mobile.AuthenticationServiceReference;
using ReBus.Mobile.TicketServiceReference;
using ReBus.Mobile.SubscriptionServiceReference;

namespace ReBus.Mobile
{
    public partial class ReBusPivotMenu : PhoneApplicationPage
    {
        private List<HistoryItem> historyList;
        private List<SubscriptionData> subscriptionsList;
        private TicketData ticketData;

        public ReBusPivotMenu()
        {
            InitializeComponent();

            accountUserNameTextBlock.Text = (App.Current as App).UserData.FirstName;
            accountUserSurnameTextBlock.Text = (App.Current as App).UserData.LastName;
            accountCreditTextBlock.Text = (App.Current as App).UserData.Credit.ToString();

            SubscriptionWebServiceClient subscriptionService = new SubscriptionWebServiceClient();
            subscriptionService.GetActiveSubscriptinsCompleted += new EventHandler<GetActiveSubscriptinsCompletedEventArgs>(subscriptionService_GetActiveSubscriptinsCompleted);
            subscriptionService.GetActiveSubscriptinsAsync((App.Current as App).SUserData);

            TicketWebServiceClient ticketService = new TicketWebServiceClient();
            ticketService.GetActiveTicketCompleted += new EventHandler<GetActiveTicketCompletedEventArgs>(ticketService_GetActiveTicketCompleted);
            ticketService.GetActiveTicketAsync((App.Current as App).TUserData);

            subscriptionService.GetHistoryCompleted += new EventHandler<SubscriptionServiceReference.GetHistoryCompletedEventArgs>(subscriptionService_GetHistoryCompleted);
            subscriptionService.GetHistoryAsync((App.Current as App).SUserData);
            
            subscriptionsList = new List<SubscriptionData>();
            subscriptionsListBox.ItemsSource = subscriptionsList;

            historyList = new List<HistoryItem>();
            historyListBox.ItemsSource = historyList;
        }

        void subscriptionService_GetHistoryCompleted(object sender, SubscriptionServiceReference.GetHistoryCompletedEventArgs e)
        {
            String defaultDate = "26/5/2012 15:20:00";
            for (int i = 0; i < 10; i++)
            {
                string type = "ticket";
                if (i % 2 == 0)
                    type = "subscription";
                HistoryItem newItem = new HistoryItem(type, i.ToString(), defaultDate, "/Images/qrtest.jpg");
                historyList.Add(newItem);
            }

            HistoryItem currentHistoryItem = historyList[0];

            largeQRImage.Source = new BitmapImage(new Uri(currentHistoryItem.QR, UriKind.Relative));
            typeTextBlock.Text = currentHistoryItem.Type;
            dateTextBlock.Text = currentHistoryItem.Date;
        }

        void ticketService_GetActiveTicketCompleted(object sender, GetActiveTicketCompletedEventArgs e)
        {
            String defaultDate = "26/5/2012 15:20:00";
            ticketData = new TicketData("Test", defaultDate, "/Images/qrtest.jpg");
            ticketButton.DataContext = ticketData;
        }

        void subscriptionService_GetActiveSubscriptinsCompleted(object sender, GetActiveSubscriptinsCompletedEventArgs e)
        {
            String defaultDate = "26/5/2012 15:20:00";
            for (int i = 0; i < 10; i++)
            {
                subscriptionsList.Add(new SubscriptionData("24B", defaultDate, defaultDate, "/Images/qrtest.jpg"));
            }
        }

        private void buyTicket_button_Click(object sender, EventArgs e)
        {
            try
            {
                this.NavigationService.Navigate(new Uri("/BuyTicketPage.xaml", UriKind.Relative));
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Error processing image.", ex);
            }
        }

        public void BarcodeResults_Finished(BarcodeCaptureResult BCResults)
        {
            try
            {
                if (WP7BarcodeManager.LastCaptureResults.BarcodeImage != null)
                {
                    image1.Source = WP7BarcodeManager.LastCaptureResults.BarcodeImage; //Display image
                }
                else
                {
                    //No image captured
                }
                if (BCResults.State == WP7_Barcode_Library.CaptureState.Success)
                {
                    qrResultsTextBlock.Text = BCResults.BarcodeText; //Use results
                }
                else
                {
                    Debug.WriteLine(BCResults.ErrorMessage);
                    qrResultsTextBlock.Text = "BCResults error: " + BCResults.ErrorMessage;
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(String.Format("QR Code Processing Error: {0}", ex.Message));
                qrResultsTextBlock.Text = "Exception: " + ex.Message;
            }
        }

        private void ticketButton_Click(object sender, RoutedEventArgs e)
        {
            TicketData ticketData = ((TicketData)((Button)sender).DataContext);
            string ticketPageUri = "/TicketPage.xaml?Name=" + ticketData.Name + "&Date=" + ticketData.Date;
            this.NavigationService.Navigate(new Uri(ticketPageUri, UriKind.Relative));
        }

        private void historyListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ListBox currentList = (ListBox)sender;
            ListBoxItem item = currentList.ItemContainerGenerator.ContainerFromItem(currentList.SelectedItem) as ListBoxItem;
            HistoryItem currentHistoryItem = ((HistoryItem)item.DataContext);

            largeQRImage.Source = new BitmapImage(new Uri(currentHistoryItem.QR, UriKind.Relative));
            typeTextBlock.Text = currentHistoryItem.Type;
            dateTextBlock.Text = currentHistoryItem.Date;
        }
    }
}