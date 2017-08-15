using System;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Security.Cryptography.X509Certificates;
using System.Net.Security;
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
            var apiKey = Environment.GetEnvironmentVariable("apikey sendgrid");
            var client = new SendGridClient(apiKey);
            var from = new EmailAddress("admin@librarydirectory.azurewebsites.net", title);
            var subject = title;
            var to = new EmailAddress(userMail, userName);
            var plainTextContent = content;
            var htmlContent = "<strong>librarydirectory.azurewebsites.net</strong>";
            var msg = MailHelper.CreateSingleEmail(from, to, subject, plainTextContent, htmlContent);
            var response = await client.SendEmailAsync(msg);
        }

        public static string SendMail2(string userMail, string title, string content)
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
            client.Credentials = new NetworkCredential("log", "pass");
            client.Port = 587;
            client.Host = "smtp.gmail.com";
            client.EnableSsl = true;
            client.DeliveryMethod = SmtpDeliveryMethod.Network;
            client.UseDefaultCredentials = false;
            ServicePointManager.ServerCertificateValidationCallback = delegate (object s,
                        X509Certificate certificate,
                        X509Chain chain,
                        SslPolicyErrors sslPolicyErrors)
            {
                return true;
            };
            try
            {
                client.Send(mail);
                return "true";

            }
            catch (Exception ex)
            {
                return "Error: " + ex.ToString();
            }

        }
    }
}