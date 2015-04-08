namespace HRManagement.Service
{
   public  interface IMailService
    {
         bool SendMessage(string from, string to, string subject, string message);
    }
}
