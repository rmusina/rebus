using System;
using System.Collections.Generic;
using ReBus.Model;
using ReBus.Services;
using ReBus.Services.API;
using ReBus.WebServices.WebServiceModel;
using System.Linq;

namespace ReBus.WebServices
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "TicketWebService" in code, svc and config file together.
    public class TicketWebService : ITicketWebService
    {
        readonly ITicketService ticketService = new TicketService();

        /// <summary>
        /// Buy a new ticket.
        /// </summary>
        /// <param name="account">The account for which to buy the ticket</param>
        /// <param name="bus">The bus for which to buy the ticket</param>
        /// <returns></returns>
        public TicketWebServiceModel BuyTicket(AccountWebServiceModel account, BusWebServiceModel bus)
        {
            var dmAccount = new Account() {GUID = account.GUID};
            var dmBus = new Bus() {GUID = bus.GUID};
            return TicketWebServiceModel.FromDataModel(ticketService.BuyTicket(dmAccount, dmBus), account);
        }

        /// <summary>
        /// Get the currently active ticket of an account.
        /// </summary>
        /// <param name="account">The account for which to get the active ticket</param>
        /// <returns></returns>
        public TicketWebServiceModel GetActiveTicket(AccountWebServiceModel account)
        {
            var dmAccount = new Account() {GUID = account.GUID};
            return TicketWebServiceModel.FromDataModel(ticketService.GetActiveTicket(dmAccount), account);
        }

        /// <summary>
        /// Get all the tickets associated to an account.
        /// </summary>
        /// <param name="account">The account for which to get the tickets</param>
        /// <returns></returns>
        public IEnumerable<TicketWebServiceModel> GetHistory(AccountWebServiceModel account)
        {
            var dmAccount = new Account() { GUID = account.GUID };
            return ticketService.GetHistory(dmAccount)
                .Select(t => TicketWebServiceModel.FromDataModel(t, account))
                .ToList();
        }

        /// <summary>
        /// Get latest tickets.
        /// </summary>
        /// <param name="account">The account for which to get the tickets</param>
        /// <param name="limit">The max number of thickets to fetch</param>
        /// <returns></returns>
        public IEnumerable<TicketWebServiceModel> GetHistoryWithLimit(AccountWebServiceModel account, int limit)
        {
            var dmAccount = new Account() { GUID = account.GUID };
            return ticketService.GetHistory(dmAccount, limit)
                .Select(t => TicketWebServiceModel.FromDataModel(t, account))
                .ToList();
        }

        /// <summary>
        /// Get older tickets.
        /// </summary>
        /// <param name="account">The account for which to get the tickets</param>
        /// <param name="before">The date before which to get the tickets</param>
        /// <param name="limit">The max number of thickets to fetch</param>
        /// <returns></returns>
        public IEnumerable<TicketWebServiceModel> GetNextHistoryWithLimit(AccountWebServiceModel account, DateTime before, int limit)
        {
            var dmAccount = new Account() { GUID = account.GUID };
            return ticketService.GetHistory(dmAccount, before, limit)
                .Select(t => TicketWebServiceModel.FromDataModel(t, account))
                .ToList();
        }

        /// <summary>
        /// Get the tickets that have been added after a given date (used to refresh the list with new values).
        /// </summary>
        /// <param name="account">The account for which to get the tickets</param>
        /// <param name="after">The date of the last ticket the client has</param>
        /// <returns></returns>
        public IEnumerable<TicketWebServiceModel> GetNewTickets(AccountWebServiceModel account, DateTime after)
        {
            var dmAccount = new Account() { GUID = account.GUID };
            return ticketService.GetNewTickets(dmAccount, after)
                .Select(t => TicketWebServiceModel.FromDataModel(t, account))
                .ToList();
        }
    }
}
