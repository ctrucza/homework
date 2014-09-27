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
            Email email = CreateEmail();
            emailServer.SendEmail(email);
        }

        protected abstract Email CreateEmail();
    }
}
