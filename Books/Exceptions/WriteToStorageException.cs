using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Books.Exceptions
{
    public class WriteToStorageException : Exception
    {
        public WriteToStorageException(string message) : base(message)
        { }

        public WriteToStorageException()
        { }

        public WriteToStorageException(string message, System.Exception inner) : base(message, inner) { }

        protected WriteToStorageException(SerializationInfo info, StreamingContext context) :
            base(info, context)
        { }
    }
}
