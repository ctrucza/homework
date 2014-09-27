using System;
using System.Net.Mail;

namespace Other.Emails
{
    public class Email
    {
        MailMessage mailMessage = new MailMessage();

        public Email SetMeAsSender()
        {
            mailMessage.From = GetMyAddress();
            return this;
        }

        private MailAddress GetMyAddress()
        {
            // Fake alert
            return new MailAddress("address@of.logged.in.user");
        }

        public Email AddHumanResourcesAsRecipient()
        {
            mailMessage.To.Add(GetHumanResourcesAddress());
            return this;
        }

        private MailAddress GetHumanResourcesAddress()
        {
            // Fake alert
            return new MailAddress("address@of.HR_HOLIDAYS.com");
        }

        public Email AddEmployeeAsRecipient(Employee employee)
        {
            mailMessage.To.Add(GetEmployeeAddress(employee));
            return this;
        }
        
        private MailAddress GetEmployeeAddress(Employee employee)
        {
            // Fake alert
            return new MailAddress(employee + "@something.com");
        }

        public Email SetSubject(string subject)
        {
            mailMessage.Subject = subject;
            return this;
        }

        public Email AppendToBody(string content)
        {
            mailMessage.Body += content + Environment.NewLine;
            return this;
        }

        public MailMessage AsMailMessage()
        {
            return mailMessage;
        }
    }
}
