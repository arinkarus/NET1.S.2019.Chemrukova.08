using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Books.Tests.Sort
{
    /// <summary>
    /// Class provides method for comparing two books in order to get the newest (by year).
    /// </summary>
    public class BooksByYearComparer : IComparer<Book>
    {
        /// <summary>
        /// Method that returns the result of comparison of years.
        /// </summary>
        /// <param name="firstBook">First book.</param>
        /// <param name="secondBook">Second book.</param>
        /// <returns>Returns 0 of publication years are the same.
        /// Returns 1 if first book was published earlier than second. Otherwise it returns -1.</returns>
        public int Compare(Book firstBook, Book secondBook)
        {
            BookValidator.CheckOnNull(firstBook);
            BookValidator.CheckOnNull(secondBook);
            return secondBook.AmountOfPages - firstBook.AmountOfPages;
        }
    }
}
