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

        protected override MailMessage CreateEmail()
        {
            var emailWriter = new EmailWriter();

            var email =
                emailWriter.SetMeAsSender()
                    .AddEmployeeAsRecipient(employee)
                    .SetSubject("Yee :)")
                    .AppendBody(info)
                    .Email;

            return email;
        }
    }
}
