using System.Collections.Generic;

namespace IOU
{
    public class Human
    {
        readonly string name;

        readonly string emailAddress;

        public Human(string name, string emailAddress)
        {
            this.name = name;
            this.emailAddress = emailAddress;
        }

        public static IEnumerable<Human> FindByName(string name)
        {
            IHumansStorage storage = ServiceLocator.HumansStorage;
            return storage.FindByName(name);
        }

        public void YouMadeMyDay()
        {
        }

        static Human GetMe()
        {
            return null;
            //return new Human(Configuration.Name, Configuration.EmailAddress);
        }

        public override string ToString()
        {
            return string.Format("{0} [{1}]", name, emailAddress);
        }
    }
}

