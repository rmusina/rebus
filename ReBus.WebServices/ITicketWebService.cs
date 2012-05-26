using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace ReBus.WebServices
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "ITicketWebService" in both code and config file together.
    [ServiceContract]
    public interface ITicketWebService
    {
        [OperationContract]
        void DoWork();
    }
}
