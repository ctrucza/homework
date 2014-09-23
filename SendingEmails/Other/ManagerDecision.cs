using System.Net.Mail;
using Other.Emails;

namespace Other
{
    public abstract class ManagerDecision
    {
        /// <summary>
        /// Double-dispatch (anti-)pattern
        /// </summary>
        public void CommunicateViaEmail(IEmailService emailService)
        {
            MailMessage email = CreateEmail();
            emailService.SendEmail(email);
        }

        protected abstract MailMessage CreateEmail();
    }
}
