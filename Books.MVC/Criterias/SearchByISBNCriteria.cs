using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Books.MVC.Criterias
{
    public class SearchByISBNCriteria : ISearchCriteria<Book>
    {
        private string isbn;

        public SearchByISBNCriteria(string isbn)
        {
            BookValidator.ValidateISBN(isbn);
            this.isbn = isbn;
        }

        public bool IsMatch(Book bookToCheck)
        {
            BookValidator.CheckOnNull(bookToCheck);
            return bookToCheck.Isbn == this.isbn;
        }
    }
}