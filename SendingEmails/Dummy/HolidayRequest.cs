using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace Dummy
{
    public class HolidayRequest
    {
        public HolidayRequest(Employee requester, PeriodOfTime periodOfTime)
        {
            // set fields etc.
        }

        public void Approve()
        {
            var email = CreateApproval();
            SendEmail(email);
        }

        private MailMessage CreateApproval()
        {
            return new MailMessage("me", "HR");
        }

        public void Reject()
        {
            var email = CreateRejection();
            SendEmail(email);
        }

        private MailMessage CreateRejection()
        {
            return new MailMessage("me", "employee");
        }

        private void SendEmail(MailMessage email)
        {
            using (var smtpClient = new SmtpClient("mail.server"))
            {
                smtpClient.Send(email);
            }
        }
    }
}
