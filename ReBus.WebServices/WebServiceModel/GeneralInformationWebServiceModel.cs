using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;
using ReBus.Model;

namespace ReBus.WebServices.WebServiceModel
{
    [DataContract]
    public class GeneralInformationWebServiceModel
    {
        [DataMember]
        public decimal TicketPrice { get; set; }

        [DataMember]
        public IDictionary<int, decimal> SubscriptionPrices { get; set; }

        [DataMember]
        public IEnumerable<LineWebServiceModel> Lines { get; set; }
    }
}