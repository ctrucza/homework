namespace IOU
{
    public class Person
    {
        private readonly string name;

        private readonly string emailAddress;

        public Person(string name, string emailAddress)
        {
            this.name = name;
            this.emailAddress = emailAddress;
        }

        public static Person GetMe()
        {
            return ServiceLocator.PeopleFacade.GetMe();
        }

        public void Greet()
        {
            ServiceLocator.Presenter.SayHi(name);
        }

        public Person WhoMadeYourDay()
        {
            string searchName = ServiceLocator.Presenter.GetNameOfWhoMadeYourDay();

            BunchOfPeople people = BunchOfPeople.FindByName(searchName);
            return people.PickPerson();
        }

        public void YouMadeMyDay()
        {
            SendMail();
            // TODO: Also save event in DB
        }

        private void SendMail()
        {
            string to = emailAddress;
            string subject = GetEmailSubject();
            string body = GetEmailBody();

            ServiceLocator.MailServer.SendMail(to, subject, body);
        }

        private static string GetEmailSubject()
        {
            return "You've made my day!";
        }

        private string GetEmailBody()
        {
            return string.Format("Thanks, {0}, you've made my day! I owe you a beer!", name);
        }

        public override string ToString()
        {
            return string.Format("{0} [{1}]", name, emailAddress);
        }
    }
}