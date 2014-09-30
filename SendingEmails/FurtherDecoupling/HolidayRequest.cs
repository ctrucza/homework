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
            // take a look at this and the other two email-sending methods
            // they look much alike.
            // What would andreib do?
            var subject = "Please :)";
            var body = CreateSubmissionBody();

            var email = new Email(employee.EmailAddress, manager.EmailAddress, subject, body);
            email.Send();
        }

        private string CreateSubmissionBody()
        {
            return string.Format("Some info: {0}", periodOfTime);
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

            var email = new Email(manager.EmailAddress, Configuration.EmailAddressOfHumanResources, subject, body);
            email.Send();
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

            var email = new Email(manager.EmailAddress, employee.EmailAddress, subject, body);
            email.Send();
        }
    }
}
