using System;
using System.Collections.Generic;
using System.Data.Objects;
using System.Transactions;
using ReBus.Model;
using ReBus.Repository;
using ReBus.Services.API;
using System.Linq;
using Transaction = ReBus.Model.Transaction;

namespace ReBus.Services
{
    public class TicketService : ITicketService
    {
        /// <summary>
        /// Buy a new ticket.
        /// </summary>
        /// <param name="account">The account for which to buy the ticket</param>
        /// <param name="bus">The bus for which to buy the ticket</param>
        /// <returns></returns>
        public Ticket BuyTicket(Account account, Bus bus)
        {
            using (ReBusContainer db = new ReBusContainer())
            {
                Ticket ticket;
                using (new TransactionScope())
                {
                    db.Accounts.Attach(account);
                    db.Buses.Attach(bus);
                    db.Refresh(RefreshMode.StoreWins, new Object[] { account, bus});

                    var cost = db.TicketCost.Single().Cost;
                    if (cost > account.Credit) { throw new InsufficientCreditException(); }

                    ticket = new Ticket { Account = account, Bus = bus, Created = DateTime.Now };
                    var transaction = new Transaction
                    {
                        Account = account,
                        Amount = cost,
                        Type = (int)TransactionType.Ticket,
                        Created = DateTime.Now
                    };
                    account.Credit -= cost;

                    db.Tickets.AddObject(ticket);
                    db.SaveChanges();
                }

                return ticket;
            }

        }

        /// <summary>
        /// Get the currently active ticket of an account.
        /// </summary>
        /// <param name="account">The account for which to get the active ticket</param>
        /// <returns></returns>
        public Ticket GetActiveTicket(Account account)
        {
            using (var db = new ReBusContainer())
            {
                db.Accounts.Attach(account);
                db.Refresh(RefreshMode.StoreWins, account);

                DateTime validity = DateTime.Now - new TimeSpan(0, 0, 45);
                return db.Tickets
                    .Where(t => t.Account == account)
                    .Where(t => t.Created >= validity)
                    .OrderByDescending(t => t.Created)
                    .FirstOrDefault();
                
            }
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
            using (var db = new ReBusContainer()) 
            {
                db.Accounts.Attach(account);
                db.Refresh(RefreshMode.StoreWins, account);

                return db.Tickets
                    .Where(t => t.Account == account)
                    .Where(t => t.Created < before)
                    .OrderByDescending(t => t.Created)
                    .Take(limit).ToList();
            }
        }

        /// <summary>
        /// Get the tickets that have been added after a given date (used to refresh the list with new values).
        /// </summary>
        /// <param name="account">The account for which to get the tickets</param>
        /// <param name="after">The date of the last ticket the client has</param>
        /// <returns></returns>
        public IEnumerable<Ticket> GetNewTickets(Account account, DateTime after)
        {
            using (var db = new ReBusContainer())
            {
                db.Accounts.Attach(account);
                db.Refresh(RefreshMode.StoreWins, account);

                return db.Tickets
                    .Where(t => t.Account == account)
                    .Where(t => t.Created > after)
                    .OrderByDescending(t => t.Created).ToList();
            }
        }
    }
}