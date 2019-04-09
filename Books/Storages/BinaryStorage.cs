using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Books.Storages
{
    /// <summary>
    /// Fake book list.
    /// </summary>
    public class BinaryStorage : IBookListStorage
    {
        public IEnumerable<Book> Load()
        {
            string path = @"E:\WebApi\states.dat";
            var loadedBooks = new List<Book>();
            using (var reader = new BinaryReader(File.Open(path, FileMode.OpenOrCreate)))
            {
                while (reader.PeekChar()  > -1)
                {
                    string isbn = reader.ReadString();
                    string name = reader.ReadString();
                    string author = reader.ReadString();
                    string publishingHouse = reader.ReadString();
                    decimal price = reader.ReadDecimal();
                    int year = reader.ReadInt32();
                    int amountOfPages = reader.ReadInt32();
                    var book = new Book(isbn, name, author, year, publishingHouse, amountOfPages, price);
                    loadedBooks.Add(book);
                }
            }
            return loadedBooks;
        }

        public void Save(IEnumerable<Book> books)
        {
            string path = @"E:\WebApi\states.dat";
            using (var writer = new BinaryWriter(File.Open(path, FileMode.Create)))
            {
                foreach (var book in books)
                {
                    writer.Write(book.Isbn);
                    writer.Write(book.Name);
                    writer.Write(book.Author);
                    writer.Write(book.PublishingHouse);
                    writer.Write(book.Price);
                    writer.Write(book.PublicationYear);
                    writer.Write(book.AmountOfPages);
                }
            }
        }

    }
}
    

