using System.Collections.Generic;

namespace IOU
{
    public class Person
    {
        readonly string name;

        readonly string emailAddress;

        public Person(string name, string emailAddress)
        {
            this.name = name;
            this.emailAddress = emailAddress;
        }

        public void YouMadeMyDay()
        {
        }

        static Person GetMe()
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

