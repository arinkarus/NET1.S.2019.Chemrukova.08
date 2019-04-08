using System;
using System.Runtime.Serialization;

namespace Books.Exceptions
{
    public class DuplicateBookException : ArgumentException
    {
        public DuplicateBookException(string message): base(message)
        { }

        public DuplicateBookException()
        { }

        public DuplicateBookException(string message, System.Exception inner) : base(message, inner) { }

        protected DuplicateBookException(SerializationInfo info, StreamingContext context) :
            base(info, context)
        { }
    }
}
