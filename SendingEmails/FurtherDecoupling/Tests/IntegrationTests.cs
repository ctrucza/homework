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

        AddressbookMock addressbookMock = new AddressbookMock();

        [SetUp]
        public void SetUpTest()
        {
            AddressbookLocator.Instance = addressbookMock;
            EmailServerLocator.Instance = emailServerMock;
        }

        [Test]
        public void IsApprovalCorrectlyCommunicated()
        {
            var managerAddress = new MailAddress("test@test.org");
            var manager = new Manager(managerAddress);

            var employeeAddress = new MailAddress("test@test.com");
            var employee = new Employee(employeeAddress);

            var periodOfTime = new PeriodOfTime();
            var holidayRequest = new HolidayRequest(manager, employee, periodOfTime, HolidayRequestStatus.Pending);
            
            holidayRequest.Approve();

            Assert.NotNull(emailServerMock.ObservedRecipient);
            Assert.IsNotEmpty(emailServerMock.ObservedSubject);
        }

        [Test]
        public void IsRejectionCorrectlyCommunicated()
        {
            var managerAddress = new MailAddress("test@test.org");
            var manager = new Manager(managerAddress);

            var employeeAddress = new MailAddress("test@test.com");
            var employee = new Employee(employeeAddress);

            var periodOfTime = new PeriodOfTime();
            var holidayRequest = new HolidayRequest(manager, employee, periodOfTime, HolidayRequestStatus.Pending);
            
            const string Reason = "Foo";
            holidayRequest.Reject(Reason);

            Assert.NotNull(emailServerMock.ObservedRecipient);
            Assert.IsNotEmpty(emailServerMock.ObservedSubject);
            Assert.True(emailServerMock.ObservedBody.Contains(Reason));
        }
    }
}
