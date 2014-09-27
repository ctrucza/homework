using System.Net.Mail;
using Other.Emails;

namespace Other
{
    public abstract class ManagerDecision
    {
        /// <summary>
        /// Double-dispatch (anti-)pattern
        /// </summary>
        public void CommunicateViaEmail(IEmailServer emailServer)
        {
            MailMessage email = CreateEmail();
            emailServer.SendEmail(email);
        }

        protected abstract MailMessage CreateEmail();
    }
}
