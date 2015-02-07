using System;
using System.Net;
using System.Collections.Generic;
using System.Linq;

namespace IOU
{
    class Program
    {
        static void Main(string[] args)
        {
            DisableCertificateValidation();

            string name = WhoMadeYourDay();
            IEnumerable<Human> humans = Human.FindByName(name);
            Human human = ChooseWisely(humans.ToArray());
            //human.WriteToStdout();

            // TODO: WriteToConsole()? PickFromConsole()? Write comment. high cohesion, buy annoying coupling? or not
            //TODO: BunchOfHumans.FindByName() // PickFromStd;

            Console.WriteLine("Test");
        }

        static string WhoMadeYourDay()
        {
            Console.WriteLine("Who made your day?");
            string name = Console.ReadLine();
            return name;
        }

        static Human ChooseWisely(Human[] humans)
        {
            for (int i = 0; i < humans.Length; i++)
            {
                Console.Write(i + ".\t");
                //humans[i].WriteToStdout();
            }

            int no = Convert.ToInt32(Console.ReadLine());
            return humans [no];
        }

        static void DisableCertificateValidation()
        {
            ServicePointManager.ServerCertificateValidationCallback = (sender, cert, chain, errors) => true;
        }
    }
}
