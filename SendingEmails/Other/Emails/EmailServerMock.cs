using System.Linq;
using System.Net.Mail;

namespace Other.Emails
{
    public class EmailServerMock : IEmailServer
    {
        public void SendEmail(MailMessage email)
        {
            ObservedRecipient = email.To.First().Address;
            ObservedSubject = email.Subject;
            ObservedBody = email.Body;
        }

        public string ObservedRecipient { get; private set; }

        public string ObservedSubject { get; private set; }

        public string ObservedBody { get; private set; }
    }
}
