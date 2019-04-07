using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace Books.Tests
{
    public class BooksTests
    {
        [Test]
        public void CreateBook_ISBNIsNull_ThrowArgumentNullException() =>
            Assert.Throws<ArgumentNullException>(() => new Book(null, "Name", "Some author", 1999, "House", 100, 100));

        [Test]
        public void CreateBook_ISBNIsEmpty_ThrowArgumentException() =>
            Assert.Throws<ArgumentException>(() => new Book("", "Name", "Some author", 1999, "House", 100, 100));

        [Test]
        public void CreateBook_NotMatchingISBNString_ThrowArgumentException() =>
            Assert.Throws<ArgumentException>(() => new Book("9854545-54", "Name", "Some author", 1999, "House", 100, 100));

        [Test]
        public void CreateBook_NameIsNull_ThrowArgumentNullException() =>
            Assert.Throws<ArgumentNullException>(() => new Book("987-123456789-4", null, "Some author", 1999, "House", 100, 100));

        [Test]
        public void CreateBook_NameContainsOnlySpaces_ThrowArgumentException() =>
            Assert.Throws<ArgumentException>(() => new Book("987-123456789-4", "   ", "Some author", 1999, "House", 100, 100));

        [Test]
        public void CreateBook_AuthorIsNull_ThrowArgumentNullException() =>
          Assert.Throws<ArgumentNullException>(() => new Book("987-123456789-4", "Name", null, 1999, "House", 100, 100));

        [Test]
        public void CreateBook_AuthorIsEmpty_ThrowArgumentException() =>
          Assert.Throws<ArgumentException>(() => new Book("987-123456789-4", "Name", "", 1999, "House", 100, 100));

        [Test]
        public void CreateBook_YearIsNegativeValue_ThrowArgumentException() =>
            Assert.Throws<ArgumentException>(() => new Book("987-123456789-4", "Name", "Author", -1999, "House", 100, 100));

        [Test]
        public void CreateBook_YearIsGreaterThanNow_ThrowArgumentException() =>
            Assert.Throws<ArgumentException>(() => new Book("987-123456789-4", "Name", "Author", 2060, "House", 100, 100));

        [Test]
        public void CreateBook_PublisingHouseIsNull_ThrowArgumentNullException() =>
            Assert.Throws<ArgumentNullException>(() => new Book("987-123456789-4", "Name", "Author", 1999, null, 100, 100));

        [Test]
        public void CreateBook_PublisingHouseIsEmpty_ThrowArgumentException() =>
            Assert.Throws<ArgumentException>(() => new Book("987-123456789-4", "Name", "Author", 1999, "", 100, 100));


        [Test]
        public void CreateBook_AmountOfPagesIsNegative_ThrowArgumentException() =>
            Assert.Throws<ArgumentException>(() => new Book("987-123456789-4", "Name", "Author", 1999, "Publishing house", -100, 100));

        [Test]
        public void CreateBook_PriceIsNegative_ThrowArgumentException() =>
           Assert.Throws<ArgumentException>(() => new Book("987-123456789-4", "Name", "Author", 1999, "Publishing house", 100, -100));

        [Test]
        public void Equals_BookAndNull_ReturnFalse()
        {
            var book = new Book("987-123456789-4", "Name", "Author", 1999, "Publishing house", 100, 100);
            var result = book.Equals(null);
            Assert.AreEqual(false, result);
        }

        [Test]
        public void Equals_EqualBooks_ReturnTrue()
        {
            var firstBook = new Book("987-123456789-4", "Name", "Author", 1999, "Publishing house", 100, 100);
            var secondBook = new Book("987-123456789-4", "Name", "Author", 1999, "Publishing house", 100, 100);
            Assert.AreEqual(firstBook.Equals(secondBook), true);
        }

        [Test]
        public void Equals_BookAndObject_ReturnFalse()
        {
            var book = new Book("987-123456789-4", "Name", "Author", 1999, "Publishing house", 100, 100);
            var notBook = new object();
            Assert.AreEqual(book.Equals(notBook), false);
        }

        [Test(ExpectedResult = "ISBN: 987-123456789-4, name: Some story, author: Author, price: 1050, publication year: 2009, publication house: Publishing house, pages: 350.")]
        public string ToString_ConcreteBook_ReturnString()
        {
            var book = new Book("987-123456789-4", "Some story", "Author", 2009, "Publishing house", 350, 1050);
            return book.ToString();
        }

        [Test]
        public void Equals_TheSameReference_ReturnTrue()
        {
            var book = new Book("987-123456789-4", "Some story", "Author", 2009, "Publishing house", 350, 1050);
            var theSameBook = book;
            Assert.AreEqual(true, book.Equals(theSameBook));
        }

        [Test]
        public void GetHashCode_TheSameBooks_ReturnEqualNumbers()
        {
            var firstBook = new Book("979-122456789-1", "New book", "Ivanov", 2010, "Publishing house", 50, 105);
            var secondBook = new Book("979-122456789-1", "New book", "Ivanov", 2010, "Publishing house", 50, 105);
            Assert.AreEqual(firstBook.GetHashCode(), secondBook.GetHashCode());
        }

        [Test]
        public void GetHashCode_DifferentBooks_ReturnNotEqualHashCodes()
        {
            var firstBook = new Book("979-122456789-1", "New book", "Ivanov", 2010, "Publishing house", 50, 105);
            var secondBook = new Book("979-722456789-2", "Another book", "Another author", 1999, "Eksmo", 201, 105);
            Assert.AreNotEqual(firstBook.GetHashCode(), secondBook.GetHashCode());
        }
    }
}