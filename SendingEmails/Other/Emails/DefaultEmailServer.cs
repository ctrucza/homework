using System.Net.Mail;

namespace Other.Emails
{
    public class DefaultEmailServer : IEmailServer
    {
        public void SendEmail(Email email)
        {
            using (var smtpClient = new SmtpClient("..."))
            {
                smtpClient.Send(email.AsMailMessage());
            }
        }
    }
}
