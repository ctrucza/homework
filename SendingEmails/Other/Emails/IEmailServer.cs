using System.Net.Mail;

namespace Other.Emails
{
    public interface IEmailServer
    {
        void SendEmail(MailMessage email);
    }
}
