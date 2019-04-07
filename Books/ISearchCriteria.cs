using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Books
{
    /// <summary>
    /// Interface that determines method for some search criteria.
    /// </summary>
    public interface ISearchCriteria
    {
        /// <summary>
        /// Method to check if book matches criteria.
        /// </summary>
        /// <param name="bookToCheck">Book to check.</param>
        /// <returns>True if book to check satisfies criteria.</returns>
        bool IsMatch(Book bookToCheck);
    }
}
