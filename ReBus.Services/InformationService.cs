using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ReBus.Model;
using ReBus.Repository;
using ReBus.Services.API;

namespace ReBus.Services
{
    public class InformationService : IInformationService
    {
        public decimal GetTicketPrice()
        {
            using (var db = new ReBusContainer())
            {
                return db.TicketCost.Single().Cost;
            }
        }

        public IDictionary<int, decimal> GetSubscriptionPrices()
        {
            using (var db = new ReBusContainer())
            {
                return db.SubscriptionCosts.ToDictionary(s => s.Lines, s => s.Cost);
            }
        }

        public IEnumerable<Line> GetLines()
        {
            using (var db = new ReBusContainer())
            {
                return db.Lines.ToList();
            }
        }

        public Bus GetBus(Guid bus)
        {
            using (var db = new ReBusContainer())
            {
                return db.Buses.Include("Line").SingleOrDefault(b => b.GUID == bus);
            }
        }

        public Ticket GetTicket(Guid ticket)
        {
            using (var db = new ReBusContainer())
            {
                return db.Tickets.Include("Account").Include("Bus").Include("Bus.Line").SingleOrDefault(t => t.GUID == ticket);
            }
        }

        public Subscription GetSubscription(Guid subscription)
        {
            using (var db = new ReBusContainer())
            {
                return db.Subscriptions.Include("Account").Include("Lines").SingleOrDefault(s => s.GUID == subscription);
            }
        }

        public object GetSubscriptionOrTicket(Guid guid)
        {
            var ticket = GetTicket(guid);

            if (ticket == null)
                return GetSubscription(guid);
            
            return ticket;
        }
    }
}
