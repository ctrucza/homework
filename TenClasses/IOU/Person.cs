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
        }

        private void SendMail()
        {
            const string Subject = "You've made my day!";
            string body = string.Format("Thanks, {0}, you've made my day! I owe you a beer", name);

            ServiceLocator.MailServer.SendMail(emailAddress, Subject, body);
        }
        
        public override string ToString()
        {
            return string.Format("{0} [{1}]", name, emailAddress);
        }
    }
}