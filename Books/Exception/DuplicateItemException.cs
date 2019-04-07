using System;

namespace Books.Exception
{
    public class DuplicateItemException : ArgumentException
    {
        public DuplicateItemException(string message): base(message)
        { }

        public DuplicateItemException()
        { }
    }
}
