using System;
using System.Collections.Generic;
using ReBus.Model;

namespace ReBus.Services.API
{
    public interface ITicketService
    {
        /// <summary>
        /// Buy a new ticket.
        /// </summary>
        /// <param name="account">The account for which to buy the ticket</param>
        /// <param name="bus">The bus for which to buy the ticket</param>
        /// <returns></returns>
        Ticket BuyTicket(Account account, Bus bus);

        /// <summary>
        /// Get the currently active ticket of an account.
        /// </summary>
        /// <param name="account">The account for which to get the active ticket</param>
        /// <returns></returns>
        Ticket GetActiveTicket(Account account);

        /// <summary>
        /// Get all the tickets associated to an account.
        /// </summary>
        /// <param name="account">The account for which to get the tickets</param>
        /// <returns></returns>
        IEnumerable<Ticket> GetHistory(Account account);

        /// <summary>
        /// Get latest tickets.
        /// </summary>
        /// <param name="account">The account for which to get the tickets</param>
        /// <param name="limit">The max number of thickets to fetch</param>
        /// <returns></returns>
        IEnumerable<Ticket> GetHistory(Account account, int limit);

        /// <summary>
        /// Get older tickets.
        /// </summary>
        /// <param name="account">The account for which to get the tickets</param>
        /// <param name="before">The date before which to get the tickets</param>
        /// <param name="limit">The max number of thickets to fetch</param>
        /// <returns></returns>
        IEnumerable<Ticket> GetHistory(Account account, DateTime before, int limit);

        /// <summary>
        /// Get the tickets that have been added after a given date (used to refresh the list with new values).
        /// </summary>
        /// <param name="account">The account for which to get the tickets</param>
        /// <param name="after">The date of the last ticket the client has</param>
        /// <returns></returns>
        IEnumerable<Ticket> GetNewTickets(Account account, DateTime after);


        /// <summary>
        /// Validates a ticket
        /// </summary>
        /// <param name="ticket">Ticket to validate</param>
        /// <param name="bus">Current checked in bus</param>
        /// <returns>0 - ticket expired, 1 - valid ticket, 2 - ticket not for current bus</returns>
        int ValidateTicket(Ticket ticket, Bus bus);
    }
}