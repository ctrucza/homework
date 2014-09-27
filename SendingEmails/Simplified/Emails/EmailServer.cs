
using System.Net.Mail;

namespace Simplified.Emails
{
    public interface EmailServer
    {
        void SendEmail(MailMessage email);
    }
}
