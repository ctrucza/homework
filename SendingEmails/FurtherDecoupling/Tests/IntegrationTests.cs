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

        private readonly MailAddress managerAddress = new MailAddress("test@test.org");

        private readonly MailAddress employeeAddress = new MailAddress("test@test.com");

        [SetUp]
        public void SetUpTest()
        {
            EmailServerLocator.Instance = emailServerMock;
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

            Assert.NotNull(emailServerMock.ObservedRecipient);
            Assert.IsNotEmpty(emailServerMock.ObservedSubject);
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

            Assert.NotNull(emailServerMock.ObservedRecipient);
            Assert.IsNotEmpty(emailServerMock.ObservedSubject);
            Assert.True(emailServerMock.ObservedBody.Contains(Reason));
        }
    }
}
