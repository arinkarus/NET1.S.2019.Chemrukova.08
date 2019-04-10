using System;
using System.Text.RegularExpressions;

namespace Books
{
    public static class BookValidator
    {
        /// <summary>
        /// Checks if object is null.
        /// </summary>
        /// <param name="obj">Given object.</param>
        /// <exception cref="ArgumentNullException">Thrown when object is null.</exception>
        public static void CheckOnNull(object obj)
        {
            if (obj == null)
            {
                throw new ArgumentNullException($"{nameof(obj)} can't be null!");
            }
        }

        /// <summary>
        /// Checks that string isn't null and does contain useful info.
        /// </summary>
        /// <param name="str">Given string.</param>
        /// <exception cref="ArgumentNullException">Thrown when given string is null.</exception>
        /// <exception cref="ArgumentException">Thrown when string contains only
        /// spaces or is empty.
        /// </exception>
        public static void CheckString(string str)
        {
            CheckOnNull(str);
            if (str.Trim().Length == 0)
            {
                throw new ArgumentException($"{nameof(str)} doesn't contain any useful information!");
            }
        }

        /// <summary>
        /// Checks number to be positive.
        /// </summary>
        /// <param name="number">Number to check.</param>
        public static void CheckForPositiveNumber(int number)
        {
            if (number <= 0)
            {
                throw new ArgumentException($"{nameof(number)} has to be a positive number!");
            }
        }

        /// <summary>
        /// Checks year.
        /// </summary>
        /// <param name="year">Number to check.</param>
        public static void CheckYear(int year)
        {
            CheckForPositiveNumber(year);
            if (year > DateTime.Today.Year)
            {
                throw new ArgumentException($"{nameof(year)} isn't valid value for year!");
            }
        }

        /// <summary>
        /// Checks price.
        /// </summary>
        /// <param name="price">Price to check.</param>
        public static void CheckPrice(decimal price)
        {
            if (price < 0)
            {
                throw new ArgumentException($"{nameof(price)} has to be a positive value.");
            }
        }

        /// <summary>
        /// Validates book number.
        /// </summary>
        /// <param name="isbn">Given ISBN number.</param>
        public static void ValidateISBN(string isbn)
        {
            CheckString(isbn);
            string patternToMatch = "^(987|979)-[0-9]{9}-[0-9]{1}$";
            if (!Regex.IsMatch(isbn, patternToMatch))
            {
                throw new ArgumentException($"{nameof(isbn)} doesn't match ISBN format.");
            }
        }
    }
}
