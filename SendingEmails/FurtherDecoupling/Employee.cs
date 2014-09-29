using System.Net.Mail;

namespace FurtherDecoupling
{
    public class Employee
    {
        public Employee(MailAddress emailAddress)
        {
            EmailAddress = emailAddress;
        }

        public MailAddress EmailAddress { get; private set; }
    }
}
