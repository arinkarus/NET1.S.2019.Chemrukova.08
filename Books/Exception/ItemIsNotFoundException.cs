using System;

namespace Books.Exception
{
    public class ItemIsNotFoundException : ArgumentException
    {
        public ItemIsNotFoundException(string message) : base(message)
        { }

        public ItemIsNotFoundException()
        { }
    }
}
