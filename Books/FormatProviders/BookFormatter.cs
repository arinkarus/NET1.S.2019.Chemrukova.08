using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Books
{
    public class BookFormatProvider: IFormatProvider, ICustomFormatter
    {
        IFormatProvider parent;

        public BookFormatProvider(IFormatProvider parent)
        {
            this.parent = parent;
        }

        public BookFormatProvider() : this(CultureInfo.CurrentCulture)
        {

        }

        public string Format(string format, object arg, IFormatProvider formatProvider)
        {
            if (arg.GetType() != typeof(Book))
            {
                return HandleOtherFormats(format, arg, parent);
            }

            var book = (Book)arg;
            switch (format)
            {
                case "Name_Price":
                    return $"{book.Name}, {book.Price.ToString(parent)}";
                case "Author_Name_Price":
                    return $"{book.Author}, {book.Name}, {book.Price.ToString(parent)}";
                default:
                    return book.ToString(format, parent);
            }
        }

        public object GetFormat(Type formatType)
        {
            if (formatType == typeof(ICustomFormatter))
            {
                return this;
            }

            return null;
        }

        private string HandleOtherFormats(string format, object arg, IFormatProvider formatProvider)
        {
            if (arg is IFormattable)
            {
                return ((IFormattable)arg).ToString(format, formatProvider);
            }

            if (arg != null)
            {
                return arg.ToString();
            }    
            
            return String.Empty;
        }
        
    }
}
