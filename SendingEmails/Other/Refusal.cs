using System.Net.Mail;
using Other.Emails;

namespace Other
{
    public class Refusal : ManagerDecision
    {
        private readonly Employee employee;
        private readonly string reason;

        /// <summary>
        /// Pass in whatever needed...
        /// </summary>
        public Refusal(Employee employee, string reason)
        {
            this.employee = employee;
            this.reason = reason;
        }

        protected override MailMessage CreateEmail()
        {
            var emailWriter = new EmailWriter();
            
            var email =
                emailWriter.SetMeAsSender()
                    .AddEmployeeAsRecipient(employee)
                    .SetSubject("Nope :(")
                    .AppendBody(reason)
                    .Email;

            return email;
        }
    }
}
