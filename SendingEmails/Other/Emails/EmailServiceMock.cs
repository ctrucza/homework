using System.Linq;
using System.Net.Mail;

namespace Other.Emails
{
    public class EmailServiceMock : IEmailService
    {
        public void SendEmail(MailMessage email)
        {
            ObservedRecipient = email.To.First().Address;
            ObserverSubject = email.Subject;
            ObservedBody = email.Body;
        }

        public string ObservedRecipient { get; private set; }

        public string ObserverSubject { get; private set; }

        public string ObservedBody { get; private set; }
    }
}
