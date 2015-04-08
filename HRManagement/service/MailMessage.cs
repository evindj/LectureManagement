using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Web;

namespace HRManagement.Service
{
    public class MailService: IMailService
    {
        public bool SendMessage(string from, string to, string subject, string body)
        {
            var message = new MailMessage(from, to, subject, body);
            var client = new SmtpClient();
            client.Send(message);
            return true;
        }
    }
}