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
        EmailServerMock emailServerMock = new EmailServerMock();

        readonly MailAddress managerAddress = new MailAddress("test@test.org");

        readonly MailAddress employeeAddress = new MailAddress("test@test.com");

        readonly MailAddress hrAddress = Configuration.EmailAddressOfHumanResources;

        [SetUp]
        public void SetUpTest()
        {
            EmailServerLocator.Instance = emailServerMock;
        }

        [Test]
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
