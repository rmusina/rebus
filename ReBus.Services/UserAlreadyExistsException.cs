using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace ReBus.Services
{
    public class UserAlreadyExistsException : Exception
    {
        public UserAlreadyExistsException()
            : this("Numele utilizatorului nu este unic.")
        {
        }

        public UserAlreadyExistsException(string message) : base(message)
        {
        }

        public UserAlreadyExistsException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected UserAlreadyExistsException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }
    }
}
