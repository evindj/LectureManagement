using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HRManagement.Models;
using HRManagement.Service;

namespace HRManagement.Controllers
{
    public class HomeController : Controller
    {
        private IMailService _mail;

        public HomeController(IMailService mail)
        {
            _mail = mail;
        }
        public ActionResult Index()
        {
            ViewBag.Message = "Modify this template to jump-start your ASP.NET MVC application.";

            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your app description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        [HttpPost]
        public ActionResult Contact(ContactModel model)
        {

            var msg = string.Format("Comment from:{1}{0} Email: {2}{0} Website: {3}{0} Comment: {4}{0}", Environment.NewLine, model.Name, model.Email, model.Website, model.Comment);
            if (_mail.SendMessage("noreply@mydomain.com", "foo@mydomain.com", "comment", msg))
            {
                ViewBag.MailSet = true;
            };

            return View();
        }
    }
}
