using System;

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
            IPeopleFacade storage = ServiceLocator.PeopleFacade;
            return storage.GetMe();
        }

        public void Greet()
        {
            Console.WriteLine("Hi, {0}!", name);
        }

        public void YouMadeMyDay()
        {
        }
        
        public override string ToString()
        {
            return string.Format("{0} [{1}]", name, emailAddress);
        }
    }
}