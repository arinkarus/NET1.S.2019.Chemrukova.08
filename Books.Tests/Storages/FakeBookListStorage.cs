using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Books.Tests.Storages
{
    /// <summary>
    /// Fake book list.
    /// </summary>
    public class FakeBookListStorage : IBookListStorage
    {
        private List<Book> storedBooks;

        public IEnumerable<Book> Load()
        {
            return storedBooks;
        }

        public void Save(IEnumerable<Book> books)
        {
            storedBooks = books.ToList();
        }
    }
}
