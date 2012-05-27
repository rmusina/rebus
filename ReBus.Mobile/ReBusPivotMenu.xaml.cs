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
using System.Collections.ObjectModel;
using System.Windows.Navigation;

namespace ReBus.Mobile
{
    public partial class ReBusPivotMenu : PhoneApplicationPage
    {
        private ObservableCollection<HistoryItem> historyList;
        private ObservableCollection<SubscriptionData> subscriptionsList;
        private TicketData ticketData;

        private bool ticketHistoryRecieved = false;
        private bool subscriptionHistoryRecieved = false;

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

            ticketService.GetHistoryCompleted += new EventHandler<TicketServiceReference.GetHistoryCompletedEventArgs>(ticketService_GetHistoryCompleted);
            ticketService.GetHistoryAsync((App.Current as App).TUserData);

            subscriptionService.GetHistoryCompleted += new EventHandler<SubscriptionServiceReference.GetHistoryCompletedEventArgs>(subscriptionService_GetHistoryCompleted);
            subscriptionService.GetHistoryAsync((App.Current as App).SUserData);

            subscriptionsList = new ObservableCollection<SubscriptionData>();
            subscriptionsListBox.ItemsSource = subscriptionsList;

            historyList = new ObservableCollection<HistoryItem>();
            historyListBox.ItemsSource = historyList;
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            if ((App.Current as App).ShouldRequestAgain)
            {
                (App.Current as App).ShouldRequestAgain = false;

                SubscriptionWebServiceClient subscriptionService = new SubscriptionWebServiceClient();
                subscriptionService.GetActiveSubscriptinsCompleted += new EventHandler<GetActiveSubscriptinsCompletedEventArgs>(subscriptionService_GetActiveSubscriptinsCompleted);
                subscriptionService.GetActiveSubscriptinsAsync((App.Current as App).SUserData);

                TicketWebServiceClient ticketService = new TicketWebServiceClient();
                ticketService.GetActiveTicketCompleted += new EventHandler<GetActiveTicketCompletedEventArgs>(ticketService_GetActiveTicketCompleted);
                ticketService.GetActiveTicketAsync((App.Current as App).TUserData);

                ticketService.GetHistoryCompleted += new EventHandler<TicketServiceReference.GetHistoryCompletedEventArgs>(ticketService_GetHistoryCompleted);
                ticketService.GetHistoryAsync((App.Current as App).TUserData);

                subscriptionService.GetHistoryCompleted += new EventHandler<SubscriptionServiceReference.GetHistoryCompletedEventArgs>(subscriptionService_GetHistoryCompleted);
                subscriptionService.GetHistoryAsync((App.Current as App).SUserData);
            }

            base.OnNavigatedTo(e);
        }

        void ticketService_GetHistoryCompleted(object sender, TicketServiceReference.GetHistoryCompletedEventArgs e)
        {
            if (e.Result != null)
            {
                for (int i = 0; i < e.Result.Count; i++)
                {
                    TicketWebServiceModel currentTicket = e.Result[i];
                    HistoryItem newItem = new HistoryItem("Ticket", currentTicket.Bus.Line.Name, currentTicket.Created.ToString(), "/Images/Bank account.png");
                    historyList.Add(newItem);
                }
                ticketHistoryRecieved = true;

                if (subscriptionHistoryRecieved)
                    SortHistoryByDate();
            }
        }

        void subscriptionService_GetHistoryCompleted(object sender, SubscriptionServiceReference.GetHistoryCompletedEventArgs e)
        {
            if (e.Result != null)
            {
                for (int i = 0; i < e.Result.Count; i++)
                {
                    SubscriptionWebServiceModel currentSubscription = e.Result[i];
                    string subscribedLines = "";
                    for (int j = 0; j < currentSubscription.Lines.Count; j++)
                    {
                        SubscriptionServiceReference.LineWebServiceModel currentLine = currentSubscription.Lines[i];
                        subscribedLines += currentLine.Name;
                        if (j < currentSubscription.Lines.Count - 1)
                            subscribedLines += ", ";
                    }
                    HistoryItem newItem = new HistoryItem("Subscription", subscribedLines, currentSubscription.Start.ToString(), "/Images/Account card.png");
                    historyList.Add(newItem);
                }
                subscriptionHistoryRecieved = true;

                if (ticketHistoryRecieved)
                    SortHistoryByDate();
            }
        }

        void ticketService_GetActiveTicketCompleted(object sender, GetActiveTicketCompletedEventArgs e)
        {
            if (e.Result != null)
            {
                ticketButton.Visibility = System.Windows.Visibility.Visible;
                noActiveTicketTextBlock.Visibility = System.Windows.Visibility.Collapsed;
                string qrUri = "http://qrcode.kaywa.com/img.php?s=12&d=" + e.Result.GUID.ToString();
                ticketData = new TicketData(e.Result.Bus.Line.Name, e.Result.Created.ToString(), qrUri);
                ticketButton.DataContext = ticketData;
            }
            else
            {
                ticketButton.Visibility = System.Windows.Visibility.Collapsed;
                noActiveTicketTextBlock.Visibility = System.Windows.Visibility.Visible;
            }
        }

        void subscriptionService_GetActiveSubscriptinsCompleted(object sender, GetActiveSubscriptinsCompletedEventArgs e)
        {
            if (e.Result != null)
            {
                for (int i = 0; i < e.Result.Count; i++)
                {
                    SubscriptionWebServiceModel currentSubscription = e.Result[i];
                    string subscribedLines = "";
                    for (int j = 0; j < currentSubscription.Lines.Count; j++)
                    {
                        SubscriptionServiceReference.LineWebServiceModel currentLine = currentSubscription.Lines[i];
                        subscribedLines += currentLine.Name;
                        if (j < currentSubscription.Lines.Count - 1)
                            subscribedLines += ", ";
                    }
                    subscriptionsList.Add(new SubscriptionData(subscribedLines, currentSubscription.Start.ToString(),
                        currentSubscription.End.ToString(), "/Images/Account card.png"));
                }
            }
        }

        private void SortHistoryByDate()
        {
            if (historyList.Count > 0)
            {
                // TODO sort

                HistoryItem currentHistoryItem = historyList[0];

                largeQRImage.Source = new BitmapImage(new Uri(currentHistoryItem.QR, UriKind.Relative));
                typeTextBlock.Text = currentHistoryItem.Type;
                dateTextBlock.Text = currentHistoryItem.Date;
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

        private void ticketButton_Click(object sender, RoutedEventArgs e)
        {
            if (((Button)sender).DataContext != null)
            {
                TicketData ticketData = ((TicketData)((Button)sender).DataContext);
                string ticketPageUri = "/TicketPage.xaml?Name=" + ticketData.Name + "&Date=" + ticketData.Date;
                (App.Current as App).ActiveTicketQrUrl = ticketData.QR;
                this.NavigationService.Navigate(new Uri(ticketPageUri, UriKind.Relative));
            }
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

        private void addCreditButton_Click(object sender, RoutedEventArgs e)
        {
            if (amountTextBox.Text.Equals(""))
            {
                MessageBox.Show("Adauga o suma!");
            }
            else
            {
                //TODO: alimentare cont
            }
        }
    }
}