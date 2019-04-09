using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Books.Tests.Search
{
    public class SearchByNameCriteria : ISearchCriteria<Book>
    {
        /// <summary>
        /// String for searching in book's title.
        /// </summary>
        private readonly string searchSubstring;

        /// Initializes a new instance of the <see cref="SearchByNameCriteria"/> class.
        public SearchByNameCriteria(string searchSubstring)
        {
            BookValidator.CheckString(searchSubstring);
            this.searchSubstring = searchSubstring;
        }

        /// <summary>
        /// Tells if title contain substring.
        /// </summary>
        /// <param name="bookToCheck">Book to check.</param>
        /// <returns>True if if title contain substring, otherwise - null.</returns>
        /// <exception cref="ArgumentException">Thrown if book to check is null.</exception>
        public bool IsMatch(Book bookToCheck)
        {
            BookValidator.CheckOnNull(bookToCheck);
            if (bookToCheck.Name.ToLower().Contains(this.searchSubstring.ToLower()))
            {
                return true;
            }

            return false;
        }
    }
}
