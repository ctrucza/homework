using NUnit.Framework;
using FurtherDecoupling.Emails;

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
            var employee = new Employee();
            var periodOfTime = new PeriodOfTime();
            var holidayRequest = new HolidayRequest(employee, periodOfTime, HolidayRequestStatus.Pending);
            
            holidayRequest.Approve();

            Assert.NotNull(emailServerMock.ObservedRecipient);
            Assert.IsNotEmpty(emailServerMock.ObservedSubject);
        }

        [Test]
        public void IsRejectionCorrectlyCommunicated()
        {
            var employee = new Employee();
            var periodOfTime = new PeriodOfTime();
            var holidayRequest = new HolidayRequest(employee, periodOfTime, HolidayRequestStatus.Pending);
            
            const string Reason = "Foo";
            holidayRequest.Reject(Reason);

            Assert.NotNull(emailServerMock.ObservedRecipient);
            Assert.IsNotEmpty(emailServerMock.ObservedSubject);
            Assert.True(emailServerMock.ObservedBody.Contains(Reason));
        }
    }
}
