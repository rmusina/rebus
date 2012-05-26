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

        public AccountWebServiceModel Authenticate(string username, string password)
        {
            Account account = accountService.Authenticate(username, password);

            if (account == null)
            {
                return null;
            }

            return AccountWebServiceModel.FromModelObject(account);
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
