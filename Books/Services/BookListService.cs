﻿using Books.Exceptions;
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
        /// Hashset that contains books.
        /// </summary>
        private HashSet<Book> books = new HashSet<Book>();

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
        /// Adds book to books.
        /// </summary>
        /// <param name="book">Book to add.</param>
        /// <exception cref="DuplicateItemException">Thrown when there is a try to add already existing book.</exception>
        /// <exception cref="ArgumentNullException">Thrown when book is null.</exception>
        public void Add(Book book)
        {
            BookValidator.CheckOnNull(book);
            if (this.books.Contains(book))
            {
                throw new DuplicateBookException($"{nameof(book)} is already in list.");
            }

            books.Add(book);
        }

        /// <summary>
        /// Removes book from books.
        /// </summary>
        /// <param name="book">Book to add.</param>
        /// <exception cref="ItemIsNotFoundException">When book to remove doesn't exist.</exception>
        /// <exception cref="ArgumentNullException">Thrown when book is null.</exception>
        public void Remove(Book book)
        {
            BookValidator.CheckOnNull(book);
            if (!this.books.Contains(book))
            {
                throw new BookIsNotFoundException($"{nameof(book)} isn't found in list.");
            }

            books.Remove(book);
        }

        /// <summary>
        /// Updates book.
        /// </summary>
        /// <param name="book"></param>
        public void Update(Book book)
        {
            BookValidator.CheckOnNull(book);
            if (!this.books.Contains(book))
            {
                throw new BookIsNotFoundException($"{nameof(book)} isn't found in list.");
            }

            this.books.Remove(book);
            this.books.Add(book);             
        }

        /// <summary>
        /// Sorts books by condition that is provided by comparer.
        /// </summary>
        /// <param name="comparer">Comparer that will be used for sorting.</param>
        public IEnumerable<Book> SortBy(IComparer<Book> comparer)
        {
            BookValidator.CheckOnNull(comparer);
            var booksToSort = books.ToList();
            booksToSort.Sort(comparer);
            return booksToSort;
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
        public IEnumerable<Book> FindByTag(ISearchCriteria<Book> searchCriteria)
        {
            BookValidator.CheckOnNull(searchCriteria);
            return GetMatchedBooks(searchCriteria);
        }
        
        /// <summary>
        /// Saves books to storage.
        /// </summary>
        public void Save() => this.bookListStorage.Save(this.books);

        private IEnumerable<Book> GetMatchedBooks(ISearchCriteria<Book> searchCriteria)
        {
            foreach (var book in this.books)
            {
                if (searchCriteria.IsMatch(book))
                {
                    yield return book;
                }
            }
        }

        /// <summary>
        /// Loads books from storage.
        /// </summary>
        /// <returns></returns>
        public void Load()
        {
            this.books = this.bookListStorage.Load().ToHashSet<Book>();
        }

        /// <summary>
        /// Finds book by criteria.
        /// </summary>
        /// <param name="searchCriteria">Given criteria.</param>
        /// <returns>Found book.</returns>
        public Book FindBookByTag(ISearchCriteria<Book> searchCriteria)
        {
            foreach (var book in this.books)
            {
                if (searchCriteria.IsMatch(book))
                {
                    return book;
                } 
            }

            return null;
        }
    }
}
