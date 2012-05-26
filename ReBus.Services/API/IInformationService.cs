using System;
using System.Collections.Generic;
using ReBus.Model;

namespace ReBus.Services.API
{
    public interface IInformationService
    {
        decimal GetTicketPrice();

        IDictionary<int, decimal> GetSubscriptionPrices();

        IEnumerable<Line> GetLines();

        Bus GetBus(Guid bus);

        Ticket GetTicket(Guid ticket);

        Subscription GetSubscription(Guid subscription);

        Object GetSubscriptionOrTicket(Guid guid);
    }
}