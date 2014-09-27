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

        protected override Email CreateEmail()
        {
            var email = new Email()
                .SetMeAsSender()
                .AddHumanResourcesAsRecipient()
                .AddEmployeeAsRecipient(employee)
                .SetSubject(EmailSubject)
                .AppendToBody(info);               

            return email;
        }
    }
}
