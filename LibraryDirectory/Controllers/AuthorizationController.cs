using LibraryDirectory.Models;
using LibraryDirectory.Helpers;
using System;
using System.Linq;
using System.Web.Mvc;
using System.Web.Security;
using System.Data.Entity.Validation;
using System.Text;

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
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(CustomerModel user)
        {
            if (user.Mail != null && user.Password != null)
            {
                var checkMail = db.Customers.FirstOrDefault(x => x.Mail == user.Mail);
                if (checkMail != null)
                {
                    var passwordWithToken = user.Password + checkMail.Token;
                    var hashedPassword = EncryptPasswordHelper.sha256_hash(passwordWithToken);
                    if (hashedPassword == checkMail.Password)
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
            if (user.Mail != null)
            {
                var token = Guid.NewGuid().ToString();
                    var passwordWithToken = user.Password + token;
                    user.IsActive = false;
                    user.Token = token;
                    user.Password = EncryptPasswordHelper.sha256_hash(passwordWithToken);
                    user.CurrentlyLentBooks = 0;
                    user.AllLentBooks = 0;
                    user.Privilege = 0;
                    user.LastLogin = DateTime.Now;
                    user.AccountBalance = 0;

                    string url = String.Format("http://librarydirectory.azurewebsites.net/Authorization/ActiveAccount/{0}", token);
                    string message = String.Format("Twój link aktywacyjny to: {2}{0}Twój token to: {1}", Environment.NewLine, token, url);
                    string userName = String.Format("{0} {1}", user.FristName, user.LastName);
                    //MailHelper2.SendMail2(user.Mail, "Library Directory - Account Activation", message); //GMAIL
                    //MailHelper2.SendMail(user.Mail, "Library Directory - Account Activation", message, userName); //SENDGRID

                    db.Customers.Add(user);
                    db.SaveChanges();
                    return RedirectToAction("Index", "Home");
                }

           
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
            if (user != null)
            {
                user.IsActive = true;
                db.SaveChanges();
            }
            return RedirectToAction("Index", "Home");
        }
    }
}