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
        private readonly Employee employee;
        private readonly PeriodOfTime periodOfTime;
        // HolidayRequest depending on EmailServer is weird.
        // I would create an Email class (from, to, subject, body) with a method Send()
        private readonly EmailServer emailServer;
        // You don't really need an addressbook:
        // A HolidayRequest has 2 properties: 
        //      - Employee and Manager. They noth have email addresses.
        //      - there is only one HR email, best kept in the app configuration
        private readonly Addressbook addressbook;

        public HolidayRequest(Employee employee, PeriodOfTime periodOfTime, HolidayRequestStatus status)
        {
            this.employee = employee;
            this.periodOfTime = periodOfTime;
            Status = status;

            // If you extract an Email class and use the Employee, Manager and app config (as above)
            // you don't need these services here.
            emailServer = EmailServerLocator.Instance;
            addressbook = AddressbookLocator.Instance;
        }

        public HolidayRequestStatus Status { get; private set; }

        public void Approve()
        {
            // My take woud be:
            // Email email = new Email(manager.email, hr.email, "Approval", CreateApprovalBody());
            // email.Send();
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
