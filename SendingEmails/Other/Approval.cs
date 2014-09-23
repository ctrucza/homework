using System.Net.Mail;
using Other.Emails;

namespace Other
{
    public class Approval : ManagerDecision
    {
        private readonly Employee employee;

        private readonly string info;

        /// <summary>
        /// Pass in whatever needed...
        /// </summary>
        public Approval(Employee employee, string info)
        {
            this.employee = employee;
            this.info = info;
        }

        private const string EmailSubject = "Yee :)";

        protected override MailMessage CreateEmail()
        {
            var emailWriter = new EmailWriter();

            var email =
                emailWriter.SetMeAsSender()
                    .AddEmployeeAsRecipient(employee)
                    .SetSubject(EmailSubject)
                    .AppendToBody(info)
                    .Email;

            return email;
        }
    }
}
