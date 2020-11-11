using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Web;
using System.Web.Mvc;

namespace WebApplication.Controllers
{
    public class ContactController : Controller
    {
        // GET: Contact
        public ActionResult Index()
        {


            return View();
        }

        [HttpPost]
        public ActionResult EnvoyerEmail(string nom, string email, string message)
        {

            try
            {
                MailMessage msg = new MailMessage();
                msg.From = new MailAddress(email);
                msg.To.Add(new MailAddress(""));
                msg.Subject = "Nouveau Message Avis";

                msg.Body = message;
                //var client = new SmtpClient
                //{

                //}
                //client.Send(msg);
            }
            catch
            {
                return View("Erreur Envoie");
            }
            return View("Merci");
        }
    }
}