using LibraryDirectory.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LibraryDirectory.Controllers
{
    public class AdminController : Controller
    {
        private CustomerDbContext db = new CustomerDbContext();

        // GET: Admin
        public ActionResult Index()
        {
            return View(db.Customers.ToList());
        }
    }
}