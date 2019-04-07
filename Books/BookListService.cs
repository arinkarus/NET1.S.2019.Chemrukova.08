﻿using Books.Exception;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Books
{
    /// <summary>
    /// Provides methods to work with books.
    /// </summary>
    public class BookListService : IBookListService
    {
        /// <summary>
        /// Book list storage.
        /// </summary>
        private readonly IBookListStorage bookListStorage;

        /// <summary>
        /// List that contains books.
        /// </summary>
        private List<Book> books = new List<Book>();

        /// <summary>
        /// Initializes a new instance of the <see cref="BookListService"/> class.
        /// </summary>
        /// <param name="storage">Storage for books.</param>
        public BookListService(IBookListStorage storage)
        {
            BookValidator.CheckOnNull(storage);
            this.bookListStorage = storage;
        }

        /// <summary>
        /// Adds book to list.
        /// </summary>
        /// <param name="book">Book to add.</param>
        /// <exception cref="DuplicateItemException">Thrown when there is a try to add already existing book.</exception>
        /// <exception cref="ArgumentNullException">Thrown when book is null.</exception>
        public void Add(Book book)
        {
            BookValidator.CheckOnNull(book);
            if (this.books.Contains(book))
            {
                throw new DuplicateItemException($"{nameof(book)} is already in list.");
            }

            books.Add(book);
        }

        /// <summary>
        /// Removes book from list.
        /// </summary>
        /// <param name="book">Book to add.</param>
        /// <exception cref="ItemIsNotFoundException">When book to remove doesn't exist.</exception>
        /// <exception cref="ArgumentNullException">Thrown when book is null.</exception>
        public void Remove(Book book)
        {
            BookValidator.CheckOnNull(book);
            if (!this.books.Contains(book))
            {
                throw new ItemIsNotFoundException($"{nameof(book)} isn't found in list.");
            }

            books.Remove(book);
        }

        /// <summary>
        /// Sorts books by condition that is provided by comparer.
        /// </summary>
        /// <param name="comparer">Comparer that will be used for sorting.</param>
        public void SortBy(IComparer<Book> comparer)
        {
            BookValidator.CheckOnNull(comparer);
            books.Sort(comparer);
        }

        /// <summary>
        /// Returns all books in list.
        /// </summary>
        /// <returns>All books.</returns>
        public IEnumerable<Book> GetAll()
        {
            return this.books;
        }

        /// <summary>
        /// Finds books that satisfy some criteria.
        /// </summary>
        /// <param name="searchCriteria">Search criteria.</param>
        /// <returns>Found books.</returns>
        public IEnumerable<Book> FindByTag(ISearchCriteria searchCriteria)
        {
            BookValidator.CheckOnNull(searchCriteria);
            return GetMatchedBooks(searchCriteria);
        }

        /// <summary>
        /// Saves books to storage.
        /// </summary>
        public void Save()
        {
            this.bookListStorage.Save(this.books);              
        }

        /// <summary>
        /// Loa
        /// </summary>
        /// <returns></returns>
        public void Load()
        {
            IEnumerable<Book> books = this.bookListStorage.Load();
            this.books = books.ToList();
        }

        private IEnumerable<Book> GetMatchedBooks(ISearchCriteria searchCriteria)
        {
            foreach (var book in this.books)
            {
                if (searchCriteria.IsMatch(book))
                {
                    yield return book;
                }
            }
        }          
    }
}
