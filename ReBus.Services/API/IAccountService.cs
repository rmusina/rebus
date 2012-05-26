using ReBus.Model;
using System.Collections.Generic;
namespace ReBus.Services.API
{
    public interface IAccountService
    {
        /// <summary>
        /// Authenticates user 
        /// </summary>
        /// <param name="username">username</param>
        /// <param name="password">password</param>
        /// <returns>corresponding Account instance or null if inexistent user</returns>
        Account Authenticate(string userName, string password);

        /// <summary>
        /// Authenticates TicketController 
        /// </summary>
        /// <param name="username">username</param>
        /// <param name="password">password</param>
        /// <returns>corresponding Account instance or null if inexistent user</returns>
        Account AuthenticateTicketController(string userName, string password);

        /// <summary>
        /// Registers new user
        /// </summary>
        /// <param name="userName">userName</param>
        /// <param name="password">password</param>
        /// <param name="firstName">firstName</param>
        /// <param name="lastName">lastName</param>
        /// <returns>new account instance</returns>
        Account Register(string userName, string password, string firstName, string lastName);

        /// <summary>
        /// Gets all transaction history corresponding to a user
        /// </summary>
        /// <param name="userAccount">user for whom transaction history is required</param>
        /// <returns>list of transaction objects</returns>
        IEnumerable<Transaction> GetTransactionHistory(Account userAccount); 
    }
}