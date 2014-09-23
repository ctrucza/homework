using System.Net.Mail;

namespace Other.Emails
{
    public interface IEmailService
    {
        void SendEmail(MailMessage email);
    }
}
