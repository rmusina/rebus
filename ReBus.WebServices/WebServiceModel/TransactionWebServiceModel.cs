using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ReBus.Model;
using System.ServiceModel;
using System.Runtime.Serialization;

namespace ReBus.WebServices.WebServiceModel
{
    [DataContract]
    public class TransactionWebServiceModel
    {
        [DataMember]
        public int Id
        {
            get;
            set;
        }

        [DataMember]
        public decimal Amount
        {
            get;
            set;
        }

        [DataMember]
        public int Type
        {
            get;
            set;
        }

        [DataMember]
        public DateTime Created
        {
            get;
            set;
        }

        public static TransactionWebServiceModel FromModelObject(Transaction transaction)
        {
            return new TransactionWebServiceModel()
                   {
                       Amount = transaction.Amount,
                       Id = transaction.Id,
                       Type = transaction.Type,
                       Created = transaction.Created
                   };
        }
    }
}