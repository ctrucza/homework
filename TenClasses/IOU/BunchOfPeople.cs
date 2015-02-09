using System;
using System.Collections.Generic;
using System.Linq;

namespace IOU
{
    public class BunchOfPeople
    {
        private readonly Person[] people;

        public BunchOfPeople(IEnumerable<Person> people)
        {
            this.people = people.ToArray();
        }

        public static BunchOfPeople FindByName(string name)
        {
            IPeopleFacade storage = ServiceLocator.PeopleFacade;
            return storage.FindByName(name);
        }

        /// <summary>
        /// High cohesion, but... annoying coupling?
        /// </summary>
        public Person PickPerson()
        {
            for (int i = 0; i < people.Length; i++)
            {
                Console.Write(i + ".\t");
                Console.WriteLine(people[i]);
            }

            int index = Convert.ToInt32(Console.ReadLine());
            return people[index];
        }
    }
}
