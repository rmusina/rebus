using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using ReBus.Services;
using ReBus.WebServices.WebServiceModel;

namespace ReBus.WebServices
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IAuthenticationWebService" in both code and config file together.
    [ServiceContract]
    public interface IAuthenticationWebService
    {
        [OperationContract]
        AccountWebServiceModel Authenticate(string username, string password);

        [OperationContract]
        AccountWebServiceModel GetAccount(Guid guid);

        [OperationContract]
        AccountWebServiceModel AuthenticateTicketController(string username, string password);

        [OperationContract]
        AccountWebServiceModel AddFunds(AccountWebServiceModel account, decimal amount);

        [OperationContract]
        string Register(string userName, string password, string firstName, string lastName);

        [OperationContract]
        IEnumerable<TransactionWebServiceModel> GetTransactionHistory(AccountWebServiceModel userAccount);
    }
}
