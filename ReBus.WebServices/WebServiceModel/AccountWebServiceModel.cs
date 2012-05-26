using System;
using ReBus.Model;
using System.Runtime.Serialization;

namespace ReBus.WebServices.WebServiceModel
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
            if (account == null)
                return null;

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
