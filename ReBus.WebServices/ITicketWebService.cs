using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using ReBus.WebServices.WebServiceModel;

namespace ReBus.WebServices
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "ITicketWebService" in both code and config file together.
    [ServiceContract]
    public interface ITicketWebService
    {
        /// <summary>
        /// Buy a new ticket.
        /// </summary>
        /// <param name="account">The account for which to buy the ticket</param>
        /// <param name="bus">The bus for which to buy the ticket</param>
        /// <returns></returns>
        [OperationContract]
        TicketWebServiceModel BuyTicket(AccountWebServiceModel account, BusWebServiceModel bus);

        /// <summary>
        /// Get the currently active ticket of an account.
        /// </summary>
        /// <param name="account">The account for which to get the active ticket</param>
        /// <returns></returns>
        [OperationContract]
        TicketWebServiceModel GetActiveTicket(AccountWebServiceModel account);

        /// <summary>
        /// Get all the tickets associated to an account.
        /// </summary>
        /// <param name="account">The account for which to get the tickets</param>
        /// <returns></returns>
        [OperationContract]
        IEnumerable<TicketWebServiceModel> GetHistory(AccountWebServiceModel account);

        /// <summary>
        /// Get latest tickets.
        /// </summary>
        /// <param name="account">The account for which to get the tickets</param>
        /// <param name="limit">The max number of thickets to fetch</param>
        /// <returns></returns>
        [OperationContract]
        IEnumerable<TicketWebServiceModel> GetHistoryWithLimit(AccountWebServiceModel account, int limit);

        /// <summary>
        /// Get older tickets.
        /// </summary>
        /// <param name="account">The account for which to get the tickets</param>
        /// <param name="before">The date before which to get the tickets</param>
        /// <param name="limit">The max number of thickets to fetch</param>
        /// <returns></returns>
        [OperationContract]
        IEnumerable<TicketWebServiceModel> GetNextHistoryWithLimit(AccountWebServiceModel account, DateTime before, int limit);

        /// <summary>
        /// Get the tickets that have been added after a given date (used to refresh the list with new values).
        /// </summary>
        /// <param name="account">The account for which to get the tickets</param>
        /// <param name="after">The date of the last ticket the client has</param>
        /// <returns></returns>
        [OperationContract]
        IEnumerable<TicketWebServiceModel> GetNewTickets(AccountWebServiceModel account, DateTime after);
    }
}
