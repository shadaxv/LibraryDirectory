using LibraryDirectory.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LibraryDirectory.Controllers
{
    public class AuthorizationController : Controller
    {
        private LibraryDbContext db = new LibraryDbContext();

        // GET: Authorization
        public ActionResult Index()
        {
            return View(db.Customers.ToList());
        }

        public ActionResult Login()
        {
            return View();
        }

        public ActionResult Registration()
        {
            return View();
        }
    }
}