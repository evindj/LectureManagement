using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using HRManagement.Service;

namespace HRManagement.Service
{
    public class MockMailService: IMailService
    {
        public bool SendMessage(string from, string to, string subject, string message)
        {
            Debug.WriteLine(string.Concat("Subject :",subject));
            return true;
        }
    }
}
