using System.Linq;
using System.Net.Mail;

namespace FurtherDecoupling.Emails
{
    public class EmailServerMock : EmailServer
    {
        public void SendEmail(MailMessage email)
        {
            ObservedSender = email.From;
            ObservedRecipient = email.To.First();
            ObservedSubject = email.Subject;
            ObservedBody = email.Body;
        }

        public MailAddress ObservedSender { get; private set; }

        public MailAddress ObservedRecipient { get; private set; }

        public string ObservedSubject { get; private set; }

        public string ObservedBody { get; private set; }
    }
}
