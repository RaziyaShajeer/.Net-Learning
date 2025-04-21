using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace WebMvc.Controllers
{
    public class EmailController : Controller
    {
        SmtpClient Client = new SmtpClient("smtp.gmail.com",587);
        public IActionResult SendMail()
        {
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> SendMail(string toEmail,string subject,string message)
        {
            var fromEmail = "farhasalman1989@gmail.com";
            var fromPassword = "isvm kqdh xmsb vnpe";


            Client.UseDefaultCredentials = false;
            Client.Credentials = new NetworkCredential(fromEmail, fromPassword);
            Client.EnableSsl = true;
            var MailMessage = new MailMessage()
            {
                From = new MailAddress(fromEmail),
                Subject = subject,
                Body = message,
                IsBodyHtml = true
            };
            //isvm kqdh xmsb vnpe

            MailMessage.To.Add(toEmail);
            await Client.SendMailAsync(MailMessage);


            return View();
        }
    }
}
