using System.Net.Mail;

namespace FurtherDecoupling.Emails
{
    public class DefaultEmailServer : EmailServer
    {
        public void SendEmail(MailMessage email)
        {
            using (var smtpClient = new SmtpClient("..."))
            {
                smtpClient.Send(email);
            }
        }
    }
}
