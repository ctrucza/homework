using System.Net.Mail;

namespace FurtherDecoupling.Emails
{
    public class Email
    {
        // (?) Rename this to "backingEmail" or simply "mailMessage"?
        private MailMessage actualEmail;

        // (?) Receive strings instead of MailAddresses? I believe not.
        public Email(MailAddress from, MailAddress to, string subject, string body)
        {
            actualEmail = new MailMessage(from, to) { Subject = subject, Body = body };
        }

        public void Send()
        {
            var emailServer = EmailServerLocator.Instance;
            emailServer.SendEmail(actualEmail);
        }
    }
}

