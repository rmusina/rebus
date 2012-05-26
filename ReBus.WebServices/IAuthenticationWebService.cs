using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using ReBus.Services;

namespace ReBus.WebServices
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IAuthenticationWebService" in both code and config file together.
    [ServiceContract]
    public interface IAuthenticationWebService
    {
        [OperationContract]
        AccountWebServiceModel Authenticate(string username, string password);
    }
}
