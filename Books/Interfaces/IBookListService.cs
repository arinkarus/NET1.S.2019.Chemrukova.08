using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Books
{
    /// <summary>
    /// Determines methods for book services.
    /// </summary>
    public interface IBookListService
    {
        /// <summary>
        /// Adds book.
        /// </summary>
        /// <param name="book">Given book.</param>
        void Add(Book book);

        /// <summary>
        /// Removes book.
        /// </summary>
        /// <param name="book">Book to remove.</param>
        void Remove(Book book);

        /// <summary>
        /// Sorts books.
        /// </summary>
        /// <param name="comparer">Given comparer.</param>
        void SortBy(IComparer<Book> comparer);

        /// <summary>
        /// Finds books.
        /// </summary>
        /// <param name="searchCriteria">Search criteria.</param>
        /// <returns>Found books.</returns>
        IEnumerable<Book> FindByTag(ISearchCriteria<Book> searchCriteria);

        int GetFirstMatchIndex(ISearchCriteria<Book> searchCriteria);

        /// <summary>
        /// Returns all books.
        /// </summary>
        /// <returns>All books.</returns>
        IEnumerable<Book> GetAll();

        IEnumerable<Book> Load();

        void Save();
    }
}
