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
    public class Ticket
    {

    }

    public class TicketData
    {
        public string Name
        {
            get;
            set;
        }

        public string Date
        {
            get;
            set;
        }

        public string QR
        {
            get;
            set;
        }

        public TicketData(string name, string date, string qr)
        {
            this.Name = name;
            this.Date = date;
            this.QR = qr;
        }
    }
}
