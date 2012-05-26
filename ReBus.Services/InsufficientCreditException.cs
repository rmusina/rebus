using System;
using System.Runtime.Serialization;

namespace ReBus.Services
{
    public class InsufficientCreditException : Exception
    {
        public InsufficientCreditException() : this("You have insufficient funds to perform the operation.")
        {
        }

        public InsufficientCreditException(string message) : base(message)
        {
        }

        public InsufficientCreditException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected InsufficientCreditException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}