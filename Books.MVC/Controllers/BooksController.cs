using Books.MVC.Criterias;
using Books.Storages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Books.MVC.Controllers
{
    public class BooksController : Controller
    {
        private IBookListService service = new BookListService(new BinaryStorage());

        public ActionResult Index()
        {
            IEnumerable<Book> books = service.Load();
            return View(books);
        }

        [HttpGet]
        public ActionResult Create(string isbn)
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Book bookToAdd)
        {
            IEnumerable<Book> books = service.Load();
            service.Add(bookToAdd);
            service.Save();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Edit(string isbn)
        {
            IEnumerable<Book> books = service.Load();
            IEnumerable<Book> booksFromStorage = service.FindByTag(new SearchByISBNCriteria(isbn));
            return View(booksFromStorage.ElementAt<Book>(0));
        }

        [HttpPost]
        public ActionResult Edit(Book book)
        {
            List<Book> books = service.Load().ToList();
            int indexOfBookToChange = service.GetFirstMatchIndex(new SearchByISBNCriteria(book.Isbn));
            books[indexOfBookToChange] = book;
            service.Save();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Delete(string isbn)
        {
            IEnumerable<Book> books = service.Load();
            IEnumerable<Book> booksFromStorage = service.FindByTag(new SearchByISBNCriteria(isbn));
            return View(booksFromStorage.ElementAt<Book>(0));
        }

        [ActionName("Delete")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string isbn)
        {
            try
            {
                List<Book> books = service.Load().ToList();
                int indexOfBookToChange = service.GetFirstMatchIndex(new SearchByISBNCriteria(isbn));
                service.Remove(books[indexOfBookToChange]);
                service.Save();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

    }
}