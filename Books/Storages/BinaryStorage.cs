﻿using Books.Exceptions;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Configuration;
using System.IO;

namespace Books.Storages
{
    /// <summary>
    /// Fake book list.
    /// </summary>
    public class BinaryStorage : IBookListStorage
    {
        private static readonly string filePath;

        private const string DefaultFilePath = "books.dat";

        static BinaryStorage()
        {
            try
            {
                var reader = new AppSettingsReader();
                var settingsReader = new AppSettingsReader();
                string filePathSetting = (string)settingsReader.GetValue("booksFilePath", typeof(string));
                filePath = filePathSetting;
            }
            catch
            {
                filePath = DefaultFilePath;
            }
        }

        public IEnumerable<Book> Load()
        {
            var loadedBooks = new List<Book>();
            try
            {
                using (var reader = new BinaryReader(File.Open(filePath, FileMode.OpenOrCreate)))
                {
                    while (reader.PeekChar() > -1)
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
            catch
            {
                throw new ReadFromStorageException($"There was an error while reading from storage: {filePath}");
            }
        }

        public void Save(IEnumerable<Book> books)
        {
            try
            {
                using (var writer = new BinaryWriter(File.Open(filePath, FileMode.Create)))
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
            catch
            {
                throw new WriteToStorageException($"There was an error while writing to storage: {filePath}");
            }
        }

    }
}
    

