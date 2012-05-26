using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ReBus.Model;
using System.Runtime.Serialization;

namespace ReBus.Services
{
    [DataContract]
    public class AccountWebServiceModel
    {
        [DataMember]
        public Guid GUID
        {
            get;
            set;
        }

        [DataMember]
        public string UserName 
        { 
            get; 
            set; 
        }

        [DataMember]
        public string FirstName
        {
            get;
            set;
        }

        [DataMember]
        public string LastName
        {
            get;
            set;
        }

        [DataMember]
        public decimal Credit
        {
            get;
            set;
        }

        internal static AccountWebServiceModel FromModelObject(Account account)
        {
            return new AccountWebServiceModel() 
                   { 
                        GUID = account.GUID,
                        FirstName = account.FirstName,
                        LastName = account.LastName,
                        UserName = account.Username,
                        Credit = account.Credit
                   };
        }
    }
}
