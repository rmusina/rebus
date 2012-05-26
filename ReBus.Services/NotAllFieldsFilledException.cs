using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace ReBus.Services
{
    public class NotAllFieldsFilledException : Exception
    {
        public NotAllFieldsFilledException()
            : this("Completati toate campurile.")
        {
        }

        public NotAllFieldsFilledException(string message) : base(message)
        {
        }

        public NotAllFieldsFilledException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected NotAllFieldsFilledException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }
    }
}
