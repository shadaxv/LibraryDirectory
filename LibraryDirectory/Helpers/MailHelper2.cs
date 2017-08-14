using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Web;
using SendGrid;
using SendGrid.Helpers.Mail;
using System.Threading.Tasks;

namespace LibraryDirectory.Helpers
{
    public class MailHelper2
    {
        public static void SendMail(string userMail, string title, string content, string userName)
        {
            Execute(userMail, title, content, userName).Wait();
        }

        static async Task Execute(string userMail, string title, string content, string userName)
        {
            var apiKey = Environment.GetEnvironmentVariable("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");
            var client = new SendGridClient(apiKey);
            var from = new EmailAddress("admin@librarydirectory.azurewebsites.net", title);
            var subject = title;
            var to = new EmailAddress(userMail, userName);
            var plainTextContent = content;
            var htmlContent = "<strong>librarydirectory.azurewebsites.net</strong>";
            var msg = MailHelper.CreateSingleEmail(from, to, subject, plainTextContent, htmlContent);
            var response = await client.SendEmailAsync(msg);
        }

        public static bool SendMail2(string userMail, string title, string content)
        {
            //ConfigurationSettings.AppSettings["SendMailGmail"];
            MailMessage mail = new MailMessage();
            mail.To.Add(userMail);
            mail.From = new MailAddress(userMail, title, Encoding.UTF8);
            mail.Subject = title;
            mail.SubjectEncoding = Encoding.UTF8;
            mail.Body = content;
            mail.BodyEncoding = Encoding.UTF8;
            mail.IsBodyHtml = true;
            mail.Priority = MailPriority.High;
            SmtpClient client = new SmtpClient();
            client.Credentials = new NetworkCredential("lkjdsaflk", "sdafasdf");
            client.Port = 587;
            client.Host = "smtp.gmail.com";
            client.EnableSsl = true;
            try
            {
                client.Send(mail);
                return true;

            }
            catch (Exception ex)
            {
                return false;
            }

        }
    }
}