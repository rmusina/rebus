using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ReBus.Services
{
    public class AccountWebServiceModel
    {
        public Guid GUID
        {
            get;
            set;
        }

        public string UserName 
        { 
            get; 
            set; 
        }

        public virtual string FirstName
        {
            get;
            set;
        }

        public virtual string LastName
        {
            get;
            set;
        }

        public virtual decimal Credit
        {
            get;
            set;
        }

        public virtual string Username
        {
            get;
            set;
        }
    }
}
