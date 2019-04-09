using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Books.Tests.Sort
{
    /// <summary>
    /// Comparer for ordering books by pages count in ascending order.
    /// </summary>
    public class BooksPagesComparer : IComparer<Book>
    {
        /// <summary>
        /// Compares two books depending on their pages count.
        /// </summary>
        /// <param name="firstBook">First book.</param>
        /// <param name="secondBook">Second book.</param>
        /// <returns>Returns 1 if amount of pages of first book is greater than the amount of pages of second.
        /// Returns 0 if amount of pages are equal.
        /// Otherwise - returns - 1.
        /// </returns>
        /// <exception cref="ArgumentNullException">Thrown when book in null.</exception>
        public int Compare(Book firstBook, Book secondBook)
        {
            BookValidator.CheckOnNull(firstBook);
            BookValidator.CheckOnNull(secondBook);
            return firstBook.AmountOfPages - secondBook.AmountOfPages;
        }
    }
}
