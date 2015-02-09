using System;

namespace IOU
{
    class Program
    {
        static void Main(string[] args)
        {
            Person me = Person.GetMe();
            me.Greet();

            string name = WhoMadeYourDay();
            BunchOfPeople people = BunchOfPeople.FindByName(name);
            Person person = people.PickPerson();
           
            Console.WriteLine(person);
            Console.ReadLine();
        }

        static string WhoMadeYourDay()
        {
            Console.WriteLine("Who made your day?");
            string name = Console.ReadLine();
            return name;
        }
    }
}
