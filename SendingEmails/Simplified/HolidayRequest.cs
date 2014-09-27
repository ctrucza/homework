using System.Net.Mail;
using Simplified.Emails;

namespace Simplified
{
    public enum HolidayRequestStatus
    {
        Pending,
        Approved,
        Rejected
    }

    public class HolidayRequest
    {
        private readonly Employee employee;
        private readonly PeriodOfTime periodOfTime;
        private readonly EmailServer emailServer;
        private readonly Addressbook addressbook;

        public HolidayRequest(Employee employee, PeriodOfTime periodOfTime, HolidayRequestStatus status)
        {
            this.employee = employee;
            this.periodOfTime = periodOfTime;
            Status = status;

            emailServer = EmailServerLocator.Instance;
            addressbook = AddressbookLocator.Instance;
        }

        public HolidayRequestStatus Status { get; private set; }

        public void Approve()
        {
            emailServer.SendEmail(CreateApprovalEmail());
            Status = HolidayRequestStatus.Approved;
        }

        private MailMessage CreateApprovalEmail()
        {
            var from = addressbook.GetMyAddress();
            var to = addressbook.GetAddressOfHumanResources();
            var subject = "Yee :)";
            var body = string.Format("Some info: {0}, {1}", employee, periodOfTime);

            return new MailMessage(from, to) { Subject = subject, Body = body };
        }

        public void Reject(string reason)
        {
            emailServer.SendEmail(CreateRefusalEmail(reason));
            Status = HolidayRequestStatus.Rejected;
        }

        private MailMessage CreateRefusalEmail(string reason)
        {
            var from = addressbook.GetMyAddress();
            var to = addressbook.GetAddressOfEmployee(employee);
            var subject = "Nope :(";
            var body = reason;
            
            return new MailMessage(from, to) { Subject = subject, Body = body };
        }
    }
}
