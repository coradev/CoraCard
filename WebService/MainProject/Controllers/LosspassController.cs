using EFDataAccess.DAL;
using MainProject.Common;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Mail;
using System.Web;
using System.Web.Mvc;

namespace MainProject.Controllers
{
    public class LosspassController : Controller
    {
        // GET: Losspass
        public ActionResult Index()
        {
            var user = (UserLogin)Session[CMConst.USER_SESSION];
            if (user != null)
            {
                return RedirectToAction("", "Home", new { area = "" });
            }
            return View();
        }

        public ActionResult SendMail(Models.EmailModel model)
        {
            if (ModelState.IsValid)
            {
                var dao = new UserDAO();
                var user = dao.GetUserByEmail(model.MailTo);
                if (user == null)
                {
                    ModelState.AddModelError("", "No account found!");
                }
                else
                {
                    //send mail
                    MailMessage mail = new MailMessage();
                    mail.To.Add(model.MailTo);
                    mail.From = new MailAddress(ConfigurationManager.AppSettings["EmailAccount"].ToString());
                    mail.Subject = "Your CoraCard Account Password!";
                    string Body = "<div style=" + "font - family: sans - serif" + "><h2>CoraCard</h2><div><b>Account</b>: " + user.USERNAME + "</div><div><b>Password</b>:" + user.PASSWORD + "</div></div>";
                    mail.Body = Body;
                    mail.IsBodyHtml = true;
                    SmtpClient smtp = new SmtpClient();
                    smtp.Host = ConfigurationManager.AppSettings["SMTPHost"].ToString();
                    smtp.Port = Convert.ToInt32(ConfigurationManager.AppSettings["SMTPPost"]);
                    smtp.UseDefaultCredentials = false;
                    string username = ConfigurationManager.AppSettings["EmailAccount"].ToString();
                    string password = ConfigurationManager.AppSettings["EmailPassword"].ToString();
                    smtp.Credentials = new System.Net.NetworkCredential(username, password); // Enter seders User name and password       
                    smtp.EnableSsl = true;
                    smtp.Send(mail);

                    TempData["Message"] = "Send your password successfully !";
                    return RedirectToAction("Index", "Login");
                }
            }
            return View("Index");
        }
    }
}