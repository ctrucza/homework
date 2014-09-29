using System.Net.Mail;

namespace FurtherDecoupling
{
    public class Manager
    {
        public Manager(MailAddress emailAddress)
        {
            EmailAddress = emailAddress;
        }

        public MailAddress EmailAddress { get; private set; }
    }
}

