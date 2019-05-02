using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using System.Globalization;
using Books;

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

        [TestCase(ExpectedResult = "Jon Skeet, C# in Depth, 2019, Manning")]
        public string ToString_ConcreteBook_ReturnString()
        {
            var book = new Book("979-122456789-1", "C# in Depth", "Jon Skeet", 2019, "Manning", 600, 100);
            return book.ToString();
        }

        [Test]
        public void GetHashCode_DifferentBooks_ReturnNotEqualHashCodes()
        {
            var firstBook = new Book("979-122456789-1", "New book", "Ivanov", 2010, "Publishing house", 50, 105);
            var secondBook = new Book("979-722456789-2", "Another book", "Another author", 1999, "Eksmo", 201, 105);
            Assert.AreNotEqual(firstBook.GetHashCode(), secondBook.GetHashCode());
        }

        [Test]
        public void ToString_InvalidFormatString_ThrowFormatException() =>
            Assert.Throws<FormatException>(() => new Book("979-122456789-1", "C# in Depth", "Jon Skeet", 2019, "Manning", 600, 100).ToString("some"));

        [TestCase("General", ExpectedResult = "Jon Skeet, C# in Depth, 2019, Manning")]
        [TestCase("Name_Author_House", ExpectedResult = "C# in Depth, Jon Skeet, Manning")]
        [TestCase("Name", ExpectedResult = "C# in Depth")]
        [TestCase("Author_Name", ExpectedResult = "Jon Skeet, C# in Depth")]
        [TestCase("Author_Name_Year", ExpectedResult = "Jon Skeet, C# in Depth, 2019")]
        [TestCase("Author_Name_Year_House", ExpectedResult = "Jon Skeet, C# in Depth, 2019, Manning")]
        public string ToString_FormatStringGiven_ReturnString(string format)
        {
            var book = new Book("979-122456789-1", "C# in Depth", "Jon Skeet", 2019, "Manning", 600, 100);
            return book.ToString(format, CultureInfo.InvariantCulture);
        }

        [TestCase("{0:Some}")]
        public void Format_BookFormatterInvalidFormatString_ThrowFormatException(string format)
        {
            var book = new Book("979-122456789-1", "C# in Depth", "Jon Skeet", 2019, "Manning", 600, 100);
            Assert.Throws<FormatException>(() => string.Format(new BookFormatter(), format, book)); 
        }

        [TestCase("{0:Author_Name_Price}", ExpectedResult = "Jon Skeet, C# in Depth, 100.01")]
        [TestCase("{0:Name_Price}", ExpectedResult = "C# in Depth, 100.01")]
        public string Format_BookFormatterValidFormatString_ReturnString(string format)
        {
            CultureInfo cultureInfo = CultureInfo.InvariantCulture;         
            var book = new Book("979-122456789-1", "C# in Depth", "Jon Skeet", 2019, "Manning", 600, 100.01m);
            return string.Format(new BookFormatter(cultureInfo), format, book);
        }

        [TestCase("{0:Price}", ExpectedResult = "100.01")]
        public string Format_BookFormatterParentFormatString_ReturnString(string format)
        {
            CultureInfo cultureInfo = CultureInfo.InvariantCulture;
            var book = new Book("979-122456789-1", "C# in Depth", "Jon Skeet", 2019, "Manning", 600, 100.01m);
            return string.Format(new BookFormatter(cultureInfo), format, book);
        }

        [TestCase("{0:Price}", ExpectedResult = "100,01")]
        public string Format_BookFormatterParentFormatStringRussianCulture_ReturnString(string format)
        {
            CultureInfo cultureInfo = new CultureInfo("RU-ru");
            var book = new Book("979-122456789-1", "C# in Depth", "Jon Skeet", 2019, "Manning", 600, 100.01m);
            return string.Format(new BookFormatter(cultureInfo), format, book);
        }

        [TestCase("{0:Author_Name_Price}", ExpectedResult = "Jon Skeet, C# in Depth, 100,01")]
        [TestCase("{0:Name_Price}", ExpectedResult = "C# in Depth, 100,01")]
        public string Format_BookFormatterValidFormatStringRussianCulture_ReturnString(string format)
        {
            CultureInfo cultureInfo = new CultureInfo("RU-ru");
            var book = new Book("979-122456789-1", "C# in Depth", "Jon Skeet", 2019, "Manning", 600, 100.01m);
            return string.Format(new BookFormatter(cultureInfo), format, book);
        }
    }
}