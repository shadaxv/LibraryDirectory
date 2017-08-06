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
        private LibraryDbContext db = new LibraryDbContext();

        // GET: LentBook
        public ActionResult Index()
        {
            return View(db.LentBooks.ToList());
        }
    }
}