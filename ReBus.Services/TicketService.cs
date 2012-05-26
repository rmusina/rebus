using System;
using System.Collections.Generic;
using ReBus.Model;
using ReBus.Services.API;

namespace ReBus.Services
{
    public class TicketService : ITicketService
    {
        public Ticket BuyTicket(Account account, Bus bus)
        {
            throw new NotImplementedException();
        }

        public Ticket GetActiveTicket(Account account)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Ticket> GetTicketHistory(Account account)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Ticket> GetTicketHistory(Account account, int limit)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Ticket> GetTicketHistory(Account account, DateTime before, int limit)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Ticket> GetTicketHistory(Account account, DateTime after)
        {
            throw new NotImplementedException();
        }
    }
}