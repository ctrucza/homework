using System.Linq;
using System.Net.Mail;

namespace Other.Emails
{
    public class EmailServerMock : IEmailServer
    {
        public void SendEmail(Email email)
        {
            MailMessage mailMessage = email.AsMailMessage();

            ObservedRecipient = mailMessage.To.First().Address;
            ObservedSubject = mailMessage.Subject;
            ObservedBody = mailMessage.Body;
        }

        public string ObservedRecipient { get; private set; }

        public string ObservedSubject { get; private set; }

        public string ObservedBody { get; private set; }
    }
}
