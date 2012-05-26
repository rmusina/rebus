using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ReBus.Model;
using ReBus.Services.API;

namespace ReBus.Services
{
    public class InformationService : IInformationService
    {
        public decimal GetTicketPrice()
        {
            throw new NotImplementedException();
        }

        public IDictionary<int, decimal> GetSubscriptionPrices()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Line> GetLines()
        {
            throw new NotImplementedException();
        }

        public Bus GetBus(Guid bus)
        {
            throw new NotImplementedException();
        }

        public Ticket GetTicket(Guid ticket)
        {
            throw new NotImplementedException();
        }

        public Subscription GetSubscription(Subscription subscription)
        {
            throw new NotImplementedException();
        }
    }
}
