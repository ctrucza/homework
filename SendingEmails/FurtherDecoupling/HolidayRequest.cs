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

    public class HolidayRequest
    {
        private readonly Manager manager;
        private readonly Employee employee;
        private readonly PeriodOfTime periodOfTime;

        public HolidayRequest(Manager manager, Employee employee, PeriodOfTime periodOfTime)
        {
            this.manager = manager;
            this.employee = employee;
            this.periodOfTime = periodOfTime;
        }

        public HolidayRequestStatus Status { get; private set; }

        public void SubmitForApproval()
        {
            InformManagerAboutSubmission();
            Status = HolidayRequestStatus.Pending;
        }

        private void InformManagerAboutSubmission()
        {
            var from = employee.EmailAddress;
            var to = manager.EmailAddress;
            var subject = "Please :)";
            var body = string.Format("Some info: {0}", periodOfTime);
            
            var email = new Email(from, to, subject, body);
            email.Send();
        }

        public void Approve()
        {
            SendApproval();
            Status = HolidayRequestStatus.Approved;
        }

        private void SendApproval()
        {
            var from = manager.EmailAddress;
            var to = Configuration.EmailAddressOfHumanResources;
            var subject = "Yee :)";
            var body = string.Format("Some info: {0}, {1}", employee, periodOfTime);

            var email = new Email(from, to, subject, body);
            email.Send();
        }

        public void Reject(string reason)
        {
            SendRefusal(reason);
            Status = HolidayRequestStatus.Rejected;
        }

        private void SendRefusal(string reason)
        {
            var from = manager.EmailAddress;
            var to = employee.EmailAddress;
            var subject = "Nope :(";
            var body = reason;

            var email = new Email(from, to, subject, body);
            email.Send();
        }
    }
}
