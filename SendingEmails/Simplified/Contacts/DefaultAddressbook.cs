using System;
using System.Net.Mail;

namespace Simplified
{
    public class DefaultAddressbook : Addressbook
    {
        public MailAddress GetMyAddress()
        {
            throw new NotImplementedException();
        }
        public MailAddress GetAddressOfHumanResources()
        {
            throw new NotImplementedException();
        }
        public MailAddress GetAddressOfEmployee(Employee employee)
        {
            throw new NotImplementedException();
        }
    }
}

