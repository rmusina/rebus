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
using System.Windows.Threading;
using ReBus.Mobile.QRModel;
using com.google.zxing.qrcode;
using Microsoft.Devices;
using com.google.zxing.common;
using com.google.zxing;
using System.Windows.Navigation;

namespace ReBus.Mobile.TicketCollector
{
    public partial class ReBusPivotMenu : PhoneApplicationPage
    {
        bool busIdentified = false;

        private readonly DispatcherTimer timer;

        private PhotoCameraLuminanceSource luminance;
        private QRCodeReader reader;
        private PhotoCamera photoCamera;

        public ReBusPivotMenu()
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

        private void scanNewTicket_button_Click(object sender, EventArgs e)
        {

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
                if (!busIdentified)
                {
                    (App.Current as App).BusGuid = new Guid(text);
                    (App.Current as App).BusGuidString = text;
                    qrResultTextBlock.Text = "Identificare bilet...";
                    busIdentified = true;
                }
                else
                {
                    if (!text.Equals((App.Current as App).BusGuidString))
                    {
                        qrResultTextBlock.Text = "Verificare bilet...";
                    }
                }
            }
            catch
            {
                qrResultTextBlock.Text = "Scaneaza din nou...";
            }
        }
    }
}