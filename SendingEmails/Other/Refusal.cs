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

        private const string EmailSubject = "Nope :(";

        protected override Email CreateEmail()
        {
            var email = new Email()
                .SetMeAsSender()
                .AddEmployeeAsRecipient(employee)
                .SetSubject(EmailSubject)
                .AppendToBody(reason);    

            return email;
        }
    }
}