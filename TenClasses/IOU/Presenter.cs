using System;

namespace IOU
{
    public class Presenter : IPresenter
    {
        public void SayHi(string name)
        {
            Console.WriteLine("Hi, {0}!", name);
        }

        public string GetNameOfWhoMadeYourDay()
        {
            Console.WriteLine("Who made your day?");
            Console.WriteLine("Enter name:");
            return Console.ReadLine();
        }

        public void DisplayPeople(BunchOfPeople people)
        {
            for (int i = 0; i < people.Count; i++)
            {
                Console.Write(i + ".\t");
                Console.WriteLine(people[i]);
            }
        }

        public int GetIndexOfSelectedPerson()
        {
            Console.WriteLine("Write index:");
            return Convert.ToInt32(Console.ReadLine());
        }
    }
}
