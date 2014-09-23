using System;
using System.Net.Mail;

namespace Other.Emails
{
    /// <summary>
    /// Aka builder :)
    /// </summary>
    public class EmailWriter
    {
        public EmailWriter()
        {
            Email = new MailMessage();
        }

        public MailMessage Email { get; private set; }

        public EmailWriter SetMeAsSender()
        {
            Email.From = GetMyAddress();
            return this;
        }

        private MailAddress GetMyAddress()
        {
            // Fake alert
            return new MailAddress("address@of.logged.in.user");
        }

        public EmailWriter AddHumanResourcesAsRecipient()
        {
            Email.To.Add(GetHumanResourcesAddress());
            return this;
        }

        private MailAddress GetHumanResourcesAddress()
        {
            // Fake alert
            return new MailAddress("address@of.HR_HOLIDAYS.com");
        }

        public EmailWriter AddEmployeeAsRecipient(Employee employee)
        {
            Email.To.Add(GetEmployeeAddress(employee));
            return this;
        }
        
        private MailAddress GetEmployeeAddress(Employee employee)
        {
            // Fake alert
            return new MailAddress(employee + "@something.com");
        }

        public EmailWriter SetSubject(string subject)
        {
            Email.Subject = subject;
            return this;
        }

        public EmailWriter AppendBody(string content)
        {
            Email.Body += content + Environment.NewLine;
            return this;
        }
    }
}
