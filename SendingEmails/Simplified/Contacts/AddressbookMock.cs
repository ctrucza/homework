using System.Net.Mail;

namespace Simplified
{
    public class AddressbookMock : Addressbook
    {
        public MailAddress GetMyAddress()
        {
            return new MailAddress("address@of.logged.in.user");
        }

        public MailAddress GetAddressOfHumanResources()
        {
            return new MailAddress("address@of.HR_HOLIDAYS.com");
        }

        public MailAddress GetAddressOfEmployee(Employee employee)
        {
            return new MailAddress(employee + "@something.com");
        }
    }
}

