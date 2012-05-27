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
using System.Windows.Navigation;
using System.Diagnostics;
using System.Windows.Media.Imaging;

using Microsoft.Devices;
using com.google.zxing;
using com.google.zxing.common;
using com.google.zxing.qrcode;
using System.Windows.Threading;
using System.Collections.ObjectModel;
using ReBus.Mobile.QRModel;
using ReBus.Mobile.TicketServiceReference;
using ReBus.Mobile.InformationServiceReference;

namespace ReBus.Mobile
{
    public partial class BuyTicketPage : PhoneApplicationPage
    {
        private readonly DispatcherTimer timer;

        private PhotoCameraLuminanceSource luminance;
        private QRCodeReader reader;
        private PhotoCamera photoCamera;

        public BuyTicketPage()
        {
            InitializeComponent();

            timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromMilliseconds(250);
            timer.Tick += (o, arg) => ScanPreviewBuffer();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            photoCamera = new PhotoCamera();
            previewVideo.SetSource(photoCamera);
            photoCamera.Initialized += OnPhotoCameraInitialized;

            CameraButtons.ShutterKeyHalfPressed += (o, arg) => photoCamera.Focus();

            base.OnNavigatedTo(e);
        }

        private void OnPhotoCameraInitialized(object sender, CameraOperationCompletedEventArgs e)
        {
            int width = Convert.ToInt32(photoCamera.PreviewResolution.Width);
            int height = Convert.ToInt32(photoCamera.PreviewResolution.Height);

            luminance = new PhotoCameraLuminanceSource(width, height);
            reader = new QRCodeReader();

            Dispatcher.BeginInvoke(() =>
            {
                previewTransform.Rotation = photoCamera.Orientation;
                timer.Start();
            });
        }

        private void ScanPreviewBuffer()
        {
            try
            {
                photoCamera.GetPreviewBufferY(luminance.PreviewBufferY);
                var binarizer = new HybridBinarizer(luminance);
                var binBitmap = new BinaryBitmap(binarizer);
                var result = reader.decode(binBitmap);
                Dispatcher.BeginInvoke(() => DisplayResult(result.Text));
            }
            catch
            {
            }
        }

        private void DisplayResult(string text)
        {
            try
            {
                qrResultTextBlock.Text = "Succes";
                if (MessageBox.Show("Esti sigur ca doresti acest bilet (ii scump)?",
                    "Confirma tranzactia", MessageBoxButton.OKCancel) == MessageBoxResult.OK)
                {
                    (App.Current as App).BusGuid = new Guid(text);

                    InformationWebServiceClient informationService = new InformationWebServiceClient();
                    informationService.GetBusCompleted += new EventHandler<GetBusCompletedEventArgs>(informationService_GetBusCompleted);
                    informationService.GetBusAsync((App.Current as App).BusGuid);

                    timer.Stop();
                    photoCamera.Dispose();      
                }              
            }
            catch
            {
                qrResultTextBlock.Text = "Scaneaza din nou...";
            }
        }

        void informationService_GetBusCompleted(object sender, GetBusCompletedEventArgs e)
        {
            if (e.Result == null)
            {
                timer.Stop();
                photoCamera.Dispose();  
                MessageBox.Show("Detaliile autobuzului nu au fost descarcate!");
                this.NavigationService.GoBack();
            }
            else
            {
                TicketWebServiceClient ticketService = new TicketWebServiceClient();
                ticketService.BuyTicketCompleted += new EventHandler<BuyTicketCompletedEventArgs>(ticketService_BuyTicketCompleted);

                TicketServiceReference.BusWebServiceModel busServiceModel = new TicketServiceReference.BusWebServiceModel();
                busServiceModel.GUID = e.Result.GUID;
                ticketService.BuyTicketAsync((App.Current as App).TUserData, busServiceModel);  
            }
        }

        void ticketService_BuyTicketCompleted(object sender, BuyTicketCompletedEventArgs e)
        {
            if (e.Result == null)
            {
                MessageBox.Show("Biletul nu a putut fi cumparat!");
            }
            else
            {
                timer.Stop();
                photoCamera.Dispose();
                MessageBox.Show("Biletul a fost cumparat cu succes!");
                this.NavigationService.GoBack();
            }
        }
    }
}