using System.Net.Mail;
using FurtherDecoupling.Emails;

namespace FurtherDecoupling
{
    public enum HolidayRequestStatus
    {
        Pending,
        Approved,
        Rejected
    }

    // There is one feature missing:
    // When a new request is created, it should send an email to the manager.
    // Different HolidayRequests go to different managers 
    // (depending on what project the employee currently works on)
    public class HolidayRequest
    {
        private readonly Manager manager;
        private readonly Employee employee;
        private readonly PeriodOfTime periodOfTime;

        public HolidayRequest(Manager manager, Employee employee, PeriodOfTime periodOfTime, HolidayRequestStatus status)
        {
            this.manager = manager;
            this.employee = employee;
            this.periodOfTime = periodOfTime;
            Status = status;
        }

        public HolidayRequestStatus Status { get; private set; }

        public void Approve()
        {
            Email email = CreateApprovalEmail();
            email.Send();

            Status = HolidayRequestStatus.Approved;
        }

        private Email CreateApprovalEmail()
        {
            var addressbook = AddressbookLocator.Instance;

            var from = manager.EmailAddress;
            var to = addressbook.GetAddressOfHumanResources();
            var subject = "Yee :)";
            var body = string.Format("Some info: {0}, {1}", employee, periodOfTime);

            return new Email(from, to, subject, body);
        }

        public void Reject(string reason)
        {
            Email email = CreateRefusalEmail(reason);
            email.Send();

            Status = HolidayRequestStatus.Rejected;
        }

        private Email CreateRefusalEmail(string reason)
        {
            var from = manager.EmailAddress;
            var to = employee.EmailAddress;
            var subject = "Nope :(";
            var body = reason;
            
            return new Email(from, to, subject, body);
        }
    }
}
