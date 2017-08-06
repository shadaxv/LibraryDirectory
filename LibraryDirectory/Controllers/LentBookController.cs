using LibraryDirectory.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LibraryDirectory.Controllers
{
    public class LentBookController : Controller
    {
        private LentBooksDbContext db = new LentBooksDbContext();

        // GET: LentBook
        public ActionResult Index()
        {
            return View(db.LentBooks.ToList());
        }
    }
}