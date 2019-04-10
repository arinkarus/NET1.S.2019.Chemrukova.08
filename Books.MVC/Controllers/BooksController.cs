using Books.MVC.Criterias;
using Books.Storages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Books.Exceptions;

namespace Books.MVC.Controllers
{
    public class BooksController : Controller
    {
        private IBookListService service = new BookListService(new BinaryStorage());

        public ActionResult Index()
        {
            service.Load();                
            return View(service.GetAll());
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Book bookToAdd)
        {
            try
            {
                service.Load();
                service.Add(bookToAdd);
                service.Save();
            }
            catch(Exception ex)
            {
                ViewBag.ErrorMessage = ex.Message;
                return View();
            }
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Edit(string isbn)
        {
            service.Load();
            Book bookToEdit = service.FindBookByTag(new SearchByISBNCriteria(isbn));
            if (bookToEdit == null)
            {
                return new HttpNotFoundResult();
            }
            return View(bookToEdit);
        }

        [HttpPost]
        public ActionResult Edit(Book book)
        {
            service.Load();
            service.Update(book);
            service.Save();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Delete(string isbn)
        {
            service.Load();
            Book book = service.FindBookByTag(new SearchByISBNCriteria(isbn));
            if (book == null)
            {
                return new HttpNotFoundResult();
            }
            return View(book);
        }


        [ActionName("Delete")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string isbn)
        {
            try
            {
                Book book = new Book
                {
                    Isbn = isbn
                };
                service.Load();
                service.Remove(book);
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