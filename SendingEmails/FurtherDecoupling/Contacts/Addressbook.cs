
using System.Net.Mail;

namespace FurtherDecoupling
{
    public interface Addressbook
    {
        MailAddress GetMyAddress();

        MailAddress GetAddressOfHumanResources();

        MailAddress GetAddressOfEmployee(Employee employee);
    }
}

