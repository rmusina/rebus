using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using ReBus.Model;
using ReBus.Services;
using ReBus.Services.API;
using ReBus.WebServices.WebServiceModel;

namespace ReBus.WebServices
{
    public class InformationWebService : IInformationWebService
    {
        readonly IInformationService informationService = new InformationService();

        public GeneralInformationWebServiceModel GetGeneralInformation()
        {
            return new GeneralInformationWebServiceModel
            {
                TicketPrice = informationService.GetTicketPrice(),
                Lines =  informationService.GetLines().Select(LineWebServiceModel.FromDataModel),
                SubscriptionPrices = informationService.GetSubscriptionPrices()
            };
        }

        public TicketWebServiceModel GetTicket(Guid guid)
        {
            return TicketWebServiceModel.FromDataModel(informationService.GetTicket(guid));
        }

        public SubscriptionWebServiceModel GetSubscription(Guid guid)
        {
            return SubscriptionWebServiceModel.FromDataModel(informationService.GetSubscription(guid));
        }

        public object GetSubscriptionOrTicket(Guid guid)
        {
            var obj = informationService.GetSubscriptionOrTicket(guid);
            if (obj is Ticket)
                return TicketWebServiceModel.FromDataModel((Ticket) obj);
            return SubscriptionWebServiceModel.FromDataModel((Subscription) obj);
        }
    }
}
