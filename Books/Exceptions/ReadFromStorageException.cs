using System;
using System.Runtime.Serialization;

namespace Books.Exceptions
{
    public class ReadFromStorageException : Exception
    { 
        public ReadFromStorageException(string message) : base(message)
        { }

        public ReadFromStorageException()
        { }

        public ReadFromStorageException(string message, System.Exception inner) : base(message, inner) { }

        protected ReadFromStorageException(SerializationInfo info, StreamingContext context) :
            base(info, context)
        { }
    }
}
