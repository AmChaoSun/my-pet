using System;
using System.Runtime.Serialization;

namespace MyPet.Utils
{
    public class CustomDbConflictException : Exception
    {
        public CustomDbConflictException()
        {
        }

        public CustomDbConflictException(string message) : base(message)
        {
        }

        public CustomDbConflictException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected CustomDbConflictException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
