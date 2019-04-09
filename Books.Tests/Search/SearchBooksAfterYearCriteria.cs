using System;

namespace Books.Tests.Search
{
    /// <summary>
    /// Search books that are greter that given year.
    /// </summary>
    public class SearchBooksAfterYearCriteria : ISearchCriteria<Book>
    {
        /// <summary>
        /// Year to compare with.
        /// </summary>
        private readonly int year;

        /// Initializes a new instance of the <see cref="SearchBooksAfterYearCriteria"/> class.
        public SearchBooksAfterYearCriteria(int year)
        {
            BookValidator.CheckYear(year);
            this.year = year;
        }

        /// <summary>
        /// Tells if book is newer.
        /// </summary>
        /// <param name="bookToCheck">Book to check.</param>
        /// <returns>True if book is published later than in given year.</returns>
        /// <exception cref="ArgumentException">Thrown if book to check is null.</exception>
        public bool IsMatch(Book bookToCheck)
        {
            BookValidator.CheckOnNull(bookToCheck);
            if (bookToCheck.PublicationYear > this.year)
            {
                return true;
            }

            return false;
        }
    }
}
