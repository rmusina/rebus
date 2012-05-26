using System;
using System.Collections.Generic;
using ReBus.Model;
using ReBus.Repository;
using ReBus.Services.API;
using System.Linq;

namespace ReBus.Services
{
    public class TicketService : ITicketService
    {
        ReBusContainer db = new ReBusContainer();

        /// <summary>
        /// Buy a new ticket.
        /// </summary>
        /// <param name="account">The account for which to buy the ticket</param>
        /// <param name="bus">The bus for which to buy the ticket</param>
        /// <returns></returns>
        public Ticket BuyTicket(Account account, Bus bus)
        {
            var ticket = new Ticket {Account = account, Bus = bus, Created = DateTime.Now};

            using (var insertDb = new ReBusContainer())
            {
                insertDb.Tickets.AddObject(ticket);
                insertDb.SaveChanges();
            }

            return ticket;
        }

        /// <summary>
        /// Get the currently active ticket of an account.
        /// </summary>
        /// <param name="account">The account for which to get the active ticket</param>
        /// <returns></returns>
        public Ticket GetActiveTicket(Account account)
        {
            DateTime validity = DateTime.Now - new TimeSpan(0, 0, 45);
            return db.Tickets
                .Where(t => t.Account == account)
                .Where(t => t.Created >= validity)
                .OrderByDescending(t => t.Created)
                .FirstOrDefault();
        }

        /// <summary>
        /// Get all the tickets associated to an account.
        /// </summary>
        /// <param name="account">The account for which to get the tickets</param>
        /// <returns></returns>
        public IEnumerable<Ticket> GetHistory(Account account)
        {
            return GetHistory(account, Int32.MaxValue);
        }

        /// <summary>
        /// Get latest tickets.
        /// </summary>
        /// <param name="account">The account for which to get the tickets</param>
        /// <param name="limit">The max number of thickets to fetch</param>
        /// <returns></returns>
        public IEnumerable<Ticket> GetHistory(Account account, int limit)
        {
            return GetHistory(account, DateTime.MaxValue, limit);
        }

        /// <summary>
        /// Get older tickets.
        /// </summary>
        /// <param name="account">The account for which to get the tickets</param>
        /// <param name="before">The date before which to get the tickets</param>
        /// <param name="limit">The max number of thickets to fetch</param>
        /// <returns></returns>
        public IEnumerable<Ticket> GetHistory(Account account, DateTime before, int limit)
        {
            return db.Tickets
                .Where(t => t.Account == account)
                .Where(t => t.Created < before)
                .OrderByDescending(t => t.Created)
                .Take(limit).ToList();
        }

        /// <summary>
        /// Get the tickets that have been added after a given date (used to refresh the list with new values).
        /// </summary>
        /// <param name="account">The account for which to get the tickets</param>
        /// <param name="after">The date of the last ticket the client has</param>
        /// <returns></returns>
        public IEnumerable<Ticket> GetNewTickets(Account account, DateTime after)
        {
            return db.Tickets
                .Where(t => t.Account == account)
                .Where(t => t.Created > after)
                .OrderByDescending(t => t.Created).ToList();
        }
    }
}