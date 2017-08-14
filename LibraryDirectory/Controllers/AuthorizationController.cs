using LibraryDirectory.Models;
using LibraryDirectory.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using System.Data.Entity.Validation;

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

        
        [HttpGet]
        public ActionResult LogIn()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(CustomerModel user)
        {
            if(user.Mail != null && user.Password != null)
            {
                var checkMail = db.Customers.FirstOrDefault(x => x.Mail == user.Mail);
                if (checkMail != null)
                {
                    var byteToken = System.Text.Encoding.Unicode.GetBytes(user.Token);
                    var encryptedPassword = EncryptPasswordHelper.GenerateSaltedHash(user.Password, byteToken);
                    if (EncryptPasswordHelper.CompareByteArrays(checkMail.Password, encryptedPassword) && checkMail.IsActive)
                    {
                        FormsAuthentication.SetAuthCookie(user.Mail, false);
                        return RedirectToAction("Index", "Home");
                    }
                }
            }
            else
            {
                ModelState.AddModelError("", "Login details are wrong.");
            }
            return View();
        }

        [HttpGet]
        public ActionResult Registration()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Registration(CustomerModel user)
        {
            //if(user.Mail != null && user.Password != null)
            //{
            try
            {
                if (ModelState.IsValid)
                {
                    var token = Guid.NewGuid().ToString();
                    var byteToken = System.Text.Encoding.Unicode.GetBytes(token);

                    user.Password = EncryptPasswordHelper.GenerateSaltedHash(user.Password, byteToken);
                    user.IsActive = false;
                    user.Token = token;

                    string url = String.Format("http://librarydirectory.azurewebsites.net/ActiveAccount/{0}", token);
                    string message = String.Format("Twój link aktywacyjny to: {2}{0}Twój token to: {1}", Environment.NewLine, token, url);
                    string userName = String.Format("{0} {1}", user.FristName, user.LastName);
                    //MailHelper.SendMail2(user.Mail, "Library Directory - Account Activation", message); //GMAIL
                    MailHelper2.SendMail(user.Mail, "Library Directory - Account Activation", message, userName); //SENDGRID

                    db.Customers.Add(user);
                    db.SaveChanges();
                    return RedirectToAction("Index", "Home");
                }

                else
                {
                    ModelState.AddModelError("", "Data is not correct");
                }
            }
            catch (DbEntityValidationException e)
            {
                foreach (var eve in e.EntityValidationErrors)
                {
                    Console.WriteLine("Entity of type \"{0}\" in state \"{1}\" has the following validation errors:", eve.Entry.Entity.GetType().Name, eve.Entry.State);
                    foreach (var ve in eve.ValidationErrors)
                    {
                        Console.WriteLine("- Property: \"{0}\", Error: \"{1}\"", ve.PropertyName, ve.ErrorMessage);
                    }
                }
                throw;
            }
            //}
            return View();
        }

        public ActionResult UserLogout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Home");
        }

        [Route("ActiveAccount/{token}")]
        public ActionResult ActiveAccount(string token)
        {
            var user = db.Customers.SingleOrDefault(x => x.Token == token);
            if(user != null)
            {
                user.IsActive = true;
                db.SaveChanges();
            }
            return RedirectToAction("Index", "View");
        }
    }
}