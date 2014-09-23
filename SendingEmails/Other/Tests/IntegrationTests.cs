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
        private readonly EmailServiceMock emailServiceMock = new EmailServiceMock();

        [Test]
        public void IsApprovalCorrectlyCommunicated()
        {
            var employee = new Employee();
            var periodOfTime = new PeriodOfTime();
            var holidayRequest = new HolidayRequest(employee, periodOfTime);
            
            var decision = holidayRequest.Approve();
            decision.CommunicateViaEmail(emailServiceMock);

            Assert.NotNull(emailServiceMock.ObservedRecipient);
            Assert.IsNotEmpty(emailServiceMock.ObserverSubject);
        }

        [Test]
        public void IsRejectionCorrectlyCommunicated()
        {
            var employee = new Employee();
            var periodOfTime = new PeriodOfTime();
            var holidayRequest = new HolidayRequest(employee, periodOfTime);
            
            const string Reason = "Foo";
            var decision = holidayRequest.Reject(Reason);
            decision.CommunicateViaEmail(emailServiceMock);

            Assert.NotNull(emailServiceMock.ObservedRecipient);
            Assert.IsNotEmpty(emailServiceMock.ObserverSubject);
            Assert.True(emailServiceMock.ObservedBody.Contains(Reason));
        }
    }
}
