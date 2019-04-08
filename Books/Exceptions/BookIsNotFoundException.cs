using System;
using System.Runtime.Serialization;

namespace Books.Exceptions
{
    public class BookIsNotFoundException : ArgumentException
    {
        public BookIsNotFoundException(string message) : base(message)
        { }

        public BookIsNotFoundException()
        { }

        public BookIsNotFoundException(string message, System.Exception inner) : base(message, inner) { }

        protected BookIsNotFoundException(SerializationInfo info, StreamingContext context) : 
            base(info, context) { }
    }
}
