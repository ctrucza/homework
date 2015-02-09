namespace IOU
{
    public interface IMailServer
    {
        void SendMail(string to, string subject, string body);
    }
}
