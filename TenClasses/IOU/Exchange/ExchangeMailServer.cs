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
            
            EmailMessage message = new EmailMessage(service);
            message.ToRecipients.Add(to);
            message.Subject = subject;
            message.Body = body;

            return message;
        }
    }
}
