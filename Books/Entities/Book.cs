using System;

namespace Books
{
    /// <summary>
    /// Represents a book entity.
    /// </summary>
    public class Book : IEquatable<Book>, IComparable<Book>
    {
        #region Fields 

        /// <summary>
        /// ISBN (number).
        /// </summary>
        private string isbn;

        /// <summary>
        /// Book title.
        /// </summary>
        private string name;

        /// <summary>
        /// Author of book.
        /// </summary>
        private string author;

        /// <summary>
        /// Year of publication.
        /// </summary>
        private int publicationYear;

        /// <summary>
        /// Publication house.
        /// </summary>
        private string publishingHouse;

        /// <summary>
        /// Page count.
        /// </summary>
        private int amountOfPages;

        /// <summary>
        /// Book's price.
        /// </summary>
        private decimal price;

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="Book"/> class.
        /// </summary>
        public Book()
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="Book"/> class.
        /// </summary>
        /// <param name="isbn">Number ISBN.</param>
        /// <param name="name">Title of book.</param>
        /// <param name="author">Author of book.</param>
        /// <param name="publicationYear">Year of publication.</param>
        /// <param name="publishingHouse">House of publication.</param>
        /// <param name="amountOfPages">Pages count.</param>
        /// <param name="price">Price of the book.</param>
        public Book(string isbn, string name, string author, int publicationYear, string publishingHouse, int amountOfPages, decimal price)
        {
            this.Isbn = isbn;
            this.Name = name;
            this.Author = author;
            this.PublicationYear = publicationYear;
            this.PublishingHouse = publishingHouse;
            this.AmountOfPages = amountOfPages;
            this.Price = price;
        }

        #endregion

        #region Properties

        /// <summary>
        /// Gets or sets isbn number of book.
        /// </summary>
        public string Isbn
        {
            get
            {
                return this.isbn;
            }

            set
            {
                BookValidator.ValidateISBN(value);
                this.isbn = value;
            }
        }

        /// <summary>
        /// Gets or sets book's title.
        /// </summary>
        public string Name
        {
            get
            {
                return this.name;
            }

            set
            {
                BookValidator.CheckString(value);
                this.name = value;
            }
        }

        /// <summary>
        /// Gets or sets author.
        /// </summary>
        public string Author
        {
            get
            {
                return this.author;
            }

            set
            {
                BookValidator.CheckString(value);
                this.author = value;
            }
        }
        
        /// <summary>
        /// Gets or sets publication year.
        /// </summary>
        public int PublicationYear
        {
            get
            {
                return this.publicationYear;
            }

            set
            {
                BookValidator.CheckYear(value);
                this.publicationYear = value;
            }
        }

        /// <summary>
        /// Gets or sets publication house name.
        /// </summary>
        public string PublishingHouse
        {
            get
            {
                return this.publishingHouse;
            }

            set
            {
                BookValidator.CheckString(value);
                this.publishingHouse = value;
            }
        }

        /// <summary>
        /// Gets or sets amount of pages.
        /// </summary>
        public int AmountOfPages
        {
            get
            {
                return this.amountOfPages;
            }

            set
            {
                BookValidator.CheckForPositiveNumber(value);
                this.amountOfPages = value;
            }
        }
        
        /// <summary>
        /// Gets or sets book's price.
        /// </summary>
        public decimal Price
        {
            get
            {
                return this.price;
            }

            set
            {
                BookValidator.CheckPrice(value);
                this.price = value;
            }
        }

        #endregion

        #region Public methods

        /// <summary>
        /// Compares this book instance with given.
        /// </summary>
        /// <param name="other">Other book.</param>
        /// <returns>Result of comparison.</returns>
        public int CompareTo(Book other)
        {
            BookValidator.CheckOnNull(other);
            return other.isbn.CompareTo(this.isbn);
        }

        /// <summary>
        /// Compares this book instance with another.
        /// </summary>
        /// <param name="other">Book to compare with.</param>
        /// <returns>True if books have equal information.</returns>
        public bool Equals(Book other)
        {
            if (other == null)
            {
                return false;
            }

            if (other == this)
            {
                return true;
            }

            if (this.Isbn == other.Isbn)
            {
                return true;
            }

          /*  if (this.Isbn == other.Isbn && this.Name == other.Name && 
                this.Price == other.Price && this.Author == other.Author && this.PublicationYear == other.PublicationYear &&
                this.PublishingHouse == other.PublishingHouse && this.AmountOfPages == this.AmountOfPages)
            {
                return true;
            }
            */
            return false;    
        }

        #endregion

        #region Object overrides

        /// <summary>
        /// Compares book with given object.
        /// </summary>
        /// <param name="obj">Given object.</param>
        /// <returns>True if object is a book and is equal to this book. Otherwise - false.</returns>
        public override bool Equals(object obj)
        {
            if ((obj == null) || !this.GetType().Equals(obj.GetType()))
            {
                return false;
            }

            return this.Equals(obj as Book);
        }

        /// <summary>
        /// Gets hash code for book.
        /// </summary>
        /// <returns>Hash code.</returns>
        public override int GetHashCode()
        {
            return (this.Isbn, this.Name, this.Price, this.Author, this.PublicationYear, this.PublishingHouse, this.AmountOfPages).GetHashCode();
        }

        /// <summary>
        /// Return string representation of book.
        /// </summary>
        /// <returns>Information about book.</returns>
        public override string ToString()
        {
            return $"ISBN: {this.Isbn}, name: {this.Name}, author: {this.author}, price: {this.price}," +
                $" publication year: {this.PublicationYear}, publication house: {this.PublishingHouse}, pages: {this.AmountOfPages}.";
        }

        #endregion
    }
}
