using Microsoft.AspNetCore.Mvc;
using BookCrud.Models;
using BookCrud.Repositories;
//using System.Web.Mvc;

namespace BookCrud.Controllers
{
    public class BookController : Controller
    {
       
        // GET: Book
        public ActionResult Index()
        {
            var books = BooksRepoManager.GetBooks();
            return View(books);
        }

        // GET: Book/Details/5
        public ActionResult Details(int id)
        {
            var book = BooksRepoManager.GetBook(id);
            if (book == null)
            {
                return NotFound();
                //return HttpNotFound();
            }
            return View(book);
        }

        // GET: Book/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Book/Create
        [HttpPost]
        public ActionResult Create(Book book)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    BooksRepoManager.Insert(book);
                    return RedirectToAction("Index");
                }
                return View(book);
            }
            catch
            {
                return View();
            }
        }

        // GET: Book/Edit/5
        public ActionResult Edit(int id)
        {
            var book = BooksRepoManager.GetBook(id);
            if (book == null)
            {
                //return HttpNotFound();
                return NotFound();
            }
            return View(book);
        }

        // POST: Book/Edit/5
        [HttpPost]
        public ActionResult Edit(Book book)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    BooksRepoManager.Update(book);
                    return RedirectToAction("Index");
                }
                return View(book);
            }
            catch
            {
                return View();
            }
        }

        // GET: Book/Delete/5
        public ActionResult Delete(int id)
        {
            var book = BooksRepoManager.GetBook(id);
            if (book == null)
            {
                return NotFound();
                //return HttpNotFound();
            }
            return View(book);
        }

        // POST: Book/Delete/5
        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            try
            {
                BooksRepoManager.Delete(id);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
