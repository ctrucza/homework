using System;

namespace IOU
{
    internal class Program
    {
        private static void Main()
        {
            try
            {
                SomeoneMadeYourDay();
            }
            catch (BadConfigurationException e)
            {
                Console.WriteLine(e.Message);
            }
            catch (Exception)
            {
                Console.WriteLine("You broke something.");
            }

            Console.ReadLine();
        }

        private static void SomeoneMadeYourDay()
        {
            Person me = Person.GetMe();
            me.Greet();
            Person person = me.WhoMadeYourDay();
            person.YouMadeMyDay();
        }
    }
}
