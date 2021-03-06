﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using ReBus.WebServices.WebServiceModel;

namespace ReBus.WebServices
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IInformationWebService" in both code and config file together.
    [ServiceContract]
    public interface IInformationWebService
    {
        [OperationContract]
        GeneralInformationWebServiceModel GetGeneralInformation();

        [OperationContract]
        TicketWebServiceModel GetTicket(Guid guid);

        [OperationContract]
        SubscriptionWebServiceModel GetSubscription(Guid guid);

        [OperationContract]
        BusWebServiceModel GetBus(Guid guid);
//
//        [OperationContract]
//        Object GetSubscriptionOrTicket(Guid guid);
    }
}
