using System.Collections.Generic;

namespace IOU
{
    public class BunchOfPeople
    {
        private readonly IEnumerable<Person> people;

        public BunchOfPeople(IEnumerable<Person> people)
        {
            this.people = people;
        }

        public static BunchOfPeople FindByName(string name)
        {
            IPeopleFacade storage = ServiceLocator.PeopleFacade;
            return storage.FindByName(name);
        }
    }
}
