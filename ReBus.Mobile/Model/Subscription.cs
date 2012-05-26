using System;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;

namespace ReBus.Mobile.Model
{
    public class Subscription
    {

    }

    public class SubscriptionData
    {
        public string Line
        {
            get;
            set;
        }

        public string StartDate
        {
            get;
            set;
        }

        public string EndDate
        {
            get;
            set;
        }

        public string QR
        {
            get;
            set;
        }

        public SubscriptionData(string line, string startDate, string endDate, string qr)
        {
            this.Line = line;
            this.StartDate = startDate;
            this.EndDate = endDate;
            this.QR = qr;
        }
    }
}
