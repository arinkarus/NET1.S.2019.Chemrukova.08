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
        /// Updates book.
        /// </summary>
        /// <param name="book">Book to update.</param>
        void Update(Book book);

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
        IEnumerable<Book> SortBy(IComparer<Book> comparer);

        /// <summary>
        /// Finds books.
        /// </summary>
        /// <param name="searchCriteria">Search criteria.</param>
        /// <returns>Found books.</returns>
        IEnumerable<Book> FindByTag(ISearchCriteria<Book> searchCriteria);

        /// <summary>
        /// Returns all books.
        /// </summary>
        /// <returns>All books.</returns>
        IEnumerable<Book> GetAll();

        /// <summary>
        /// Finds book by tag.
        /// </summary>
        /// <param name="searchCriteria"></param>
        /// <returns>Book.</returns>
        Book FindBookByTag(ISearchCriteria<Book> searchCriteria);

        /// <summary>
        /// Loads data from storage to temporary set of books.
        /// </summary>
        void Load();

        /// <summary>
        /// Saves data from temporary set of books to storage.
        /// </summary>
        void Save();
    }
}
