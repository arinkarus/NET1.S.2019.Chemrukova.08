using NUnit.Framework;
using System;
using Books.Tests.Sort;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Books.Tests.Storages;
using Books.Tests.Search;
using Books.Exceptions;

namespace Books.Tests
{
    public class BookListServiceTests
    {
        [TestCase]
        public void SortBy_BooksPagesComparerAsc_SortBooks()
        {
            var expected = new List<Book>()
            {
               new Book("987-123456789-4", "Name", "Author", 2010, "House", 100, 100),
               new Book("987-123456771-4", "English dictionary", "Englishmen", 2010, "House", 200, 100),
               new Book("987-123456779-4", "Some book", "Ivanov", 2010, "House", 1050, 100)
            };
            var bookListService = new BookListService(new FakeBookListStorage());
            bookListService.Add(new Book("987-123456789-4", "Name", "Author", 2010, "House", 100, 100));
            bookListService.Add(new Book("987-123456779-4", "Some book", "Ivanov", 2010, "House", 1050, 100));
            bookListService.Add(new Book("987-123456771-4", "English dictionary", "Englishmen", 2010, "House", 200, 100));
            bookListService.SortBy(new BooksPagesComparer());
            IEnumerable<Book> books = bookListService.GetAll();
            CollectionAssert.AreEqual(expected, books);
        }

        [Test]
        public void SortBy_BooksByYearComparer_SortBooks()
        {
            var expected = new List<Book>()
            {
               new Book("987-123456789-4", "Name", "Author", 2015, "House", 100, 100),
               new Book("987-123456771-4", "English dictionary", "Englishmen", 1999, "House", 200, 100),
               new Book("987-123456779-4", "Some book", "Ivanov", 1985, "House", 1050, 100),
            };
            var bookListService = new BookListService(new FakeBookListStorage());
            bookListService.Add(new Book("987-123456789-4", "Name", "Author", 2015, "House", 100, 100));
            bookListService.Add(new Book("987-123456779-4", "Some book", "Ivanov", 1985, "House", 1050, 100));
            bookListService.Add(new Book("987-123456771-4", "English dictionary", "Englishmen", 1999, "House", 200, 100));
            bookListService.SortBy(new BooksPagesComparer());
            IEnumerable<Book> books = bookListService.GetAll();
            CollectionAssert.AreEqual(expected, books);
        }

        [Test]
        public void SortBy_ComparerIsNull_ThrowArgumentNullException()
        {
            var bookListService = new BookListService(new FakeBookListStorage());
            bookListService.Add(new Book("987-123456789-4", "Name", "Author", 2010, "House", 100, 100));
            bookListService.Add(new Book("987-123456779-4", "Some book", "Ivanov", 2010, "House", 1050, 100));
            Assert.Throws<ArgumentNullException>(() => bookListService.SortBy(null));
        }

        [Test]
        public void SortBy_SearchCriteriaIsNull_ThrowArgumentNullException()
        {
            var bookListService = new BookListService(new FakeBookListStorage());
            bookListService.Add(new Book("987-123456789-4", "Name", "Author", 2010, "House", 100, 100));
            bookListService.Add(new Book("987-123456779-4", "Some book", "Ivanov", 2010, "House", 1050, 100));
            Assert.Throws<ArgumentNullException>(() => bookListService.FindByTag(null));
        }

        [Test]
        public void FindByTag_SearchByNameCriteria_ReturnBooks()
        {
            var expected = new List<Book>()
            {
               new Book("987-123456771-4", "English dictionary", "Englishmen", 1999, "House", 200, 100),
               new Book("987-123456777-4", "Russian Dictionary", "Petrov", 2000, "House", 155, 101)
            };

            var bookListService = new BookListService(new FakeBookListStorage());
            bookListService.Add(new Book("987-123456789-4", "Name", "Author", 2015, "House", 100, 100));
            bookListService.Add(new Book("987-123456779-4", "Some book", "Ivanov", 1985, "House", 1050, 100));
            bookListService.Add(new Book("987-123456771-4", "English dictionary", "Englishmen", 1999, "House", 200, 100));
            bookListService.Add(new Book("987-123456777-4", "Russian Dictionary", "Petrov", 2000, "House", 155, 101));
            IEnumerable<Book> foundBooks = bookListService.FindByTag(new SearchByNameCriteria("dictionary"));
            CollectionAssert.AreEqual(expected, foundBooks);
        }

        [Test]
        public void FindByTag_SearchBooksAfterYearCriteria()
        {
            var expected = new List<Book>()
            {
               new Book("987-123456789-4", "Name", "Author", 2015, "House", 100, 100),
               new Book("987-123456777-4", "Russian Dictionary", "Petrov", 2000, "House", 155, 101)
            };

            var bookListService = new BookListService(new FakeBookListStorage());
            bookListService.Add(new Book("987-123456789-4", "Name", "Author", 2015, "House", 100, 100));
            bookListService.Add(new Book("987-123456779-4", "Some book", "Ivanov", 1985, "House", 1050, 100));
            bookListService.Add(new Book("987-123456771-4", "English dictionary", "Englishmen", 1999, "House", 200, 100));
            bookListService.Add(new Book("987-123456777-4", "Russian Dictionary", "Petrov", 2000, "House", 155, 101));
            IEnumerable<Book> foundBooks = bookListService.FindByTag(new SearchBooksAfterYearCriteria(1999));
            CollectionAssert.AreEqual(expected, foundBooks);
        }

        [Test]
        public void Remove_BookIsNotInList_ThrowItemIsNotFoundException()
        {
            var bookThatIsNotInBookList = new Book("987-123456779-4", "NOT EXISTING IN LIST", "XXX", 2012, "XXX", 10, 20);
            var bookListService = new BookListService(new FakeBookListStorage());
            bookListService.Add(new Book("987-123456789-4", "Name", "Author", 2015, "House", 100, 100));
            bookListService.Add(new Book("987-123456779-4", "Some book", "Ivanov", 1985, "House", 1050, 100));
            bookListService.Add(new Book("987-123456771-4", "English dictionary", "Englishmen", 1999, "House", 200, 100));
            bookListService.Add(new Book("987-123456777-4", "Russian Dictionary", "Petrov", 2000, "House", 155, 101));
            Assert.Throws<BookIsNotFoundException>(() => bookListService.Remove(bookThatIsNotInBookList));
        }

        [Test]
        public void Remove_BookIsInList_RemoveBook()
        {
            var bookToDelete = new Book("987-123456777-4", "Russian Dictionary", "Petrov", 2000, "House", 155, 101);
            var bookListService = new BookListService(new FakeBookListStorage());
            bookListService.Add(new Book("987-123456779-4", "Some book", "Ivanov", 1985, "House", 1050, 100));
            bookListService.Add(new Book("987-123456771-4", "English dictionary", "Englishmen", 1999, "House", 200, 100));
            bookListService.Add(new Book("987-123456777-4", "Russian Dictionary", "Petrov", 2000, "House", 155, 101));
            bookListService.Remove(bookToDelete);
            var expected = new List<Book>()
            {
               new Book("987-123456779-4", "Some book", "Ivanov", 1985, "House", 1050, 100),
               new Book("987-123456771-4", "English dictionary", "Englishmen", 1999, "House", 200, 100)
            };
            CollectionAssert.AreEqual(expected, bookListService.GetAll());
        }

        [Test]
        public void Remove_BookToDeleteIsNull_ThrowArgumentNullException()
        {
            var bookListService = new BookListService(new FakeBookListStorage());
            Assert.Throws<ArgumentNullException>(() => bookListService.Remove(null));
        }

        [Test]
        public void Add_BookToAddIsNull_ThrowArgumentNullException()
        {
            var bookListService = new BookListService(new FakeBookListStorage());
            Assert.Throws<ArgumentNullException>(() => bookListService.Add(null));
        }

        [Test]
        public void Add_BookAlreadyExists_ThrowDuplicateItemException()
        {
            var bookThatIsAlreadyExistsInList = new Book("987-123456779-4", "Some book", "Ivanov", 1985, "House", 1050, 100);
            var bookListService = new BookListService(new FakeBookListStorage());
            bookListService.Add(new Book("987-123456779-4", "Some book", "Ivanov", 1985, "House", 1050, 100));
            Assert.Throws<DuplicateBookException>(() => bookListService.Add(bookThatIsAlreadyExistsInList));
        }

        [Test]
        public void Save_ConcreteBooks_SavedToStorage()
        {
            var bookListService = new BookListService(new FakeBookListStorage());
            bookListService.Add(new Book("987-123456789-4", "Name", "Author", 2015, "House", 100, 100));
            bookListService.Add(new Book("987-123456779-4", "Some book", "Ivanov", 1985, "House", 1050, 100));
            bookListService.Add(new Book("987-123456771-4", "English dictionary", "Englishmen", 1999, "House", 200, 100));
            bookListService.Add(new Book("987-123456777-4", "Russian Dictionary", "Petrov", 2000, "House", 155, 101));
            var beforeSaving = bookListService.GetAll();
            bookListService.Save();
            bookListService.Load();
            var current = bookListService.GetAll();
            CollectionAssert.AreEqual(beforeSaving, current);
        }
    }
}