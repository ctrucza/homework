using NUnit.Framework;
using Other.Emails;

namespace Other.Tests
{
    /// <summary>
    /// More like a playground than a set of tests, though.
    /// </summary>
    [TestFixture]
    public class IntegrationTests
    {
        private readonly EmailServerMock emailServerMock = new EmailServerMock();

        [Test]
        public void IsApprovalCorrectlyCommunicated()
        {
            var employee = new Employee();
            var periodOfTime = new PeriodOfTime();
            var holidayRequest = new HolidayRequest(employee, periodOfTime);
            
            var decision = holidayRequest.Approve();
            decision.CommunicateViaEmail(emailServerMock);

            Assert.NotNull(emailServerMock.ObservedRecipient);
            Assert.IsNotEmpty(emailServerMock.ObservedSubject);
        }

        [Test]
        public void IsRejectionCorrectlyCommunicated()
        {
            var employee = new Employee();
            var periodOfTime = new PeriodOfTime();
            var holidayRequest = new HolidayRequest(employee, periodOfTime);
            
            const string Reason = "Foo";
            var decision = holidayRequest.Reject(Reason);
            decision.CommunicateViaEmail(emailServerMock);

            Assert.NotNull(emailServerMock.ObservedRecipient);
            Assert.IsNotEmpty(emailServerMock.ObservedSubject);
            Assert.True(emailServerMock.ObservedBody.Contains(Reason));
        }
    }
}
