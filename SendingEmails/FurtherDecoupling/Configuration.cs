using System.Net.Mail;

namespace FurtherDecoupling
{
    public class Configuration
    {
        public static MailAddress EmailAddressOfHumanResources
        {
            get
            {
                return new MailAddress("address@of.HR_HOLIDAYS.com");
            }
        }
    }
}

