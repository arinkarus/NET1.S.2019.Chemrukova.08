using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Books
{
    /// <summary>
    /// Determines which methods book storage has to have.
    /// </summary>
    public interface IBookListStorage
    {
        /// <summary>
        /// Loads books.
        /// </summary>
        /// <returns>Loaded books.</returns>
        IEnumerable<Book> Load();

        /// <summary>
        /// Saves books.
        /// </summary>
        /// <param name="books">Given books.</param>
        void Save(IEnumerable<Book> books);
    }
}
