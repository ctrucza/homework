using System.Net.Mail;

namespace Simplified.Emails
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
