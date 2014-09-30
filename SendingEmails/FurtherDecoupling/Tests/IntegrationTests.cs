using NUnit.Framework;
using FurtherDecoupling.Emails;
using System.Net.Mail;

namespace FurtherDecoupling.Tests
{
    /// <summary>
    /// More like a playground than a set of tests, though.
    /// </summary>
    [TestFixture]
    public class IntegrationTests
    {
        readonly EmailServerMock emailServerMock = new EmailServerMock();
        readonly MailAddress managerAddress = new MailAddress("test@test.org");
        readonly MailAddress employeeAddress = new MailAddress("test@test.com");
        readonly MailAddress hrAddress = Configuration.EmailAddressOfHumanResources;

        [SetUp]
        public void SetUpTest()
        {
            EmailServerLocator.Instance = emailServerMock;
        }

        // General comment on these test names:
        // Naming is hard. Naming unit tests is hard and controversial.
        // I like my test names to be a little bit more explicit about what they test.
        [Test]
        // I'd call it:
        //      email_is_sent_to_manager_on_submission
        // but this test checks two different things:
        //      that on submission the status is Pending
        //      and that a mail is sent to the manager
        //
        // Maybe breaking up into two tests?
        //      submission_sends_mail_to_manager
        //      submission_marks_the_request_as_pending
        // (and put it in HolidayRequestTests)
        //
        //  Checking two different things opens up some design questions too:
        //      what is the status of a request before submission?
        public void CanCorrectlySubmitARequest()
        {
            var manager = new Manager(managerAddress);
            var employee = new Employee(employeeAddress);
            
            var periodOfTime = new PeriodOfTime();
            var holidayRequest = new HolidayRequest(manager, employee, periodOfTime);

            holidayRequest.SubmitForApproval();

            Assert.AreEqual(HolidayRequestStatus.Pending, holidayRequest.Status);
            Assert.AreEqual(employeeAddress, emailServerMock.ObservedSender);
            Assert.AreEqual(managerAddress, emailServerMock.ObservedRecipient);
        }

        [Test]
        // same two-check problem
        //      approval_send_mail_to_hr
        //      approval_marks_the_request_as_approved
        public void IsApprovalCorrectlyCommunicated()
        {
            var manager = new Manager(managerAddress);
            var employee = new Employee(employeeAddress);

            var periodOfTime = new PeriodOfTime();
            var holidayRequest = new HolidayRequest(manager, employee, periodOfTime);

            holidayRequest.SubmitForApproval();
            holidayRequest.Approve();

            Assert.AreEqual(HolidayRequestStatus.Approved, holidayRequest.Status);
            Assert.AreEqual(managerAddress, emailServerMock.ObservedSender);
            Assert.AreEqual(hrAddress, emailServerMock.ObservedRecipient);
        }

        [Test]
        // same two-checks
        //  rejection_sends_mail_to_employee
        public void IsRejectionCorrectlyCommunicated()
        {
            var manager = new Manager(managerAddress);
            var employee = new Employee(employeeAddress);

            var periodOfTime = new PeriodOfTime();
            var holidayRequest = new HolidayRequest(manager, employee, periodOfTime);

            holidayRequest.SubmitForApproval();

            const string Reason = "Foo";
            holidayRequest.Reject("Foo");

            Assert.AreEqual(HolidayRequestStatus.Rejected, holidayRequest.Status);
            Assert.AreEqual(managerAddress, emailServerMock.ObservedSender);
            Assert.AreEqual(employeeAddress, emailServerMock.ObservedRecipient);
            Assert.True(emailServerMock.ObservedBody.Contains(Reason));
        }
    }
}
