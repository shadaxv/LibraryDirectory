using LibraryDirectory.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LibraryDirectory.Controllers
{
    public class BooksController : Controller
    {
        private BookDbContext db = new BookDbContext();

        // GET: Books
        public ActionResult Index()
        {
            return View(db.Books.ToList());
        }
    }
}