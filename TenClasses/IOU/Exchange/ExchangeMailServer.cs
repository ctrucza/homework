using Microsoft.Exchange.WebServices.Data;

namespace IOU.Exchange
{
    public class ExchangeMailServer : IMailServer
    {
        public void SendMail(string to, string subject, string body)
        {
            EmailMessage message = CreateMessage(to, subject, body);
            message.SendAndSaveCopy();
        }

        private static EmailMessage CreateMessage(string to, string subject, string body)
        {
            ExchangeService service = ExchangeServicesLocator.GetExchangeService();
            EmailMessage message = new EmailMessage(service) { Subject = subject, Body = body };
            message.ToRecipients.Add(to);
            return message;
        }
    }
}
