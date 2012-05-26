using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using ReBus.Services;
using ReBus.Services.API;
using ReBus.Model;

namespace ReBus.WebServices
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "AuthenticationWebService" in code, svc and config file together.
    public class AuthenticationWebService : IAuthenticationWebService
    {
        IAccountService accountService = new AccountService();

        public AccountWebServiceModel Authenticate(string username, string password)
        {
            Account account = accountService.Authenticate(username, password);

            if (account == null)
            {
                return null;
            }

            return AccountWebServiceModel.FromModelObject(account);
        }
    }
}
