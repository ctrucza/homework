
using System.Net.Mail;

namespace FurtherDecoupling.Emails
{
    public interface EmailServer
    {
        void SendEmail(MailMessage email);
    }
}
