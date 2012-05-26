using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;
using ReBus.Model;

namespace ReBus.WebServices.WebServiceModel
{
    [DataContract]
    public class SubscriptionWebServiceModel
    {
        [DataMember]
        public Guid GUID { get; set; }

        [DataMember]
        public IEnumerable<LineWebServiceModel> Lines { get; set; }

        [DataMember]
        public AccountWebServiceModel Account { get; set; }

        [DataMember]
        public DateTime Start { get; set; }

        [DataMember]
        public DateTime End { get; set; }

        [DataMember]
        public DateTime Created { get; set; }

        public static SubscriptionWebServiceModel FromDataModel(Subscription subscription)
        {
            return FromDataModel(subscription, subscription == null ? null : AccountWebServiceModel.FromModelObject(subscription.Account));
        }

        public static SubscriptionWebServiceModel FromDataModel(Subscription subscription, AccountWebServiceModel account)
        {
            if (subscription == null)
                return null;

            return new SubscriptionWebServiceModel
            {
                GUID = subscription.GUID,
                Account = account,
                Created = subscription.Created,
                End = subscription.End,
                Lines = subscription.Lines.Select(LineWebServiceModel.FromDataModel).ToList(),
                Start = subscription.Start
            };
        }
    }
}