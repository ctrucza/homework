using FurtherDecoupling.Emails;
using System.Net.Mail;

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
            SaveInStorage();
            InformManagerAboutSubmission();
            Status = HolidayRequestStatus.Pending;
        }

        private void SaveInStorage()
        {
            // (?) Or not...?
            // Locate IStorage, call storage.Add(this) or so.
        }

        private void InformManagerAboutSubmission()
        {
            var subject = "Please :)";
            var body = CreateSubmissionBody();

            SendEmail(employee.EmailAddress, manager.EmailAddress, subject, body);
        }

        private string CreateSubmissionBody()
        {
            return string.Format("Some info: {0}", periodOfTime);
        }

        private void SendEmail(MailAddress from, MailAddress to, string subject, string body)
        {
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
            var subject = "Yee :)";
            var body = CreateApprovalBody();

            SendEmail(manager.EmailAddress, Configuration.EmailAddressOfHumanResources, subject, body);
        }

        private string CreateApprovalBody()
        {
            return string.Format("Some info: {0}, {1}", employee, periodOfTime);
        }

        public void Reject(string reason)
        {
            SendRefusal(reason);
            Status = HolidayRequestStatus.Rejected;
        }

        private void SendRefusal(string reason)
        {
            var subject = "Nope :(";
            var body = reason;

            SendEmail(manager.EmailAddress, employee.EmailAddress, subject, body);
        }
    }
}
