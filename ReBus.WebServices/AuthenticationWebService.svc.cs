using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using ReBus.Services;
using ReBus.Services.API;
using ReBus.Model;
using ReBus.WebServices.WebServiceModel;

namespace ReBus.WebServices
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "AuthenticationWebService" in code, svc and config file together.
    public class AuthenticationWebService : IAuthenticationWebService
    {
        readonly IAccountService accountService = new AccountService();

        private AccountWebServiceModel AuthenticateUser(string username, string password, bool isTicketController)
        {
            Account account = isTicketController ? 
                accountService.AuthenticateTicketController(username, password) :
                accountService.Authenticate(username, password);

            if (account == null)
            {
                return null;
            }

            return AccountWebServiceModel.FromModelObject(account);
        }

        public AccountWebServiceModel Authenticate(string username, string password)
        {
            return AuthenticateUser(username, password, false);
        }

        public AccountWebServiceModel GetAccount(Guid guid)
        {
            return AccountWebServiceModel.FromModelObject(accountService.GetAccount(guid));
        }

        public AccountWebServiceModel AuthenticateTicketController(string username, string password)
        {
            return AuthenticateUser(username, password, true);
        }

        public AccountWebServiceModel AddFunds(AccountWebServiceModel account, decimal amount)
        {
            return AccountWebServiceModel.FromModelObject(accountService.AddFunds(new Account {GUID = account.GUID}, amount));
        }

        public string Register(string userName, string password, string firstName, string lastName)
        {
            try
            {
                Account account = accountService.Register(userName, password, firstName, lastName);
            }
            catch (Exception fieldsExc)
            {
                return fieldsExc.Message;
            }

            return String.Empty;
        }

        public IEnumerable<TransactionWebServiceModel> GetTransactionHistory(AccountWebServiceModel userAccount)
        {
            IEnumerable<Transaction> transactions = accountService.GetTransactionHistory(new Account() 
                                                                                         { 
                                                                                             Username = userAccount.UserName,
                                                                                             GUID = userAccount.GUID,
                                                                                             Credit = userAccount.Credit,
                                                                                             LastName = userAccount.LastName,
                                                                                             FirstName = userAccount.FirstName
                                                                                         });

            if (transactions == null || transactions.Count<Transaction>() == 0)
            {
                return new List<TransactionWebServiceModel>();
            }

            return transactions.Select<Transaction, TransactionWebServiceModel>
                    (currentTransaction => TransactionWebServiceModel.FromModelObject(currentTransaction));
        }
    }
}
