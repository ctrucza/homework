
using System.Net.Mail;

namespace Simplified
{
    public interface Addressbook
    {
        MailAddress GetMyAddress();

        MailAddress GetAddressOfHumanResources();

        MailAddress GetAddressOfEmployee(Employee employee);
    }
}

